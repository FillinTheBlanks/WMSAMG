using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WMSAMG.Models.CSIS2017Models;
using WMSAMG.Models.CSISControlModels;

namespace WMSAMG.Controllers
{
    public class StoragingController : Controller
    {
        private readonly IConfiguration _configuration;

        public StoragingController(IConfiguration configuration)
        {
            _configuration = configuration;
        }


        // GET: Storaging
        public IActionResult Index()
        {
            DataTable dt = new DataTable();
            using (SqlConnection sqlConnection = new SqlConnection(_configuration.GetConnectionString("DataContextConnection")))
            {
                sqlConnection.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("spSelect_ActualInventory", sqlConnection);
                sqlDa.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sqlDa.SelectCommand.Parameters.AddWithValue("CompanyID", "35a953cd-49b0-4db4-b5ec-2aa23733a5e2");
                sqlDa.SelectCommand.Parameters.AddWithValue("LocationID", "aea95735-24df-40a2-9132-5cbff7595bb9");
                sqlDa.SelectCommand.Parameters.AddWithValue("CustomerID", "");
                sqlDa.Fill(dt);
            }
            ViewBag.datasource = dt;
            return View(dt);
        }

     

        // GET: Storaging/Edit/5
        public IActionResult AddorEdit(Guid? id)
        {
            string strid = id.ToString();
            TblStorageTimeFrame tblStorageTimeFrame = new TblStorageTimeFrame();
            if (!string.IsNullOrEmpty(strid))
            {
                tblStorageTimeFrame = FetchRecordByID(strid);
            }
                return View(tblStorageTimeFrame);
        }

