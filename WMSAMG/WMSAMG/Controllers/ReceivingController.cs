using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Claims;
using WMSAMG.Models.CSIS2017Models;

namespace WMSAMG.Controllers
{
    [Authorize]
    public class ReceivingController : Controller
    {
        private readonly IConfiguration _configuration;

        public ReceivingController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // GET: Receiving
        public IActionResult Index()
        {
            //string email = HttpContext.User.Identity.Name;
            //ViewBag.UserEmail = email;

            DataTable dt = new DataTable();
            using (SqlConnection sqlConnection = new SqlConnection(_configuration.GetConnectionString("DataContextConnection")))
            {
                sqlConnection.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("spSelect_ReceivingDetailbyFilter", sqlConnection);
                sqlDa.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sqlDa.SelectCommand.Parameters.AddWithValue("TextFilter", "aea95735-24df-40a2-9132-5cbff7595bb9");
                sqlDa.SelectCommand.Parameters.AddWithValue("ColumnName", "LocationID");
                sqlDa.Fill(dt);
            }
            ViewBag.datasource = dt;
            return View(dt);

        }

        public IActionResult BlastingIn()
        {
            //string email = HttpContext.User.Identity.Name;
            //ViewBag.UserEmail = email;

            DataTable dt = new DataTable();
            using (SqlConnection sqlConnection = new SqlConnection(_configuration.GetConnectionString("DataContextConnection")))
            {
                sqlConnection.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("spSelect_BlastingInbyFilter", sqlConnection);
                sqlDa.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sqlDa.SelectCommand.Parameters.AddWithValue("TextFilter", "aea95735-24df-40a2-9132-5cbff7595bb9");
                sqlDa.SelectCommand.Parameters.AddWithValue("ColumnName", "LocationID");
                sqlDa.Fill(dt);
            }
            ViewBag.datasource = dt;
            return View(dt);

        }

        

        // GET: Receiving/AddorEdit/Guid or RefNo
        public IActionResult AddorEdit(string id)
        {
            TblReceivingDetail tblReceiving = new TblReceivingDetail();

            if (!string.IsNullOrEmpty(id))
            {
                if (id.Substring(0, 3) == "GSC" && ModelState.IsValid)
                {
                    tblReceiving.Rrcode = id;
                    tblReceiving.Nature = "RR";
                    tblReceiving.LocationId = Guid.Parse("aea95735-24df-40a2-9132-5cbff7595bb9");
                    tblReceiving.ApprovedBy = Guid.Parse(this.User.FindFirstValue(ClaimTypes.NameIdentifier).Replace(" ", ""));
                    tblReceiving.EmployeeId = Guid.Parse(this.User.FindFirstValue(ClaimTypes.NameIdentifier).Replace(" ", ""));
                    tblReceiving.ReferenceCode = Guid.Empty;
                    tblReceiving.CarrierReferenceCode = Guid.Empty;
                    tblReceiving.TransactionDate = DateTime.Now;
                }
                else
                {
                    tblReceiving = FetchRecordByID(id);
                }
            }
            else
            {
                tblReceiving.Nature = "RR";
                tblReceiving.LocationId = Guid.Parse("aea95735-24df-40a2-9132-5cbff7595bb9");
                tblReceiving.Rrcode = "GSC" + tblReceiving.Nature + GetReferenceNo(tblReceiving.Nature, tblReceiving.LocationId);
                tblReceiving.ApprovedBy = Guid.Parse(this.User.FindFirstValue(ClaimTypes.NameIdentifier).Replace(" ", ""));
                tblReceiving.EmployeeId = Guid.Parse(this.User.FindFirstValue(ClaimTypes.NameIdentifier).Replace(" ", ""));
                tblReceiving.CarrierReferenceCode = Guid.Empty;
            }

            return View(tblReceiving);
        }

