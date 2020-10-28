using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WMSAMG.Models.PRACTICEDB;
using WMSAMG.Models;

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
            using (PRACTICEDBContext Obj = new PRACTICEDBContext())
            {
                List<Department> Dept = Obj.Departments.ToList();

                return Json(Dept, new System.Text.Json.JsonSerializerOptions());
            }

        }
        //Get Employee with Id
        public JsonResult Get_DepartmentById(string Id)
        {
            using (PRACTICEDBContext Obj = new PRACTICEDBContext())
            {
                int DeptCode = int.Parse(Id);
                return Json(Obj.Departments.Find(DeptCode), new System.Text.Json.JsonSerializerOptions());
            }
        }

        //Insert new Department
        public string Insert_Department(Department department)
        {
            if (department != null)
            {
                using (PRACTICEDBContext Obj = new PRACTICEDBContext())
                {
                    Obj.Departments.Add(department);
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
        public string Delete_Department(Department department)
        {
            if (department != null)
            {
                using (PRACTICEDBContext Obj = new PRACTICEDBContext())
                {
                    var Emp_ = Obj.Entry(department);
                    if (Emp_.State == Microsoft.EntityFrameworkCore.EntityState.Detached)
                    {
                        Obj.Departments.Attach(department);
                        Obj.Departments.Remove(department);
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
        public string Update_Department(Department department)
        {
            if (department != null)
            {
                using (PRACTICEDBContext Obj = new PRACTICEDBContext())
                {
                    var Dept_ = Obj.Entry(department);
                    Department DeptObj = Obj.Departments.Where(x => x.DeptCode == department.DeptCode).FirstOrDefault();
                    DeptObj.DeptName = department.DeptName;
                   
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