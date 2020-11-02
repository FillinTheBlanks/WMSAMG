//using System;
//using System.Collections.Generic;
//using System.Linq;
//using Microsoft.AspNetCore.Cors;
//using Microsoft.AspNetCore.Mvc;
//using WMSAMG.Models.PRACTICEDB;

//namespace WMSAMG.TestFiles
//{
    
//    public class EmployeeController : Controller
//    {
//        PRACTICEDBContext Obj = new PRACTICEDBContext();
//        //[EnableCors("AllowOrigin")]
//        public ActionResult Index()
//        {
//            return View();
//        }

//        //Get All Employee
//        [HttpGet]
//        [Route("Employee/Get_AllEmployee")]
//        public JsonResult Get_AllEmployee()
//        {
            
//            using (PRACTICEDBContext Obj = new PRACTICEDBContext())
//            {
//                List<EmployeeView> Emp = Obj.EmployeeView.ToList();

//                return Json(Emp, new System.Text.Json.JsonSerializerOptions());
//            }
            
//        }
//        [HttpGet]
//        [Route("Employee/Get_EmployeeById/{Id}")]
//        //Get Employee with Id
//        public JsonResult Get_EmployeeById(string Id)
//        {
//            using(PRACTICEDBContext Obj = new PRACTICEDBContext())
//            {
//                int EmpId = int.Parse(Id);
//                return Json(Obj.Employee.Find(EmpId), new System.Text.Json.JsonSerializerOptions());
//            }
//        }

//        [HttpPost]
//        [Route("Employee/InsertEmployee")]
//        public JsonResult InsertEmployee([FromBody] Employee employees)
//        {

//            if (ModelState.IsValid)
//            {
//                Obj.Employee.Add(employees);
//                Obj.SaveChanges();
//                string message = " Insert Success!";
//                return Json(message, new System.Text.Json.JsonSerializerOptions());
//            }
//            else
//            {
//                string message = "Error on Model!";
//                return Json(message, new System.Text.Json.JsonSerializerOptions());
//            }
//        }

//        [HttpPut]
//        [Route("Employee/UpdateEmployee")]
//        public JsonResult UpdateEmployee([FromBody] Employee employee)
//        {
//            if (ModelState.IsValid)
//            {
//                var emp = Obj.Employee.Where(x => x.EmpId == employee.EmpId).FirstOrDefault();
//                emp.EmpName = employee.EmpName;
//                emp.EmpCity = employee.EmpCity;
//                emp.EmpAge = employee.EmpAge;
//                emp.DeptCode = employee.DeptCode;
//                Obj.SaveChanges();
//                return Json(emp, new System.Text.Json.JsonSerializerOptions());
//            }
//            else
//            {
//                string message = "Error on Model!";
//                return Json(message, new System.Text.Json.JsonSerializerOptions());
//            }
//        }

//        [HttpDelete]
//        [Route("Employee/DeleteEmployee/{EmpId}")]
//        public JsonResult DeleteEmployee(int EmpId)
//        {
//            if (ModelState.IsValid)
//            {
//                Employee employee = Obj.Employee.Find(EmpId);
//                Obj.Employee.Remove(employee);
//                Obj.SaveChanges();
//                return Json(employee, new System.Text.Json.JsonSerializerOptions());
//            }
//            else
//            {
//                string message = "Error on Model!";
//                return Json(message, new System.Text.Json.JsonSerializerOptions());
//            }
//        }

//        [HttpGet]
//        [Route("Employee/getById/{Id}")]
//        public JsonResult getById(int Id)
//        {
//            Employee employee = Obj.Employee.Find(Id);
//            return Json(employee, new System.Text.Json.JsonSerializerOptions());
//        }


//        ////Insert new Employee
//        //public string Insert_Employee(Employee employee)
//        //{
//        //    if (employee != null)
//        //    {
//        //        using(PRACTICEDBContext Obj = new PRACTICEDBContext())
//        //        {
//        //            Obj.Employee.Add(employee);
//        //            Obj.SaveChanges();
//        //            return "Employee Added Successfully";
//        //        }
//        //    } else
//        //    {
//        //        return "Employee Not Inserted! Try Again";
//        //    }
            
//        //}

//        ////Delete Employee Information
//        //public string Delete_Employee(Employee employee)
//        //{
//        //    if(employee != null)
//        //    {
//        //        using(PRACTICEDBContext Obj = new PRACTICEDBContext())
//        //        {
//        //            var Emp_ = Obj.Entry(employee);
//        //            if(Emp_.State == Microsoft.EntityFrameworkCore.EntityState.Detached)
//        //            {
//        //                Obj.Employee.Attach(employee);
//        //                Obj.Employee.Remove(employee);
//        //            }
//        //            Obj.SaveChanges();
//        //            return "Employee Deleted Successfully";
//        //        }
//        //    } else
//        //    {
//        //        return "Employee Not Delete! Try Again";
//        //    }
//        //}

//        ////Update Employee Information
//        //public string Update_Employee(Employee employee)
//        //{
            
//        //    if (employee != null)
//        //    {
//        //        using (PRACTICEDBContext Obj = new PRACTICEDBContext())
//        //        {
//        //            var Emp_ = Obj.Entry(employee);
//        //            Employee EmpObj = Obj.Employee.Where(x => x.EmpId == employee.EmpId).FirstOrDefault();
//        //            //Employee EmpObj = Obj.Employee.Where(x => x.EmpId == 3005).FirstOrDefault();

//        //            EmpObj.EmpAge = employee.EmpAge;
//        //            EmpObj.EmpCity = employee.EmpCity;
//        //            EmpObj.EmpName = employee.EmpName;
//        //            EmpObj.DeptCode = employee.DeptCode;
//        //            Obj.SaveChanges();
//        //            return "Employee Updated Successfully";
//        //        }
//        //    } else
//        //    {
//        //        return "Employee Not Updated! Try Again";
//        //    }
//        //}
//    }
//}