        // GET: Receiving/AddorEditBlastIn/Guid or RefNo
        public IActionResult AddorEditBlastIn(string id)
        {
            TblReceivingDetail tblReceiving = new TblReceivingDetail();
            
            if (!string.IsNullOrEmpty(id))
            {
                if (id.Substring(0, 3) == "GSC" && ModelState.IsValid)
                {
                    tblReceiving.Rrcode = id;
                    tblReceiving.Nature = "RR";
                    tblReceiving.LocationId = Guid.Parse("aea95735-24df-40a2-9132-5cbff7595bb9");
                    tblReceiving.ApprovedBy = Guid.Parse(this.User.FindFirstValue(ClaimTypes.NameIdentifier).Replace(" ", ""));
                    tblReceiving.EmployeeId = Guid.Parse(this.User.FindFirstValue(ClaimTypes.NameIdentifier).Replace(" ", ""));
                    tblReceiving.ReferenceCode = Guid.Empty;
                    tblReceiving.CarrierReferenceCode = Guid.Empty;
                    tblReceiving.TransactionDate = DateTime.Now;
                }
                else
                {
                    tblReceiving = FetchRecordByID(id);
                }
            }
            else
            {
                tblReceiving.Nature = "RR";
                tblReceiving.LocationId = Guid.Parse("aea95735-24df-40a2-9132-5cbff7595bb9");
                tblReceiving.Rrcode = "GSC" + tblReceiving.Nature + GetReferenceNo(tblReceiving.Nature, tblReceiving.LocationId);
                tblReceiving.ApprovedBy = Guid.Parse(this.User.FindFirstValue(ClaimTypes.NameIdentifier).Replace(" ", ""));
                tblReceiving.EmployeeId = Guid.Parse(this.User.FindFirstValue(ClaimTypes.NameIdentifier).Replace(" ", ""));
                tblReceiving.CarrierReferenceCode = Guid.Empty;
            }

            return View(tblReceiving);
        }

