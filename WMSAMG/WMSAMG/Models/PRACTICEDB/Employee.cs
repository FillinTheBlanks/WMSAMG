using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WMSAMG.Models.PRACTICEDB
{
    public partial class Employee
    {
        [Key]
        [Column("Emp_Id")]
        public int EmpId { get; set; }
        [Column("Emp_Name")]
        public string EmpName { get; set; }
        [Column("Emp_City")]
        public string EmpCity { get; set; }
        [Column("Emp_Age")]
        public int? EmpAge { get; set; }
        [Column("Dept_Code")]
        public int? DeptCode { get; set; }

        [ForeignKey(nameof(DeptCode))]
        [InverseProperty(nameof(Department.Employee))]
        public virtual Department DeptCodeNavigation { get; set; }
        
    }
}
