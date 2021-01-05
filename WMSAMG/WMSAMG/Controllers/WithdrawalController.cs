using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WMSAMG.Models.CSIS2017Models;
using WMSAMG.Models.CSISControlModels;

namespace WMSAMG.Controllers
{
    [Authorize]
    public class WithdrawalController : Controller
    {
        private readonly IConfiguration _configuration;

        public WithdrawalController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        
        // GET: Withdrawal
        public IActionResult Index()
        {
            DataTable dt = new DataTable();
            using (SqlConnection sqlConnection = new SqlConnection(_configuration.GetConnectionString("DataContextConnection")))
            {
                sqlConnection.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("spSelect_StockWithdrawalDetailbyFilter", sqlConnection);
                sqlDa.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sqlDa.SelectCommand.Parameters.AddWithValue("TextFilter", "aea95735-24df-40a2-9132-5cbff7595bb9");
                sqlDa.SelectCommand.Parameters.AddWithValue("ColumnName", "LocationID");
                sqlDa.Fill(dt);
            }
            ViewBag.datasource = dt;
            return View(dt);
        }

      

        // GET: Withdrawal/AddorEdit/5
        public IActionResult AddorEdit(Guid? id)
        {
   
            string strid = id.ToString();
            TblStockWithdrawalDetail tblStockWithdrawal = new TblStockWithdrawalDetail();
            if (!string.IsNullOrEmpty(strid))
            {
                tblStockWithdrawal = FetchRecordByID(strid);
            }
            else
            {
                tblStockWithdrawal.Nature = "SW";
                tblStockWithdrawal.LocationId = Guid.Parse("aea95735-24df-40a2-9132-5cbff7595bb9");
                tblStockWithdrawal.Swcode = "GSC" + tblStockWithdrawal.Nature + GetReferenceNo(tblStockWithdrawal.Nature, tblStockWithdrawal.LocationId);
                tblStockWithdrawal.ApprovedBy = Guid.Parse(this.User.FindFirstValue(ClaimTypes.NameIdentifier).Replace(" ", ""));
                tblStockWithdrawal.Approver = Guid.Parse(this.User.FindFirstValue(ClaimTypes.NameIdentifier).Replace(" ", ""));
                tblStockWithdrawal.Requestor = Guid.Parse(this.User.FindFirstValue(ClaimTypes.NameIdentifier).Replace(" ", ""));
                tblStockWithdrawal.EmployeeId = Guid.Parse(this.User.FindFirstValue(ClaimTypes.NameIdentifier).Replace(" ", ""));
                
            }
            return View(tblStockWithdrawal);
        }