        // POST: Receiving/AddorEdit
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddorEdit([Bind("ReferenceCode,Rrcode,CarrierReferenceCode,CustomerId,CustomerName,PayTypeInitial,StockId,StockSku,StockDescription,Size,StockGroupId,StockPcsperPack,StockPackperCase,Qty,ActualWeight,Uom,ReceivingTime,EndTime,StockWeightinKilosperPack,StockWeightinKilosperCase,PalletNo,CompanyId,StorageLocationId,StorageId,StorageTypeId,TransactionDate,LocationId,Nature,Source,Remarks,ApprovedBy,EmployeeId,EmployeeDate,IsSaved")] TblReceivingDetail tblReceivingDetail)
        {
            string Rrcode = tblReceivingDetail.Rrcode;
            DateTime? ReceivingTime = tblReceivingDetail.ReceivingTime;
            string Remarks = tblReceivingDetail.Remarks;
            //int successindx = 0;
            if (!ModelState.IsValid)
            {
                //var query = from state in ModelState.Values
                //            from error in state.Errors
                //            select error.ErrorMessage;
                var errors = ModelState.ErrorCount.ToString();
                ViewBag.ErrorMsg = errors;
            }

            if (ModelState.IsValid)
            {
                using (SqlConnection sqlConnection = new SqlConnection(_configuration.GetConnectionString("DataContextConnection")))
                {
                    sqlConnection.Open();
                    SqlCommand sqlCmd = new SqlCommand("spInsert_ReceivingDetail", sqlConnection);
                    sqlCmd.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("ReferenceCode", tblReceivingDetail.ReferenceCode);
                    sqlCmd.Parameters.AddWithValue("RRCode", tblReceivingDetail.Rrcode);
                    sqlCmd.Parameters.AddWithValue("CarrierReferenceCode", tblReceivingDetail.CarrierReferenceCode);
                    sqlCmd.Parameters.AddWithValue("CustomerID", tblReceivingDetail.CustomerId);
                    sqlCmd.Parameters.AddWithValue("PayTypeInitial", tblReceivingDetail.PayTypeInitial);
                    sqlCmd.Parameters.AddWithValue("StockID", tblReceivingDetail.StockId);
                    sqlCmd.Parameters.AddWithValue("StockSKU", tblReceivingDetail.StockSku);
                    sqlCmd.Parameters.AddWithValue("Size", tblReceivingDetail.Size);
                    sqlCmd.Parameters.AddWithValue("StockGroupID", tblReceivingDetail.StockGroupId);
                    sqlCmd.Parameters.AddWithValue("StockPcsperPack", tblReceivingDetail.StockPcsperPack);
                    sqlCmd.Parameters.AddWithValue("StockPackperCase", tblReceivingDetail.StockPackperCase);
                    sqlCmd.Parameters.AddWithValue("Qty", tblReceivingDetail.Qty);
                    sqlCmd.Parameters.AddWithValue("ActualWeight", tblReceivingDetail.ActualWeight);
                    sqlCmd.Parameters.AddWithValue("UOM", tblReceivingDetail.Uom);
                    sqlCmd.Parameters.AddWithValue("ReceivingTime", tblReceivingDetail.ReceivingTime);
                    sqlCmd.Parameters.AddWithValue("EndTime", tblReceivingDetail.EndTime);
                    sqlCmd.Parameters.AddWithValue("StockWeightinKilosperPack", tblReceivingDetail.StockWeightinKilosperPack);
                    sqlCmd.Parameters.AddWithValue("StockWeightinKilosperCase", tblReceivingDetail.StockWeightinKilosperCase);
                    sqlCmd.Parameters.AddWithValue("PalletNo", "");
                    sqlCmd.Parameters.AddWithValue("CompanyID", tblReceivingDetail.CompanyId);
                    sqlCmd.Parameters.AddWithValue("TransactionDate", DateTime.Now);
                    sqlCmd.Parameters.AddWithValue("LocationID", tblReceivingDetail.LocationId);
                    sqlCmd.Parameters.AddWithValue("Nature", tblReceivingDetail.Nature);
                    sqlCmd.Parameters.AddWithValue("Source", tblReceivingDetail.Nature);
                    sqlCmd.Parameters.AddWithValue("Remarks", tblReceivingDetail.Remarks);
                    sqlCmd.Parameters.AddWithValue("ApprovedBy", tblReceivingDetail.EmployeeId);
                    sqlCmd.Parameters.AddWithValue("EmployeeID", tblReceivingDetail.EmployeeId);
                    sqlCmd.Parameters.AddWithValue("isSaved", 1);
                    sqlCmd.ExecuteNonQuery();
                }
                if (!string.IsNullOrEmpty(tblReceivingDetail.ReferenceCode.ToString()))
                {
                    //tblReceivingDetail = new TblReceivingDetail();
                    //tblReceivingDetail.Nature = "RR";
                    //tblReceivingDetail.LocationId = Guid.Parse("aea95735-24df-40a2-9132-5cbff7595bb9");
                    //tblReceivingDetail.Rrcode = Rrcode;
                    //tblReceivingDetail.ReceivingTime = ReceivingTime;
                    //tblReceivingDetail.Remarks = Remarks;
                    //tblReceivingDetail.ApprovedBy = Guid.Parse(this.User.FindFirstValue(ClaimTypes.NameIdentifier).Replace(" ", ""));
                    //tblReceivingDetail.EmployeeId = Guid.Parse(this.User.FindFirstValue(ClaimTypes.NameIdentifier).Replace(" ", ""));
                    //tblReceivingDetail.CarrierReferenceCode = Guid.Empty;
                   
                    tblReceivingDetail.ActualWeight = 0;
                    tblReceivingDetail.ReferenceCode = Guid.Empty;
                    return View(tblReceivingDetail);
                }
                else
                {
                    return RedirectToAction(nameof(Index));
                }

            }
            else
            {
                tblReceivingDetail = new TblReceivingDetail();
                tblReceivingDetail.Nature = "RR";
                tblReceivingDetail.LocationId = Guid.Parse("aea95735-24df-40a2-9132-5cbff7595bb9");
                tblReceivingDetail.Rrcode = "GSC" + tblReceivingDetail.Nature + GetReferenceNo(tblReceivingDetail.Nature, tblReceivingDetail.LocationId);
                tblReceivingDetail.ApprovedBy = Guid.Parse(this.User.FindFirstValue(ClaimTypes.NameIdentifier).Replace(" ", ""));
                tblReceivingDetail.EmployeeId = Guid.Parse(this.User.FindFirstValue(ClaimTypes.NameIdentifier).Replace(" ", ""));
                tblReceivingDetail.CarrierReferenceCode = Guid.Empty;
            }

            return View(tblReceivingDetail);

        }

