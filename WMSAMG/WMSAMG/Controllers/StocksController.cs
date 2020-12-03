using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WMSAMG.Models.CSISControlModels;
using Newtonsoft.Json;

namespace WMSAMG.Controllers
{
    public class StocksController : Controller
    {
        private readonly IConfiguration _configuration;

        public StocksController(IConfiguration configuration)
        {
            this._configuration = configuration;
            
        }

        // GET: Stocks
        public IActionResult Index()
        {
            
            DataTable dt = new DataTable();
            using (SqlConnection sqlConnection = new SqlConnection(_configuration.GetConnectionString("AuthContextConnection")))
            {
                sqlConnection.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("spSelect_StocksbyFilter", sqlConnection);
                sqlDa.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sqlDa.SelectCommand.Parameters.AddWithValue("TextFilter", "");
                sqlDa.SelectCommand.Parameters.AddWithValue("ColumnName", "StockSKU");
                sqlDa.Fill(dt);
            }
            return View(dt);
        }

        public JsonResult GetStockBySKU(string Id)
        {
            
            DataTable dt = new DataTable();
            using (SqlConnection sqlConnection = new SqlConnection(_configuration.GetConnectionString("AuthContextConnection")))
            {
                sqlConnection.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("spSelect_StocksbyFilter", sqlConnection);
                sqlDa.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sqlDa.SelectCommand.Parameters.AddWithValue("TextFilter", Id);
                sqlDa.SelectCommand.Parameters.AddWithValue("ColumnName", "StockSKU");
                sqlDa.Fill(dt);
            }
            List<VwStocktoStockGrouptoCustomerandCompany> Stocks = dt.AsEnumerable().Select(row =>
                new VwStocktoStockGrouptoCustomerandCompany
                {
                    StockId = row.Field<Guid>("StockID"),
                    StockGroupId = row.Field<Guid>("StockGroupID"),
                    StockSku = row.Field<string>("StockSKU"),
                    StockDescription = row.Field<string>("StockDescription"),
                    CustomerId = row.Field<string>("CustomerID"),
                    CustomerName = row.Field<string>("CustomerName"),
                    CompanyId = row.Field<Guid>("CompanyId"),
                    CompanyName = row.Field<string>("CompanyName"),
                    LocationId = row.Field<Guid>("LocationId"),
                    LocationInitial = row.Field<string>("LocationInitial"),
                    PayTypeInitial = row.Field<string>("PayTypeInitial")
                }).ToList();
            //string JSONString = string.Empty;
            //JSONString = JsonConvert.SerializeObject(dt);
            
            return Json(Stocks, new System.Text.Json.JsonSerializerOptions());
            
        }


        // GET: Stocks/AddorEdit/Guid
        public IActionResult AddorEdit(Guid? id)
        {
            string strid = id.ToString();
            TblStock tblStock = new TblStock();

            tblStock.Companies = PopulateCompany();
            tblStock.Customers = PopulateCustomer();
            tblStock.StockGroup = PopulateStockGroup();

            if (strid != string.Empty)
            {
                tblStock = FetchStockByID(id);
            }
           
            return View(tblStock);
        }