        // POST: Withdrawal/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        //[ValidateAntiForgeryToken]
        [Route("Withdrawal/SaveRecord")]
        //[ValidateAntiForgeryToken]
        public JsonResult SaveRecord([FromBody] TblStockWithdrawalDetail tblStockWithdrawal)
        {
            //if (id != tblStorageTimeFrame.StorageTimeFrameId)
            //{
            //{
            //    return NotFound();
            //}
            string message = string.Empty;

            //if (!ModelState.IsValid) { 
            //    message = ModelState.Values.SelectMany(v => v.Errors).Select(error => error.ErrorMessage).ToString();

            //}
            if (ModelState.IsValid)
            {
                using (SqlConnection sqlConnection = new SqlConnection(_configuration.GetConnectionString("DataContextConnection")))
                {
                    sqlConnection.Open();
                    SqlCommand sqlCmd = new SqlCommand("spInsert_StockWithdrawalDetail", sqlConnection);
                    sqlCmd.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("ReferenceCode", tblStockWithdrawal.ReferenceCode);
                    sqlCmd.Parameters.AddWithValue("SWCode", tblStockWithdrawal.Swcode);
                    sqlCmd.Parameters.AddWithValue("RRCode", tblStockWithdrawal.Rrcode);
                    sqlCmd.Parameters.AddWithValue("Nature", tblStockWithdrawal.Nature);
                    sqlCmd.Parameters.AddWithValue("CustomerID", tblStockWithdrawal.CustomerId);
                    sqlCmd.Parameters.AddWithValue("PayTypeInitial", tblStockWithdrawal.PayTypeInitial);
                    sqlCmd.Parameters.AddWithValue("StockID", tblStockWithdrawal.StockId);
                    sqlCmd.Parameters.AddWithValue("StockSKU", tblStockWithdrawal.StockSku);
                    sqlCmd.Parameters.AddWithValue("StockPcsperPack", tblStockWithdrawal.StockPcsperPack);
                    sqlCmd.Parameters.AddWithValue("StockGroupID", tblStockWithdrawal.StockGroupId);
                    sqlCmd.Parameters.AddWithValue("Qty", tblStockWithdrawal.Qty);
                    sqlCmd.Parameters.AddWithValue("ActualWeight", tblStockWithdrawal.ActualWeight);
                    sqlCmd.Parameters.AddWithValue("UOM", tblStockWithdrawal.Uom);
                    sqlCmd.Parameters.AddWithValue("PalletNo", tblStockWithdrawal.PalletNo);
                    sqlCmd.Parameters.AddWithValue("CompanyID", tblStockWithdrawal.CompanyId);
                    sqlCmd.Parameters.AddWithValue("ProductionDate", tblStockWithdrawal.ProductionDate);
                    sqlCmd.Parameters.AddWithValue("StorageLocationID", tblStockWithdrawal.StorageLocationId);
                    sqlCmd.Parameters.AddWithValue("StorageID", tblStockWithdrawal.StorageId);
                    sqlCmd.Parameters.AddWithValue("StorageTypeID", tblStockWithdrawal.StorageTypeId);
                    sqlCmd.Parameters.AddWithValue("TransactionDate", tblStockWithdrawal.TransactionDate);
                    sqlCmd.Parameters.AddWithValue("StartTime", tblStockWithdrawal.StartTime);
                    sqlCmd.Parameters.AddWithValue("EndTime", tblStockWithdrawal.EndTime);
                    sqlCmd.Parameters.AddWithValue("LocationID", "aea95735-24df-40a2-9132-5cbff7595bb9");
                    sqlCmd.Parameters.AddWithValue("Source", tblStockWithdrawal.Source);
                    sqlCmd.Parameters.AddWithValue("Remarks", tblStockWithdrawal.Remarks);
                    sqlCmd.Parameters.AddWithValue("ApprovedBy", Guid.Parse(this.User.FindFirstValue(ClaimTypes.NameIdentifier).Replace(" ", "")));
                    sqlCmd.Parameters.AddWithValue("Requestor", Guid.Parse(this.User.FindFirstValue(ClaimTypes.NameIdentifier).Replace(" ", "")));
                    sqlCmd.Parameters.AddWithValue("Approver", Guid.Parse(this.User.FindFirstValue(ClaimTypes.NameIdentifier).Replace(" ", "")));
                    sqlCmd.Parameters.AddWithValue("EmployeeID", Guid.Parse(this.User.FindFirstValue(ClaimTypes.NameIdentifier).Replace(" ", "")));
                    sqlCmd.Parameters.AddWithValue("IsSaved", 1);
                    sqlCmd.ExecuteNonQuery();
                    message = " Saved Successfully!";
                }

                //return RedirectToAction(nameof(Index));
            }
            else
            {
                message = "Error on Model!";
            }
           
            //return View(tblStorageTimeFrame);
            return Json(message, new System.Text.Json.JsonSerializerOptions());
        }

        // GET: Withdrawal/Delete/5
        public IActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

           

            return View();
        }

        // POST: Withdrawal/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
           
