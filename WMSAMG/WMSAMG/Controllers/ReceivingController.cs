using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WMSAMG.Models.CSIS2017Models;

namespace WMSAMG.Controllers
{
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
            DataTable dt = new DataTable();
            using (SqlConnection sqlConnection = new SqlConnection(_configuration.GetConnectionString("DataContextConnection")))
            {
                sqlConnection.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("spSelect_ReceivingDetailbyFilter", sqlConnection);
                sqlDa.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sqlDa.SelectCommand.Parameters.AddWithValue("TextFilter", "");
                sqlDa.SelectCommand.Parameters.AddWithValue("ColumnName", "RRCode");
                sqlDa.Fill(dt);
            }
            return View(dt);
            
        }

        // GET: Receiving/Details/5
        public IActionResult AddorEdit(Guid? id)
        {
            //List<object> DataRange = new List<object>();
            //DataRange.Add(new { Text = "1,000 Rows", Value = "1000" });
            //DataRange.Add(new { Text = "10,000 Rows", Value = "10000" });
            //DataRange.Add(new { Text = "100,000 Rows", Value = "100000" });
            //ViewBag.Data = DataRange;


            String strid = id.ToString();

            TblReceivingDetail tblReceiving = new TblReceivingDetail();
            
            //tblReceiving.Customers = PopulateCustomers();
            
            if (strid != string.Empty)
            {
                tblReceiving = FetchStockByID(strid);
            } else
            {
                tblReceiving.Nature = "RR";
                tblReceiving.LocationId = Guid.Parse("aea95735-24df-40a2-9132-5cbff7595bb9");
                tblReceiving.Rrcode = "GSC" + tblReceiving.Nature + GetReferenceNo(tblReceiving.Nature, tblReceiving.LocationId);
            }

            return View(tblReceiving);
        }

        // GET: Receiving/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Receiving/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddorEdit([Bind("ReferenceCode,Rrcode,CarrierReferenceCode,CustomerId,PayTypeInitial,StockId,StockSku,StockGroupId,StockPcsperPack,StockPackperCase,Qty,ActualWeight,Uom,ReceivingTime,EndTime,StockWeightinKilosperPack,StockWeightinKilosperCase,PalletNo,CompanyId,StorageLocationId,StorageId,StorageTypeId,TransactionDate,LocationId,Nature,Source,Remarks,ApprovedBy,EmployeeId,EmployeeDate,IsSaved")] TblReceivingDetail tblReceivingDetail)
        {
            if (ModelState.IsValid)
            {
                using (SqlConnection sqlConnection = new SqlConnection(_configuration.GetConnectionString("AuthContextConnection")))
                {
                    sqlConnection.Open();
                    SqlCommand sqlCmd = new SqlCommand("spInsert_Stocks", sqlConnection);
                    sqlCmd.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("ReferenceCode", tblReceivingDetail.ReferenceCode);
                    sqlCmd.Parameters.AddWithValue("RRCode", tblReceivingDetail.Rrcode);
                    sqlCmd.Parameters.AddWithValue("CarrierReferenceCode", tblReceivingDetail.CarrierReferenceCode);
                    sqlCmd.Parameters.AddWithValue("CustomerID", tblReceivingDetail.CustomerId);
                    sqlCmd.Parameters.AddWithValue("PayTypeInitial", tblReceivingDetail.PayTypeInitial);
                    sqlCmd.Parameters.AddWithValue("StockID", tblReceivingDetail.StockId);
                    sqlCmd.Parameters.AddWithValue("StockSKU", tblReceivingDetail.StockSku);
                    sqlCmd.Parameters.AddWithValue("StockGroupID", tblReceivingDetail.StockGroupId);
                    sqlCmd.Parameters.AddWithValue("StockPcsperPack", tblReceivingDetail.StockPcsperPack);
                    sqlCmd.Parameters.AddWithValue("CarrierReferenceCode", tblReceivingDetail.CarrierReferenceCode);
                    sqlCmd.Parameters.AddWithValue("CarrierReferenceCode", tblReceivingDetail.CarrierReferenceCode);
                    sqlCmd.Parameters.AddWithValue("CarrierReferenceCode", tblReceivingDetail.CarrierReferenceCode);
                    sqlCmd.Parameters.AddWithValue("CarrierReferenceCode", tblReceivingDetail.CarrierReferenceCode);
                    sqlCmd.Parameters.AddWithValue("CarrierReferenceCode", tblReceivingDetail.CarrierReferenceCode);
                    sqlCmd.Parameters.AddWithValue("CarrierReferenceCode", tblReceivingDetail.CarrierReferenceCode);
                    sqlCmd.Parameters.AddWithValue("CarrierReferenceCode", tblReceivingDetail.CarrierReferenceCode);
                    sqlCmd.Parameters.AddWithValue("CarrierReferenceCode", tblReceivingDetail.CarrierReferenceCode);
                    sqlCmd.Parameters.AddWithValue("CarrierReferenceCode", tblReceivingDetail.CarrierReferenceCode);
                    sqlCmd.Parameters.AddWithValue("CarrierReferenceCode", tblReceivingDetail.CarrierReferenceCode);
                    sqlCmd.Parameters.AddWithValue("CarrierReferenceCode", tblReceivingDetail.CarrierReferenceCode);
                    sqlCmd.Parameters.AddWithValue("CarrierReferenceCode", tblReceivingDetail.CarrierReferenceCode);
                    sqlCmd.Parameters.AddWithValue("CarrierReferenceCode", tblReceivingDetail.CarrierReferenceCode);
                    sqlCmd.Parameters.AddWithValue("CarrierReferenceCode", tblReceivingDetail.CarrierReferenceCode);
                    sqlCmd.Parameters.AddWithValue("CarrierReferenceCode", tblReceivingDetail.CarrierReferenceCode);

                }
                    return RedirectToAction(nameof(Index));
            }
            return View(tblReceivingDetail);
        }

        // GET: Receiving/Edit/5
        

        // POST: Receiving/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddorEdit(Guid id, [Bind("ReferenceCode,Rrcode,CarrierReferenceCode,CustomerId,PayTypeInitial,StockId,StockSku,StockGroupId,StockPcsperPack,StockPackperCase,Qty,ActualWeight,Uom,ReceivingTime,EndTime,StockWeightinKilosperPack,StockWeightinKilosperCase,PalletNo,CompanyId,StorageLocationId,StorageId,StorageTypeId,TransactionDate,LocationId,Nature,Source,Remarks,ApprovedBy,EmployeeId,EmployeeDate,IsSaved")] TblReceivingDetail tblReceivingDetail)
        {
            if (id != tblReceivingDetail.ReferenceCode)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                
                return RedirectToAction(nameof(Index));
            }
            return View();
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
        public TblReceivingDetail FetchStockByID(string id)
        {

            DataTable dt = new DataTable();
            TblReceivingDetail tblReceiving = new TblReceivingDetail();

            //tblReceiving.Customers = PopulateCustomers();

            using (SqlConnection sqlConnection = new SqlConnection(_configuration.GetConnectionString("DataContextConnection")))
            {
                sqlConnection.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("spSelect_ReceivingDetailbyFilter", sqlConnection);
                sqlDa.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sqlDa.SelectCommand.Parameters.AddWithValue("TextFilter", id);
                sqlDa.SelectCommand.Parameters.AddWithValue("ColumnName", "ReferenceCode");
                sqlDa.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    tblReceiving.ReferenceCode = (Guid)dt.Rows[0]["ReferenceCode"];
                    tblReceiving.Rrcode = dt.Rows[0]["RRCode"].ToString();
                    tblReceiving.CustomerId = dt.Rows[0]["CustomerID"].ToString();
                    tblReceiving.CustomerName = dt.Rows[0]["CustomerName"].ToString();
                    tblReceiving.PayTypeInitial = dt.Rows[0]["PayTypeInitial"].ToString();
                    tblReceiving.StockId = (Guid)dt.Rows[0]["StockID"];
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
                    if (!String.IsNullOrEmpty(dt.Rows[0]["EndTime"].ToString()))
                    {
                        tblReceiving.EndTime = Convert.ToDateTime(dt.Rows[0]["EndTime"]);
                    }
                    
                    tblReceiving.Remarks = dt.Rows[0]["Remarks"].ToString();
                    
                }
            }
           
            return tblReceiving;
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

        public JsonResult GetRecordsbyRRNo(string? Id)
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
                    Rrcode = row.Field<string>("RRCode"),
                    CustomerId = row.Field<string>("CustomerID"),
                    CustomerName = row.Field<string>("CustomerName"),
                    PayTypeInitial = row.Field<string>("PayTypeInitial"),
                    StockId = row.Field<Guid>("StockID"),
                    StockSku = row.Field<string>("StockSKU"),
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
