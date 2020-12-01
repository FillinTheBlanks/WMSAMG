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
            List<object> DataRange = new List<object>();
            DataRange.Add(new { Text = "1,000 Rows 11 Columns", Value = "1000" });
            DataRange.Add(new { Text = "10,000 Rows 11 Columns", Value = "10000" });
            DataRange.Add(new { Text = "1,00,000 Rows 11 Columns", Value = "100000" });
            ViewBag.Data = DataRange;

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
            string strid = id.ToString();
            TblReceivingDetail tblReceiving = new TblReceivingDetail();

            tblReceiving.Customers = PopulateCustomers();



            if (strid != string.Empty)
            {
                tblReceiving = FetchStockByID(id);
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
               
                return RedirectToAction(nameof(Index));
            }
            return View(tblReceivingDetail);
        }

        // GET: Receiving/Edit/5
        public IActionResult AddoEdit(Guid? id)
        {
           
            return View();
        }

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
        public TblReceivingDetail FetchStockByID(Guid? id)
        {

            DataTable dt = new DataTable();
            TblReceivingDetail tblReceiving = new TblReceivingDetail();

            tblReceiving.Customers = PopulateCustomers();

            using (SqlConnection sqlConnection = new SqlConnection(_configuration.GetConnectionString("DataContextConnection")))
            {
                sqlConnection.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("spSelect_ReceivingbyFilter", sqlConnection);
                sqlDa.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sqlDa.SelectCommand.Parameters.AddWithValue("TextFilter", id);
                sqlDa.SelectCommand.Parameters.AddWithValue("ColumnName", "ReferenceCode");
                sqlDa.Fill(dt);
                if (dt.Rows.Count == 1)
                {
                    tblReceiving.Rrcode = dt.Rows[0]["RRCode"].ToString();
                    
                    tblReceiving.Stocks.Find(a => a.Value == dt.Rows[0]["StockSku"].ToString()).Selected = true;
                    //tblReceiving.StockDescription = dt.Rows[0]["StockDescription"].ToString();
                    //tblReceiving.StockPcsperPack = Convert.ToDecimal(dt.Rows[0]["StockPcsperPack"].ToString());
                    //tblReceiving.StockPackperCase = Convert.ToDecimal(dt.Rows[0]["StockPackperCase"].ToString());
                    //tblReceiving.StockWeightinKilosperPack = Convert.ToDecimal(dt.Rows[0]["StockWeightinKilosperPack"].ToString());
                    //tblReceiving.StockWeightinKilosperCase = Convert.ToDecimal(dt.Rows[0]["StockWeightinKilosperCase"].ToString());
                    //tblReceiving.ShelfLifeinDays = Convert.ToInt32(dt.Rows[0]["ShelfLifeinDays"].ToString());
                    //tblReceiving.CompanyId = (Guid)dt.Rows[0]["CompanyID"];
                    tblReceiving.Customers.Find(a => a.Value == dt.Rows[0]["CustomerID"].ToString()).Selected = true;
                    //tblReceiving.Companies.Find(a => a.Value == dt.Rows[0]["CompanyID"].ToString()).Selected = true;
                    //tblReceiving.StockStatus = Convert.ToBoolean(dt.Rows[0]["StockStatus"].ToString());
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
    }
}
