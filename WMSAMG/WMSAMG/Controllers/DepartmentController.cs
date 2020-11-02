using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WMSAMG.Models.CSISControlModels;


namespace WMSAMG.Controllers
{
    public class DepartmentController : Controller
    {
        // GET: Department
        public ActionResult Index()
        {
            return View();
        }

        //Get All Employee
        public JsonResult Get_AllDepartment()
        {
            using (CSISControlContext Obj = new CSISControlContext())
            {
                List<VwDepartmenttoCompany> Dept = Obj.VwDepartmenttoCompany.ToList();

                return Json(Dept, new System.Text.Json.JsonSerializerOptions());
            }

        }
        //Get Employee with Id
        public JsonResult Get_DepartmentById(string Id)
        {
            using (CSISControlContext Obj = new CSISControlContext())
            {
                Guid DepartmentId = Guid.Parse(Id);
                return Json(Obj.TblDepartment.Find(DepartmentId), new System.Text.Json.JsonSerializerOptions());
            }
        }

        //Insert new Department
        public string Insert_Department(TblDepartment department)
        {
            if (department != null)
            {
                using (CSISControlContext Obj = new CSISControlContext())
                {
                    Obj.TblDepartment.Add(department);
                    Obj.SaveChanges();
                    return "Department Added Successfully";
                }
            }
            else
            {
                return "Department Not Inserted! Try Again";
            }

        }

        //Delete Department Information
        public string Delete_Department(TblDepartment department)
        {
            if (department != null)
            {
                using (CSISControlContext Obj = new CSISControlContext())
                {
                    var Emp_ = Obj.Entry(department);
                    if (Emp_.State == Microsoft.EntityFrameworkCore.EntityState.Detached)
                    {
                        Obj.TblDepartment.Attach(department);
                        Obj.TblDepartment.Remove(department);
                    }
                    Obj.SaveChanges();
                    return "Department Deleted Successfully";
                }
            }
            else
            {
                return "Department Not Delete! Try Again";
            }
        }

        //Update Department Information
        public string Update_Department(TblDepartment department)
        {
            if (department != null)
            {
                using (CSISControlContext Obj = new CSISControlContext())
                {
                    var Dept_ = Obj.Entry(department);
                    TblDepartment DeptObj = Obj.TblDepartment.Where(x => x.DepartmentId == department.DepartmentId).FirstOrDefault();
                    DeptObj.DepartmentName = department.DepartmentName;
                    DeptObj.DepartmentStatus = department.DepartmentStatus;
                    Obj.SaveChanges();
                    return "Department Updated Successfully";
                }
            }
            else
            {
                return "Department Not Updated! Try Again";
            }
        }
    }
}