        // POST: Receiving/AddorEditBlastIn
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddorEditBlastIn([Bind("ReferenceCode,Rrcode,CarrierReferenceCode,CustomerId,CustomerName,PayTypeInitial,StockId,StockSku,StockDescription,Size,StockGroupId,StockPcsperPack,StockPackperCase,Qty,ActualWeight,Uom,ReceivingTime,EndTime,StockWeightinKilosperPack,StockWeightinKilosperCase,PalletNo,CompanyId,StorageLocationId,StorageId,StorageTypeId,TransactionDate,LocationId,Nature,Source,Remarks,ApprovedBy,EmployeeId,EmployeeDate,IsSaved")] TblReceivingDetail tblReceivingDetail)
        {
            string Rrcode = tblReceivingDetail.Rrcode;
            DateTime? ReceivingTime = tblReceivingDetail.ReceivingTime;
            string Remarks = tblReceivingDetail.Remarks;
            //int successindx = 0;
            if (!ModelState.IsValid)
            {
                //var query = from state in ModelState.Values
                //            from error in state.Errors
                //            select error.ErrorMessage;
                var errors = ModelState.ErrorCount.ToString();
                ViewBag.ErrorMsg = errors;
            }

            if (ModelState.IsValid)
            {
                using (SqlConnection sqlConnection = new SqlConnection(_configuration.GetConnectionString("DataContextConnection")))
                {
                    sqlConnection.Open();
                    SqlCommand sqlCmd = new SqlCommand("spInsert_ReceivingDetail", sqlConnection);
                    sqlCmd.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("ReferenceCode", tblReceivingDetail.ReferenceCode);
                    sqlCmd.Parameters.AddWithValue("RRCode", tblReceivingDetail.Rrcode);
                    sqlCmd.Parameters.AddWithValue("CarrierReferenceCode", tblReceivingDetail.CarrierReferenceCode);
                    sqlCmd.Parameters.AddWithValue("CustomerID", tblReceivingDetail.CustomerId);
                    sqlCmd.Parameters.AddWithValue("PayTypeInitial", tblReceivingDetail.PayTypeInitial);
                    sqlCmd.Parameters.AddWithValue("StockID", tblReceivingDetail.StockId);
                    sqlCmd.Parameters.AddWithValue("StockSKU", tblReceivingDetail.StockSku);
                    sqlCmd.Parameters.AddWithValue("Size", tblReceivingDetail.Size);
                    sqlCmd.Parameters.AddWithValue("StockGroupID", tblReceivingDetail.StockGroupId);
                    sqlCmd.Parameters.AddWithValue("StockPcsperPack", tblReceivingDetail.StockPcsperPack);
                    sqlCmd.Parameters.AddWithValue("StockPackperCase", tblReceivingDetail.StockPackperCase);
                    sqlCmd.Parameters.AddWithValue("Qty", tblReceivingDetail.Qty);
                    sqlCmd.Parameters.AddWithValue("ActualWeight", tblReceivingDetail.ActualWeight);
                    sqlCmd.Parameters.AddWithValue("UOM", tblReceivingDetail.Uom);
                    sqlCmd.Parameters.AddWithValue("ReceivingTime", tblReceivingDetail.ReceivingTime);
                    sqlCmd.Parameters.AddWithValue("EndTime", tblReceivingDetail.EndTime);
                    sqlCmd.Parameters.AddWithValue("StockWeightinKilosperPack", tblReceivingDetail.StockWeightinKilosperPack);
                    sqlCmd.Parameters.AddWithValue("StockWeightinKilosperCase", tblReceivingDetail.StockWeightinKilosperCase);
                    sqlCmd.Parameters.AddWithValue("PalletNo", "");
                    sqlCmd.Parameters.AddWithValue("CompanyID", tblReceivingDetail.CompanyId);
                    sqlCmd.Parameters.AddWithValue("TransactionDate", DateTime.Now);
                    sqlCmd.Parameters.AddWithValue("LocationID", tblReceivingDetail.LocationId);
                    sqlCmd.Parameters.AddWithValue("Nature", tblReceivingDetail.Nature);
                    sqlCmd.Parameters.AddWithValue("Source", tblReceivingDetail.Nature);
                    sqlCmd.Parameters.AddWithValue("Remarks", tblReceivingDetail.Remarks);
                    sqlCmd.Parameters.AddWithValue("ApprovedBy", tblReceivingDetail.EmployeeId);
                    sqlCmd.Parameters.AddWithValue("EmployeeID", tblReceivingDetail.EmployeeId);
                    sqlCmd.Parameters.AddWithValue("isSaved", 0);
                    sqlCmd.ExecuteNonQuery();
                }
                if (!string.IsNullOrEmpty(tblReceivingDetail.ReferenceCode.ToString()))
                {
                    //tblReceivingDetail = new TblReceivingDetail();
                    //tblReceivingDetail.Nature = "RR";
                    //tblReceivingDetail.LocationId = Guid.Parse("aea95735-24df-40a2-9132-5cbff7595bb9");
                    //tblReceivingDetail.Rrcode = Rrcode;
                    //tblReceivingDetail.ReceivingTime = ReceivingTime;
                    //tblReceivingDetail.Remarks = Remarks;
                    //tblReceivingDetail.ApprovedBy = Guid.Parse(this.User.FindFirstValue(ClaimTypes.NameIdentifier).Replace(" ", ""));
                    //tblReceivingDetail.EmployeeId = Guid.Parse(this.User.FindFirstValue(ClaimTypes.NameIdentifier).Replace(" ", ""));
                    //tblReceivingDetail.CarrierReferenceCode = Guid.Empty;
                    tblReceivingDetail.ActualWeight = 0;
                    tblReceivingDetail.ReferenceCode = Guid.Empty;
                    return View(tblReceivingDetail);
                }
                else
                {
                    return RedirectToAction(nameof(Index));
                }

            }
            else
            {
                tblReceivingDetail = new TblReceivingDetail();
                tblReceivingDetail.Nature = "RR";
                tblReceivingDetail.LocationId = Guid.Parse("aea95735-24df-40a2-9132-5cbff7595bb9");
                tblReceivingDetail.Rrcode = "GSC" + tblReceivingDetail.Nature + GetReferenceNo(tblReceivingDetail.Nature, tblReceivingDetail.LocationId);
                tblReceivingDetail.ApprovedBy = Guid.Parse(this.User.FindFirstValue(ClaimTypes.NameIdentifier).Replace(" ", ""));
                tblReceivingDetail.EmployeeId = Guid.Parse(this.User.FindFirstValue(ClaimTypes.NameIdentifier).Replace(" ", ""));
                tblReceivingDetail.CarrierReferenceCode = Guid.Empty;
                

            }

            return View(tblReceivingDetail);

        }

