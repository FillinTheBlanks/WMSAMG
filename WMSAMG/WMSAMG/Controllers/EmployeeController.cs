using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WMSAMG.Models;
using Microsoft.AspNetCore.Mvc;
using WMSAMG.Models.PRACTICEDB;

namespace WMSAMG.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }

        //public ActionResult Index()
        //{
        //    var repo = new EmployeeRepository();
        //    var employeeList = new repo.CreateEmployee();
        //    return View(employeeList);
        //}

        //Get All Employee
        public JsonResult Get_AllEmployee()
        {
            
            using (PRACTICEDBContext Obj = new PRACTICEDBContext())
            {
                List<EmployeeView> Emp = Obj.EmployeeViews.ToList();

                return Json(Emp, new System.Text.Json.JsonSerializerOptions());
            }
            
        }
        //Get Employee with Id
        public JsonResult Get_EmployeeById(string Id)
        {
            using(PRACTICEDBContext Obj = new PRACTICEDBContext())
            {
                int EmpId = int.Parse(Id);
                return Json(Obj.Employees.Find(EmpId), new System.Text.Json.JsonSerializerOptions());
            }
        }

        //Insert new Employee
        public string Insert_Employee(Employee employee)
        {
            if (employee != null)
            {
                using(PRACTICEDBContext Obj = new PRACTICEDBContext())
                {
                    Obj.Employees.Add(employee);
                    Obj.SaveChanges();
                    return "Employee Added Successfully";
                }
            } else
            {
                return "Employee Not Inserted! Try Again";
            }
            
        }

        //Delete Employee Information
        public string Delete_Employee(Employee employee)
        {
            if(employee != null)
            {
                using(PRACTICEDBContext Obj = new PRACTICEDBContext())
                {
                    var Emp_ = Obj.Entry(employee);
                    if(Emp_.State == Microsoft.EntityFrameworkCore.EntityState.Detached)
                    {
                        Obj.Employees.Attach(employee);
                        Obj.Employees.Remove(employee);
                    }
                    Obj.SaveChanges();
                    return "Employee Deleted Successfully";
                }
            } else
            {
                return "Employee Not Delete! Try Again";
            }
        }

        //Update Employee Information
        public string Update_Employee(Employee employee)
        {
            if(employee != null)
            {
                using(PRACTICEDBContext Obj = new PRACTICEDBContext())
                {
                    var Emp_ = Obj.Entry(employee);
                    Employee EmpObj = Obj.Employees.Where(x => x.EmpId == employee.EmpId).FirstOrDefault();

                    EmpObj.EmpAge = employee.EmpAge;
                    EmpObj.EmpCity = employee.EmpCity;
                    EmpObj.EmpName = employee.EmpName;
                    EmpObj.DeptCode = employee.DeptCode;
                    Obj.SaveChanges();
                    return "Employee Updated Successfully";
                }
            } else
            {
                return "Employee Not Updated! Try Again";
            }
        }
    }
}