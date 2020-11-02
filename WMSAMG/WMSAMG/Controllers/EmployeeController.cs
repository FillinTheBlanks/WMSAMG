using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using WMSAMG.Models.CSISControlModels;

namespace WMSAMG.Controllers
{
    
    public class EmployeeController : Controller
    {
        CSISControlContext Obj = new CSISControlContext();
        //[EnableCors("AllowOrigin")]
        public ActionResult Index()
        {
            return View();
        }

        //Get All Employee
        [HttpGet]
        [Route("Employee/Get_AllEmployee")]
        public JsonResult Get_AllEmployee()
        {    
            using(CSISControlContext Obj = new CSISControlContext())
            { 
                List<VwEmployeetoDepartmentandCompany> Emp = Obj.VwEmployeetoDepartmentandCompany.ToList();
                return Json(Emp, new System.Text.Json.JsonSerializerOptions());
            }
        }

        [HttpGet]
        [Route("Employee/Get_EmployeeById/{Id}")]
        //Get Employee with Id
        public JsonResult Get_EmployeeById(string Id)
        {
            using(CSISControlContext Obj = new CSISControlContext())
            {
                Guid EmployeeId = Guid.Parse(Id);
                return Json(Obj.VwEmployeetoDepartmentandCompany.Find(EmployeeId), new System.Text.Json.JsonSerializerOptions());
            }
        }

        [HttpPost]
        [Route("Employee/InsertEmployee")]
        public JsonResult InsertEmployee([FromBody] TblEmployee employees)
        {
            using (CSISControlContext Obj = new CSISControlContext())
            {
                if (ModelState.IsValid)
                {
                    Obj.TblEmployee.Add(employees);
                    Obj.SaveChanges();
                    string message = " Insert Success!";
                    return Json(message, new System.Text.Json.JsonSerializerOptions());
                }
                else
                {
                    string message = "Error on Model!";
                    return Json(message, new System.Text.Json.JsonSerializerOptions());
                }
            }
        }

        [HttpPut]
        [Route("Employee/UpdateEmployee")]
        public JsonResult UpdateEmployee([FromBody] TblEmployee employee)
        {
            using (CSISControlContext Obj = new CSISControlContext())
            {
                if (ModelState.IsValid)
                {
                    var emp = Obj.VwEmployeetoDepartmentandCompany.Where(x => x.EmployeeId == employee.EmployeeId).FirstOrDefault();
                    //emp.EmpName = employee.EmpName;
                    //emp.EmpCity = employee.EmpCity;
                    //emp.EmpAge = employee.EmpAge;
                    //emp.DeptCode = employee.DeptCode;
                    Obj.SaveChanges();
                    return Json(emp, new System.Text.Json.JsonSerializerOptions());
                }
                else
                {
                    string message = "Error on Model!";
                    return Json(message, new System.Text.Json.JsonSerializerOptions());
                }
            }
        }

        [HttpDelete]
        [Route("Employee/DeleteEmployee/{EmpId}")]
        public JsonResult DeleteEmployee(int EmpId)
        {
            using (CSISControlContext Obj = new CSISControlContext())
            {
                if (ModelState.IsValid)
                {
                    TblEmployee employee = Obj.TblEmployee.Find(EmpId);
                    Obj.TblEmployee.Remove(employee);
                    Obj.SaveChanges();
                    return Json(employee, new System.Text.Json.JsonSerializerOptions());
                }
                else
                {
                    string message = "Error on Model!";
                    return Json(message, new System.Text.Json.JsonSerializerOptions());
                }
            }
        }

        [HttpGet]
        [Route("Employee/getById/{Id}")]
        public JsonResult getById(int EmployeeId)
        {
            using (CSISControlContext Obj = new CSISControlContext())
            {
                VwEmployeetoDepartmentandCompany employee = Obj.VwEmployeetoDepartmentandCompany.Find(EmployeeId);
                return Json(employee, new System.Text.Json.JsonSerializerOptions());
            }
        }


        ////Insert new Employee
        //public string Insert_Employee(Employee employee)
        //{
        //    if (employee != null)
        //    {
        //        using(PRACTICEDBContext Obj = new PRACTICEDBContext())
        //        {
        //            Obj.Employee.Add(employee);
        //            Obj.SaveChanges();
        //            return "Employee Added Successfully";
        //        }
        //    } else
        //    {
        //        return "Employee Not Inserted! Try Again";
        //    }
            
        //}

        ////Delete Employee Information
        //public string Delete_Employee(Employee employee)
        //{
        //    if(employee != null)
        //    {
        //        using(PRACTICEDBContext Obj = new PRACTICEDBContext())
        //        {
        //            var Emp_ = Obj.Entry(employee);
        //            if(Emp_.State == Microsoft.EntityFrameworkCore.EntityState.Detached)
        //            {
        //                Obj.Employee.Attach(employee);
        //                Obj.Employee.Remove(employee);
        //            }
        //            Obj.SaveChanges();
        //            return "Employee Deleted Successfully";
        //        }
        //    } else
        //    {
        //        return "Employee Not Delete! Try Again";
        //    }
        //}

        ////Update Employee Information
        //public string Update_Employee(Employee employee)
        //{
            
        //    if (employee != null)
        //    {
        //        using (PRACTICEDBContext Obj = new PRACTICEDBContext())
        //        {
        //            var Emp_ = Obj.Entry(employee);
        //            Employee EmpObj = Obj.Employee.Where(x => x.EmpId == employee.EmpId).FirstOrDefault();
        //            //Employee EmpObj = Obj.Employee.Where(x => x.EmpId == 3005).FirstOrDefault();

        //            EmpObj.EmpAge = employee.EmpAge;
        //            EmpObj.EmpCity = employee.EmpCity;
        //            EmpObj.EmpName = employee.EmpName;
        //            EmpObj.DeptCode = employee.DeptCode;
        //            Obj.SaveChanges();
        //            return "Employee Updated Successfully";
        //        }
        //    } else
        //    {
        //        return "Employee Not Updated! Try Again";
        //    }
        //}
    }
}