        public IActionResult ColdStorage1()
        {

            DataTable dt = new DataTable();
            using (SqlConnection sqlConnection = new SqlConnection(_configuration.GetConnectionString("DataContextConnection")))
            {
                sqlConnection.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("spSelect_ActualInventoryByStorageName", sqlConnection);
                sqlDa.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sqlDa.SelectCommand.Parameters.AddWithValue("CompanyID", "35a953cd-49b0-4db4-b5ec-2aa23733a5e2");
                sqlDa.SelectCommand.Parameters.AddWithValue("LocationID", "aea95735-24df-40a2-9132-5cbff7595bb9");
                sqlDa.SelectCommand.Parameters.AddWithValue("StorageName", "COLD STORE 1");
                sqlDa.Fill(dt);
            }

            ViewBag.datasource = dt;
            return View();

        }

        public string GenerateProdDateRefNo()
        {
            string PDRno = "PD-";
            DateTime date = DateTime.Now;

            PDRno = PDRno + date.ToString("yy").Substring(1, 1) + date.ToString("MM") + date.ToString("dd");

            return PDRno;
        }

        // GET: Receiving/Delete/5
        public IActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }



            return View();
        }

        // POST: Receiving/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {

            return RedirectToAction(nameof(Index));
        }

        [NonAction]
        public TblReceivingDetail FetchRecordByID(string id)
        {

            DataTable dt = new DataTable();
            TblReceivingDetail tblReceiving = new TblReceivingDetail();

            //tblReceiving.Customers = PopulateCustomers();

            using (SqlConnection sqlConnection = new SqlConnection(_configuration.GetConnectionString("DataContextConnection")))
            {
                sqlConnection.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("spSelect_AllReceivingDetailbyFilter", sqlConnection);
                sqlDa.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sqlDa.SelectCommand.Parameters.AddWithValue("TextFilter", id);
                sqlDa.SelectCommand.Parameters.AddWithValue("ColumnName", "ReferenceCode");
                sqlDa.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    tblReceiving.ReferenceCode = (Guid)dt.Rows[0]["ReferenceCode"];
                    tblReceiving.Rrcode = dt.Rows[0]["RRCode"].ToString();
                    tblReceiving.CarrierReferenceCode = (Guid)dt.Rows[0]["CarrierReferenceCode"];
                    tblReceiving.CustomerId = dt.Rows[0]["CustomerID"].ToString();
                    tblReceiving.CustomerName = dt.Rows[0]["CustomerName"].ToString();
                    tblReceiving.PayTypeInitial = dt.Rows[0]["PayTypeInitial"].ToString();
                    tblReceiving.StockId = (Guid)dt.Rows[0]["StockID"];
                    tblReceiving.StockGroupId = (Guid)dt.Rows[0]["StockGroupID"];
                    tblReceiving.StockSku = dt.Rows[0]["StockSKU"].ToString();
                    tblReceiving.StockDescription = dt.Rows[0]["StockDescription"].ToString();
                    tblReceiving.Qty = Convert.ToInt64(dt.Rows[0]["Qty"]);
                    tblReceiving.ActualWeight = Convert.ToDecimal(dt.Rows[0]["ActualWeight"]);
                    tblReceiving.Uom = dt.Rows[0]["UOM"].ToString();
                    tblReceiving.PalletNo = dt.Rows[0]["PalletNo"].ToString();
                    tblReceiving.CompanyId = (Guid)dt.Rows[0]["CompanyId"];
                    tblReceiving.CompanyName = dt.Rows[0]["CompanyName"].ToString();
                    tblReceiving.LocationId = (Guid)dt.Rows[0]["LocationID"];
                    tblReceiving.LocationInitial = dt.Rows[0]["LocationInitial"].ToString();
                    tblReceiving.ReceivingTime = Convert.ToDateTime(dt.Rows[0]["ReceivingTime"]);
                    tblReceiving.EndTime = Convert.ToDateTime(dt.Rows[0]["EndTime"]);
                    tblReceiving.Remarks = dt.Rows[0]["Remarks"].ToString();
                    tblReceiving.StockPcsperPack = Convert.ToInt64(dt.Rows[0]["StockPcsperPack"]);
                    tblReceiving.StockPackperCase = Convert.ToInt64(dt.Rows[0]["StockPackperCase"]);
                    tblReceiving.StockWeightinKilosperPack = Convert.ToInt64(dt.Rows[0]["StockWeightinKilosperPack"]);
                    tblReceiving.StockWeightinKilosperCase = Convert.ToInt64(dt.Rows[0]["StockWeightinKilosperCase"]);
                    tblReceiving.TransactionDate = Convert.ToDateTime(dt.Rows[0]["TransactionDate"]);
                    tblReceiving.Nature = dt.Rows[0]["Nature"].ToString();
                    tblReceiving.Source = dt.Rows[0]["Source"].ToString();
                    tblReceiving.EmployeeId = GetNullable<Guid>(dt.Rows[0]["EmployeeID"]);
                    tblReceiving.ApprovedBy = GetNullable<Guid>(dt.Rows[0]["ApprovedBy"]);
                    tblReceiving.EmployeeDate = Convert.ToDateTime(dt.Rows[0]["EmployeeDate"]);
                    tblReceiving.IsSaved = (Boolean)dt.Rows[0]["IsSaved"];
                }
            }

            return tblReceiving;
        }

        public static T? GetNullable<T>(object obj) where T : struct
        {
            if (obj == DBNull.Value) return null;
            return (T?)obj;
        }

        public List<SelectListItem> PopulateCustomers()
        {
            List<SelectListItem> items = new List<SelectListItem>();
            using (SqlConnection sqlConnection = new SqlConnection(_configuration.GetConnectionString("AuthContextConnection")))
            {
                sqlConnection.Open();
                SqlCommand sqlCmd = new SqlCommand("spSelect_CustomerbyFilter", sqlConnection);
                sqlCmd.Parameters.AddWithValue("TextFilter", "");
                sqlCmd.Parameters.AddWithValue("ColumnName", "CustomerName");
                sqlCmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader sqlDr = sqlCmd.ExecuteReader();

                while (sqlDr.Read())
                {
                    items.Add(new SelectListItem
                    {
                        Text = sqlDr["CustomerName"].ToString(),
                        Value = sqlDr["CustomerID"].ToString()
                    });

                }

            }
            return items;
        }

        public List<SelectListItem> PopulateStocks(Guid? id)
        {
            List<SelectListItem> items = new List<SelectListItem>();
            using (SqlConnection sqlConnection = new SqlConnection(_configuration.GetConnectionString("AuthContextConnection")))
            {
                sqlConnection.Open();
                SqlCommand sqlCmd = new SqlCommand("spSelect_StocksbyFilter", sqlConnection);
                sqlCmd.Parameters.AddWithValue("TextFilter", id);
                sqlCmd.Parameters.AddWithValue("ColumnName", "CustomerID");
                sqlCmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader sqlDr = sqlCmd.ExecuteReader();

                while (sqlDr.Read())
                {
                    items.Add(new SelectListItem
                    {
                        Text = sqlDr["CustomerName"].ToString(),
                        Value = sqlDr["CustomerID"].ToString()
                    });

                }

            }
            return items;
        }

        [NonAction]
        public string GetReferenceNo(string nature, Guid? locationid)
        {
            string RrCode = String.Empty;
            using (SqlConnection sqlConnection = new SqlConnection(_configuration.GetConnectionString("DataContextConnection")))
            {
                sqlConnection.Open();
                SqlCommand sqlCmd = new SqlCommand("spSelect_AvailableRRCode", sqlConnection);
                sqlCmd.Parameters.AddWithValue("LocationID", locationid);
                sqlCmd.Parameters.AddWithValue("Nature", nature);
                sqlCmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader sqlDr = sqlCmd.ExecuteReader();

                while (sqlDr.Read())
                {
                    RrCode = sqlDr[2].ToString();
                }
            }
            return RrCode;
        }

        public JsonResult GetRecordsbyRRNo(string Id)
        {
            if (Id is null)
            {
                Id = "";
            }
            DataTable dt = new DataTable();
            using (SqlConnection sqlConnection = new SqlConnection(_configuration.GetConnectionString("DataContextConnection")))
            {
                sqlConnection.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("spSelect_ReceivingDetailbyFilter", sqlConnection);
                sqlDa.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sqlDa.SelectCommand.Parameters.AddWithValue("TextFilter", Id);
                sqlDa.SelectCommand.Parameters.AddWithValue("ColumnName", "RRCode");
                sqlDa.Fill(dt);
            }
            List<VwReceivingDetail> vwReceivingDetails = dt.AsEnumerable().Select(row =>
                new VwReceivingDetail
                {
                    ReferenceCode = row.Field<Guid>("ReferenceCode"),
                    Remarks = row.Field<string>("Remarks"),
                    Rrcode = row.Field<string>("RRCode"),
                    CustomerId = row.Field<string>("CustomerID"),
                    CustomerName = row.Field<string>("CustomerName"),
                    PayTypeInitial = row.Field<string>("PayTypeInitial"),
                    StockId = row.Field<Guid>("StockID"),
                    StockSku = row.Field<string>("StockSKU"),
                    StockPcsperPack = row.Field<decimal>("StockPcsperPack"),
                    StockDescription = row.Field<string>("StockDescription"),
                    Qty = row.Field<decimal>("Qty"),
                    ActualWeight = row.Field<decimal>("ActualWeight"),
                    ReceivingTime = row.Field<Nullable<DateTime>>("ReceivingTime"),
                    EndTime = row.Field<Nullable<DateTime>>("EndTime"),
                    LineNum = row.Field<int>("LineNum")

                }).ToList();


            return Json(vwReceivingDetails, new System.Text.Json.JsonSerializerOptions());

        }

        public JsonResult GetRecordsbyRRNoBlastIn(string Id)
        {
            if (Id is null)
            {
                Id = "";
            }
            DataTable dt = new DataTable();
            using (SqlConnection sqlConnection = new SqlConnection(_configuration.GetConnectionString("DataContextConnection")))
            {
                sqlConnection.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("spSelect_BlastingInbyFilter", sqlConnection);
                sqlDa.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sqlDa.SelectCommand.Parameters.AddWithValue("TextFilter", Id);
                sqlDa.SelectCommand.Parameters.AddWithValue("ColumnName", "RRCode");
                sqlDa.Fill(dt);
            }
            List<VwReceivingDetail> vwReceivingDetails = dt.AsEnumerable().Select(row =>
                new VwReceivingDetail
                {
                    ReferenceCode = row.Field<Guid>("ReferenceCode"),
                    Remarks = row.Field<string>("Remarks"),
                    Rrcode = row.Field<string>("RRCode"),
                    CustomerId = row.Field<string>("CustomerID"),
                    CustomerName = row.Field<string>("CustomerName"),
                    PayTypeInitial = row.Field<string>("PayTypeInitial"),
                    StockId = row.Field<Guid>("StockID"),
                    StockSku = row.Field<string>("StockSKU"),
                    StockPcsperPack = row.Field<decimal>("StockPcsperPack"),
                    StockDescription = row.Field<string>("StockDescription"),
                    Qty = row.Field<decimal>("Qty"),
                    ActualWeight = row.Field<decimal>("ActualWeight"),
                    ReceivingTime = row.Field<Nullable<DateTime>>("ReceivingTime"),
                    EndTime = row.Field<Nullable<DateTime>>("EndTime")

                }).ToList();


            return Json(vwReceivingDetails, new System.Text.Json.JsonSerializerOptions());

        }

    }
}