        // POST: Storaging/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Route("Storaging/InsertTimeFrame")]
        //[ValidateAntiForgeryToken]
        public JsonResult InsertTimeFrame([FromBody] TblStorageTimeFrame tblStorageTimeFrame)
        {
            //if (id != tblStorageTimeFrame.StorageTimeFrameId)
            //{
            //{
            //    return NotFound();
            //}
            string message = string.Empty;
            if (ModelState.IsValid)
            { 
                using (SqlConnection sqlConnection = new SqlConnection(_configuration.GetConnectionString("DataContextConnection")))
                {
                    sqlConnection.Open();
                    SqlCommand sqlCmd = new SqlCommand("spUpdate_StorageLocationbyRefCode", sqlConnection);
                    sqlCmd.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("StorageTimeFrameID", tblStorageTimeFrame.StorageTimeFrameId);
                    sqlCmd.Parameters.AddWithValue("RefCode", tblStorageTimeFrame.RefCode);
                    sqlCmd.Parameters.AddWithValue("RRCode", tblStorageTimeFrame.ReferenceNo);
                    sqlCmd.Parameters.AddWithValue("Nature", tblStorageTimeFrame.Nature);
                    sqlCmd.Parameters.AddWithValue("CustomerID", tblStorageTimeFrame.CustomerId);
                    sqlCmd.Parameters.AddWithValue("PayTypeInitial", tblStorageTimeFrame.PayTypeInitial);
                    sqlCmd.Parameters.AddWithValue("StockID", tblStorageTimeFrame.StockId);
                    sqlCmd.Parameters.AddWithValue("StorageLocationID", tblStorageTimeFrame.StorageLocationId);
                    sqlCmd.Parameters.AddWithValue("StorageID", tblStorageTimeFrame.StorageId);
                    sqlCmd.Parameters.AddWithValue("StorageTypeID", tblStorageTimeFrame.StorageTypeId);
                    sqlCmd.Parameters.AddWithValue("DateTimeFrameFrom", tblStorageTimeFrame.DateTimeFrameFrom);
                    sqlCmd.Parameters.AddWithValue("LocationID", "aea95735-24df-40a2-9132-5cbff7595bb9");
                    sqlCmd.Parameters.AddWithValue("Remarks", "");
                    sqlCmd.Parameters.AddWithValue("ApprovedBy", Guid.Parse(this.User.FindFirstValue(ClaimTypes.NameIdentifier).Replace(" ", "")));
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

        // GET: Storaging/Delete/5
        public IActionResult Delete(Guid? id)
        {
          
            return View();
        }

        // POST: Storaging/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
          
            return RedirectToAction(nameof(Index));
        }

        [NonAction]
        public TblStorageTimeFrame FetchRecordByID(string id)
        {

            DataTable dt = new DataTable();
            TblStorageTimeFrame tblStorageTimeFrame = new TblStorageTimeFrame();

            //tblReceiving.Customers = PopulateCustomers();

            using (SqlConnection sqlConnection = new SqlConnection(_configuration.GetConnectionString("DataContextConnection")))
            {
                sqlConnection.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("spSelect_StorageTimeFrame", sqlConnection);
                sqlDa.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sqlDa.SelectCommand.Parameters.AddWithValue("RefCode", id);
                sqlDa.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    tblStorageTimeFrame.RefCode = (Guid)dt.Rows[0]["ReferenceCode"];
                    tblStorageTimeFrame.ReferenceNo = dt.Rows[0]["RRCode"].ToString().Trim();
                    tblStorageTimeFrame.CustomerId = dt.Rows[0]["CustomerID"].ToString();
                    tblStorageTimeFrame.CustomerName = dt.Rows[0]["CustomerName"].ToString();
                    //if(!string.IsNullOrEmpty(dt.Rows[0]["StorageLocationID"].ToString()))
                    //{
                    //    tblStorageTimeFrame.StorageLocationId = (Guid)dt.Rows[0]["StorageLocationID"];
                    //}
                    
                    //tblStorageTimeFrame.StorageId = (Guid)dt.Rows[0]["StorageID"];
                    tblStorageTimeFrame.StorageTypeId = dt.Rows[0]["StorageTypeID"].ToString();
                    tblStorageTimeFrame.StorageName = dt.Rows[0]["StorageName"].ToString();
                    tblStorageTimeFrame.Nature = dt.Rows[0]["Nature"].ToString();
                    tblStorageTimeFrame.PayTypeInitial = dt.Rows[0]["PayTypeInitial"].ToString();
                    //tblStorageTimeFrame.StorageLocationName.Find(a => a.Value == dt.Rows[0]["StorageLocationName"].ToString()).Selected = true;
                    tblStorageTimeFrame.DateTimeFrameFrom = GetNullable<DateTime>(dt.Rows[0]["DateTimeFrameFrom"]);
                    tblStorageTimeFrame.FixedRate = GetNullable<Decimal>(dt.Rows[0]["FixedRate"]);
                    tblStorageTimeFrame.HourlyRate = GetNullable<Decimal>(dt.Rows[0]["HourlyRate"]);
                }
            }

            return tblStorageTimeFrame;
        }

        public static T? GetNullable<T>(object obj) where T : struct
        {
            if (obj == DBNull.Value) return null;
            return (T?)obj;
        }

        public JsonResult GetStorageByLocationID()
        {
            
            DataTable dt = new DataTable();
            using (SqlConnection sqlConnection = new SqlConnection(_configuration.GetConnectionString("AuthContextConnection")))
            {
                sqlConnection.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("spSelect_StorageLocationbyLocation", sqlConnection);
                sqlDa.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sqlDa.SelectCommand.Parameters.AddWithValue("LocationID", "aea95735-24df-40a2-9132-5cbff7595bb9");
                sqlDa.Fill(dt);
            }
            List<VwStoragetoLocation> Stocks = dt.AsEnumerable().Select(row =>
                new VwStoragetoLocation
                {
                    StorageId = row.Field<Guid>("StorageID"),
                    StorageLocationId = row.Field<Guid>("StorageLocationID"),
                    StorageLocationName = row.Field<string>("StorageLocationName"),
                    StorageTypeId = row.Field<string>("StorageTypeID"),
                    StorageName = row.Field<string>("StorageName")
                }).ToList();

            //string JSONString = string.Empty;
            //JSONString = JsonConvert.SerializeObject(dt);

            return Json(Stocks, new System.Text.Json.JsonSerializerOptions());
        }

        public JsonResult GetStorageByStorageLocationID(string id)
        {
            //if (string.IsNullOrEmpty(slid))
            //{
            //    slid = "";
            //}
            DataTable dt = new DataTable();
            using (SqlConnection sqlConnection = new SqlConnection(_configuration.GetConnectionString("AuthContextConnection")))
            {
                sqlConnection.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("spSelect_StorageLocationbyFilter", sqlConnection);
                sqlDa.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sqlDa.SelectCommand.Parameters.AddWithValue("TextFilter", id);
                sqlDa.SelectCommand.Parameters.AddWithValue("ColumnName", "StorageLocationID");
                sqlDa.Fill(dt);
            }
            List<VwStoragetoLocation> StorageLocations = dt.AsEnumerable().Select(row =>
                new VwStoragetoLocation
                {
                    StorageId = row.Field<Guid>("StorageID"),
                    StorageLocationId = row.Field<Guid>("StorageLocationID"),
                    StorageLocationName = row.Field<string>("StorageLocationName"),
                    StorageTypeId = row.Field<string>("StorageTypeID"),
                    StorageName = row.Field<string>("StorageName"),
                    FixedRate = row.Field<Decimal>("FixedRate"),
                    HourlyRate = row.Field<Decimal>("HourlyRate")
                }).ToList();

            //string JSONString = string.Empty;
            //JSONString = JsonConvert.SerializeObject(dt);

            return Json(StorageLocations, new System.Text.Json.JsonSerializerOptions());
        }

        public JsonResult GetActualInventorybyRRCode(string id)
        {
            
            DataTable dt = new DataTable();
            using (SqlConnection sqlConnection = new SqlConnection(_configuration.GetConnectionString("DataContextConnection")))
            {
                sqlConnection.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("spSelect_ActualInventory", sqlConnection);
                sqlDa.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sqlDa.SelectCommand.Parameters.AddWithValue("CompanyID", "35a953cd-49b0-4db4-b5ec-2aa23733a5e2");
                sqlDa.SelectCommand.Parameters.AddWithValue("LocationID", "aea95735-24df-40a2-9132-5cbff7595bb9");
                sqlDa.SelectCommand.Parameters.AddWithValue("CustomerID", "");
                sqlDa.Fill(dt);
            }
            List<VwActualInventory> actualInventories = dt.AsEnumerable().Select(row =>
                new VwActualInventory
                {
                    Rrcode = row.Field<string>("RRCode"),
                    ReferenceCode = row.Field<Guid>("ReferenceCode"),
                    StockId = row.Field<Guid>("StockID"),
                    StockSku = row.Field<string>("StockSKU"),
                    StockDescription = row.Field<string>("StockDescription"),
                    Qty = row.Field<Decimal>("Qty"),
                    ActualWeight = row.Field<Decimal>("ActualWeight"),
                    //TransactionDate = row.Field<DateTime>("TransactionDate"),
                    StorageName = row.Field<string>("StorageName"),
                    StorageLocationName = row.Field<string>("StorageLocationName")
                }).Where(c => c.Rrcode == id).ToList();

            return Json(actualInventories, new System.Text.Json.JsonSerializerOptions());
        }
    }
}
