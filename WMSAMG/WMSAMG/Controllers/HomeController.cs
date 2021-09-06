﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Diagnostics;
using WMSAMG.Models;

namespace WMSAMG.Controllers
{

    
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;
        //public HomeController(ILogger<HomeController> logger)
        //{
        //    _logger = logger;
        //}

        public HomeController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [Authorize]
        public IActionResult Index()
        {
            DataTable dt = new DataTable();
            using (SqlConnection sqlConnection = new SqlConnection(_configuration.GetConnectionString("DataContextConnection")))
            {
                sqlConnection.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("spSelect_OnHandInventory", sqlConnection);
                sqlDa.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sqlDa.SelectCommand.Parameters.AddWithValue("CompanyID", "35a953cd-49b0-4db4-b5ec-2aa23733a5e2");
                sqlDa.SelectCommand.Parameters.AddWithValue("LocationID", "aea95735-24df-40a2-9132-5cbff7595bb9");
                sqlDa.SelectCommand.Parameters.AddWithValue("CustomerID", "");
                sqlDa.Fill(dt);
            }
            ViewBag.datasource = dt;
            return View(dt);

        }

        [Authorize]
        public IActionResult StoragingTicket()
        {
            DataTable dt = new DataTable();
            using (SqlConnection sqlConnection = new SqlConnection(_configuration.GetConnectionString("DataContextConnection")))
            {
                sqlConnection.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("spSelect_StorageTicket", sqlConnection);
                sqlDa.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sqlDa.SelectCommand.Parameters.AddWithValue("CustomerID", "");
                sqlDa.SelectCommand.Parameters.AddWithValue("TransactionDate", "");
                sqlDa.SelectCommand.Parameters.AddWithValue("StorageID", "");
                sqlDa.Fill(dt);
            }
            ViewBag.datasource = dt;

            return View(dt);
        }

        [Authorize]
        public IActionResult WithdrawalTicket()
        {
            DataTable dt = new DataTable();
            using (SqlConnection sqlConnection = new SqlConnection(_configuration.GetConnectionString("DataContextConnection")))
            {
                sqlConnection.Open();
                SqlDataAdapter sqlDa = new SqlDataAdapter("spSelect_WithdrawalTicket", sqlConnection);
                sqlDa.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
                sqlDa.SelectCommand.Parameters.AddWithValue("CustomerID", "");
                sqlDa.SelectCommand.Parameters.AddWithValue("TransactionDate", "");
                sqlDa.SelectCommand.Parameters.AddWithValue("StorageID", "");
                sqlDa.Fill(dt);
            }
            ViewBag.datasource = dt;

            return View(dt);
        }

        
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


    }
}
