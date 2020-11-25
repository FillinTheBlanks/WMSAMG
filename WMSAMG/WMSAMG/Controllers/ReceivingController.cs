﻿using System;
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
            using (SqlConnection sqlConnection = new SqlConnection(_configuration.GetConnectionString("AuthContextConnection")))
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
            if (id == null)
            {
                return NotFound();
            }

           

            return View();
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

    }
}