        // POST: Stocks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddorEdit(Guid id, [Bind("StockId,StockSku,StockDescription,StockGroupId,StockPcsperPack,StockPackperCase,StockWeightinKilosperPack,StockWeightinKilosperCase,ShelfLifeinDays,CustomerId,CompanyId,StockStatus")] TblStock tblStock)
        {
            
            if (ModelState.IsValid)
            {
                using (SqlConnection sqlConnection = new SqlConnection(_configuration.GetConnectionString("AuthContextConnection")))
                {
                    sqlConnection.Open();
                    SqlCommand sqlCmd = new SqlCommand("spInsert_Stocks", sqlConnection);
                    sqlCmd.CommandType = System.Data.CommandType.StoredProcedure;
                    sqlCmd.Parameters.AddWithValue("StockID", tblStock.StockId);
                    sqlCmd.Parameters.AddWithValue("StockSKU", tblStock.StockSku);
                    sqlCmd.Parameters.AddWithValue("StockDescription", tblStock.StockDescription); 
                    sqlCmd.Parameters.AddWithValue("StockPackperCase", tblStock.StockPackperCase); 
                    sqlCmd.Parameters.AddWithValue("StockPcsperPack", tblStock.StockPcsperPack);
                    sqlCmd.Parameters.AddWithValue("StockWeightinKilosperCase", tblStock.StockWeightinKilosperCase);
                    sqlCmd.Parameters.AddWithValue("StockWeightinKilosperPack", tblStock.StockWeightinKilosperPack);
                    sqlCmd.Parameters.AddWithValue("ShelfLifeinDays", tblStock.ShelfLifeinDays);
                    sqlCmd.Parameters.AddWithValue("StockStatus", tblStock.StockStatus);
                    sqlCmd.Parameters.AddWithValue("StockGroupID", tblStock.StockGroupId);
                    sqlCmd.Parameters.AddWithValue("CustomerID", tblStock.CustomerId);
                    sqlCmd.Parameters.AddWithValue("CompanyID", tblStock.CompanyId);
                    sqlCmd.ExecuteNonQuery();
                }
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        // GET: Stocks/Delete/5
        public IActionResult Delete(Guid? id)
        {
            TblStock tblStock = new TblStock();
            string strid = id.ToString();
            if (strid != string.Empty)
            {
                tblStock = FetchStockByID(id);
            }
            return View(tblStock);
        }

        // POST: Stocks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
             
            return RedirectToAction(nameof(Index));
        }

        [NonAction]
        public TblStock FetchStockByID(Guid? id)
        {
            
            DataTable dt = new DataTable();
            TblStock tblStock = new TblStock();

            tblStock.Companies = PopulateCompany();
            tblStock.Customers = PopulateCustomer();
            tblStock.StockGroup = PopulateStockGroup();

            using (SqlConnection sqlConnection = new SqlConnection(_configuration.GetConnectionString("AuthContextConnection")))
            {
                sqlConnection.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("spSelect_StocksbyFilter", sqlConnection);
                sqlDa.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sqlDa.SelectCommand.Parameters.AddWithValue("TextFilter", id);
                sqlDa.SelectCommand.Parameters.AddWithValue("ColumnName", "StockID");
                sqlDa.Fill(dt);
                if(dt.Rows.Count == 1)
                {
                    tblStock.StockId = (Guid)dt.Rows[0]["StockID"];
                    tblStock.StockSku = dt.Rows[0]["StockSKU"].ToString();
                    //tblStock.StockGroupId = (Guid)dt.Rows[0]["StockGroupID"];
                    tblStock.StockGroup.Find(a => a.Value == dt.Rows[0]["StockGroupID"].ToString()).Selected = true;
                    tblStock.StockDescription = dt.Rows[0]["StockDescription"].ToString();
                    tblStock.StockPcsperPack = Convert.ToDecimal(dt.Rows[0]["StockPcsperPack"].ToString());
                    tblStock.StockPackperCase = Convert.ToDecimal(dt.Rows[0]["StockPackperCase"].ToString());
                    tblStock.StockWeightinKilosperPack = Convert.ToDecimal(dt.Rows[0]["StockWeightinKilosperPack"].ToString());
                    tblStock.StockWeightinKilosperCase = Convert.ToDecimal(dt.Rows[0]["StockWeightinKilosperCase"].ToString());
                    tblStock.ShelfLifeinDays = Convert.ToInt32(dt.Rows[0]["ShelfLifeinDays"].ToString());
                    //tblStock.CustomerId = dt.Rows[0]["CustomerID"].ToString();
                    tblStock.CompanyId = (Guid)dt.Rows[0]["CompanyID"];
                    tblStock.Customers.Find(a => a.Value == dt.Rows[0]["CustomerID"].ToString()).Selected = true;
                    tblStock.Companies.Find(a => a.Value == dt.Rows[0]["CompanyID"].ToString()).Selected = true;
                    tblStock.StockStatus = Convert.ToBoolean(dt.Rows[0]["StockStatus"].ToString());
                }
            }
            return tblStock;
        }


        public List<SelectListItem> PopulateCompany()
        {
            List<SelectListItem> items = new List<SelectListItem>();
            using (SqlConnection sqlConnection = new SqlConnection(_configuration.GetConnectionString("AuthContextConnection")))
            {
                sqlConnection.Open();
                SqlCommand sqlCmd = new SqlCommand("spSelect_CompanybyFilter", sqlConnection);
                sqlCmd.Parameters.AddWithValue("TextFilter", "");
                sqlCmd.Parameters.AddWithValue("ColumnName", "CompanyInitial");
                sqlCmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader sqlDr = sqlCmd.ExecuteReader();

                while(sqlDr.Read())
                {
                    items.Add(new SelectListItem
                    {
                        Text = sqlDr["CompanyInitial"].ToString(),
                        Value = sqlDr["CompanyID"].ToString()
                    });
                   
                }
               
            }
            return items;
        }

        public List<SelectListItem> PopulateCustomer()
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

        public List<SelectListItem> PopulateStockGroup()
        {
            List<SelectListItem> items = new List<SelectListItem>();
            using (SqlConnection sqlConnection = new SqlConnection(_configuration.GetConnectionString("AuthContextConnection")))
            {
                sqlConnection.Open();
                SqlCommand sqlCmd = new SqlCommand("spSelect_StockGroupbyFilter", sqlConnection);
                sqlCmd.Parameters.AddWithValue("TextFilter", "");
                sqlCmd.Parameters.AddWithValue("ColumnName", "StockGroupCategory");
                sqlCmd.CommandType = System.Data.CommandType.StoredProcedure;
                SqlDataReader sqlDr = sqlCmd.ExecuteReader();

                while (sqlDr.Read())
                {
                    items.Add(new SelectListItem
                    {
                        Text = sqlDr["StockGroupCategory"].ToString(),
                        Value = sqlDr["StockGroupID"].ToString()
                    });

                }

            }
            return items;
        }
    }
}
