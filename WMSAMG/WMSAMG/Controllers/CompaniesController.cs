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
using WMSAMG.Models.CSISControlModels;

namespace WMSAMG.Controllers
{
    public class CompaniesController : Controller
    {
        private readonly IConfiguration _configuration;

        public CompaniesController(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        // GET: Companies
        public IActionResult Index()
        {
            DataTable dt = new DataTable();
            using (SqlConnection sqlConnection = new SqlConnection(_configuration.GetConnectionString("AuthContextConnection")))
            {
                sqlConnection.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("spSelect_CompanybyFilter", sqlConnection);
                sqlDa.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sqlDa.SelectCommand.Parameters.AddWithValue("TextFilter", "");
                sqlDa.SelectCommand.Parameters.AddWithValue("ColumnName", "CompanyInitial");
                sqlDa.Fill(dt);
            }
            return View(dt);
            
        }

        //Get All Employee
        [HttpGet]
        [Route("Company/Get_AllCompany")]
        public JsonResult Get_AllCompany()
        {
            using (CSISControlContext Obj = new CSISControlContext())
            {
                List<TblCompany> companies = Obj.TblCompany.ToList();
                return Json(companies, new System.Text.Json.JsonSerializerOptions());
            }
        }

        // GET: Companies/Details/5
        public IActionResult Details(Guid? id)
        {
            TblCompany tblCompany = new TblCompany();

            return View(tblCompany);
        }

        // GET: Companies/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Companies/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("CompanyId,CompanyName,CompanyInitial,CompanyAddress,CompanyStatus,OfficeHourTimeIn,OfficeHourTimeOut")] TblCompany tblCompany)
        {
            if (ModelState.IsValid)
            {
                
                return RedirectToAction(nameof(Index));
            }
            return View(tblCompany);
        }

        // GET: Companies/Edit/5
        public IActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

           
            return View();
        }

        // POST: Companies/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Guid id, [Bind("CompanyId,CompanyName,CompanyInitial,CompanyAddress,CompanyStatus,OfficeHourTimeIn,OfficeHourTimeOut")] TblCompany tblCompany)
        {
            if (id != tblCompany.CompanyId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
               
                return RedirectToAction(nameof(Index));
            }
            return View(tblCompany);
        }

        // GET: Companies/Delete/5
        public IActionResult Delete(Guid? id)
        {
            TblCompany tblCompany = new TblCompany();

            return View(tblCompany);
        }

        // POST: Companies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(Guid id)
        {
            
            return RedirectToAction(nameof(Index));
        }

    }
}
