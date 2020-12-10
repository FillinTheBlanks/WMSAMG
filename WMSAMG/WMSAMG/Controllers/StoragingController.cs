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
        [ValidateAntiForgeryToken]
        public IActionResult AddorEdit(Guid id, [Bind("StorageTimeFrameId,RefCode,ReferenceNo,CustomerId,PayTypeInitial,Nature,StorageLocationId,StorageId,StorageTypeId,DateTimeFrameFrom,DateTimeFrameTo,FixedRate,HourlyRate")] TblStorageTimeFrame tblStorageTimeFrame)
        {
            if (id != tblStorageTimeFrame.StorageTimeFrameId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(tblStorageTimeFrame);
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
                    tblStorageTimeFrame.ReferenceNo = dt.Rows[0]["RRCode"].ToString();
                    tblStorageTimeFrame.CustomerId = dt.Rows[0]["CustomerID"].ToString();
                    tblStorageTimeFrame.CustomerName = dt.Rows[0]["CustomerName"].ToString();
                    tblStorageTimeFrame.StorageLocationId = (Guid)dt.Rows[0]["StorageLocationID"];
                    tblStorageTimeFrame.StorageId = (Guid)dt.Rows[0]["StorageID"];
                    tblStorageTimeFrame.StorageTypeId = dt.Rows[0]["StorageTypeID"].ToString();
                    tblStorageTimeFrame.StorageName = dt.Rows[0]["StorageName"].ToString();
                    //tblStorageTimeFrame.StorageLocationName.Find(a => a.Value == dt.Rows[0]["StorageLocationName"].ToString()).Selected = true;
                    tblStorageTimeFrame.DateTimeFrameFrom = (DateTime)dt.Rows[0]["DateTimeFrameFrom"];
                    tblStorageTimeFrame.FixedRate = (Decimal)dt.Rows[0]["FixedRate"];
                    tblStorageTimeFrame.HourlyRate = (Decimal)dt.Rows[0]["HourlyRate"];
                }
            }

            return tblStorageTimeFrame;
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

    }
}