            return RedirectToAction(nameof(Index));
        }

        [NonAction]
        public TblStockWithdrawalDetail FetchRecordByID(string id)
        {

            DataTable dt = new DataTable();
            TblStockWithdrawalDetail tblStockWithdrawal = new TblStockWithdrawalDetail();

            //tblReceiving.Customers = PopulateCustomers();

            using (SqlConnection sqlConnection = new SqlConnection(_configuration.GetConnectionString("DataContextConnection")))
            {
                sqlConnection.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("spSelect_StockWithdrawalDetailbyFilter", sqlConnection);
                sqlDa.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sqlDa.SelectCommand.Parameters.AddWithValue("TextFilter", id);
                sqlDa.SelectCommand.Parameters.AddWithValue("ColumnName", "ReferenceCode");
                sqlDa.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    tblStockWithdrawal.ReferenceCode = (Guid)dt.Rows[0]["ReferenceCode"];
                    tblStockWithdrawal.Swcode = dt.Rows[0]["SWCode"].ToString().Trim();
                    tblStockWithdrawal.CustomerId = dt.Rows[0]["CustomerID"].ToString();
                    tblStockWithdrawal.CustomerName = dt.Rows[0]["CustomerName"].ToString();
                }
            }

            return tblStockWithdrawal;
        }

        [NonAction]
        public string GetReferenceNo(string nature, Guid? locationid)
        {
            string SwCode = String.Empty;
            using (SqlConnection sqlConnection = new SqlConnection(_configuration.GetConnectionString("DataContextConnection")))
            {
                sqlConnection.Open();
                SqlCommand sqlCmd = new SqlCommand("spSelect_AvailableSWCode", sqlConnection);
                sqlCmd.Parameters.AddWithValue("LocationID", locationid);
                sqlCmd.Parameters.AddWithValue("Nature", nature);
                sqlCmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader sqlDr = sqlCmd.ExecuteReader();

                while (sqlDr.Read())
                {
                    SwCode = sqlDr[2].ToString();
                }
            }
            return SwCode;
        }

        public JsonResult GetActualInventorybyCustomerID(string id)
        {

            DataTable dt = new DataTable();
            using (SqlConnection sqlConnection = new SqlConnection(_configuration.GetConnectionString("DataContextConnection")))
            {
                sqlConnection.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("spSelect_ActualInventory", sqlConnection);
                sqlDa.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sqlDa.SelectCommand.Parameters.AddWithValue("CompanyID", "35a953cd-49b0-4db4-b5ec-2aa23733a5e2");
                sqlDa.SelectCommand.Parameters.AddWithValue("LocationID", "aea95735-24df-40a2-9132-5cbff7595bb9");
                sqlDa.SelectCommand.Parameters.AddWithValue("CustomerID", id);
                sqlDa.Fill(dt);
            }
            List<VwActualInventory> actualInventories = dt.AsEnumerable().Select(row =>
                new VwActualInventory
                {
                    Rrcode = row.Field<string>("RRCode"),
                    ReferenceCode = row.Field<Guid>("ReferenceCode"),
                    PayTypeInitial = row.Field<string>("PayTypeInitial"),
                    StockId = row.Field<Guid>("StockID"),
                    StockSku = row.Field<string>("StockSKU"),
                    StockPcsperPack = row.Field<Decimal>("StockPcsperPack"),
                    StockGroupId = row.Field<Guid>("StockGroupID"),
                    Uom = row.Field<string>("UOM"),
                    PalletNo = row.Field<string>("PalletNo"),
                    CompanyId = row.Field<Guid>("CompanyID"),
                    StockDescription = row.Field<string>("StockDescription"),
                    Qty = row.Field<Decimal>("Qty"),
                    ActualWeight = row.Field<Decimal>("ActualWeight"),
                    TransactionDate = row.Field<DateTime>("TransactionDate"),
                    StorageName = row.Field<string>("StorageName"),
                    Source = row.Field<string>("Nature"),
                    StorageLocationName = row.Field<string>("StorageLocationName"),
                    StorageLocationId = row.Field<Nullable<Guid>>("StorageLocationID"),
                    StorageId = row.Field<Nullable<Guid>>("StorageID"),
                    StorageTypeId = row.Field<string>("StorageTypeID")
                }).Where(c => c.StorageLocationId != null).OrderByDescending(c => c.TransactionDate).ToList();

            return Json(actualInventories, new System.Text.Json.JsonSerializerOptions());
        }

        public static T? GetNullable<T>(object obj) where T : struct
        {
            if (obj == DBNull.Value) return null;
            return (T?)obj;
        }

        public JsonResult GetCustomers()
        {
            //if (string.IsNullOrEmpty(slid))
            //{
            //    slid = "";
            //}
            DataTable dt = new DataTable();
            using (SqlConnection sqlConnection = new SqlConnection(_configuration.GetConnectionString("AuthContextConnection")))
            {
                sqlConnection.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("spSelect_CustomerbyFilter", sqlConnection);
                sqlDa.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sqlDa.SelectCommand.Parameters.AddWithValue("TextFilter", "aea95735-24df-40a2-9132-5cbff7595bb9");
                sqlDa.SelectCommand.Parameters.AddWithValue("ColumnName", "LocationID");
                sqlDa.Fill(dt);
            }
            List<VwCustomertoCompanyandLocation> vwCustomers = dt.AsEnumerable().Select(row =>
                new VwCustomertoCompanyandLocation
                {
                    CustomerId = row.Field<string>("CustomerId"),
                    CustomerName = row.Field<string>("CustomerName"),
                    CustomerStatus = row.Field<bool>("CustomerStatus")
                }).Where(c => c.CustomerStatus == true).ToList();

            
            return Json(vwCustomers, new System.Text.Json.JsonSerializerOptions());
        }
    }
}
