using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WMSAMG.Models.CSISControlModels
{
    public partial class VwEmployeetoDepartmentandCompany
    {
        [Column("EmployeeID")]
        public Guid EmployeeId { get; set; }
        [StringLength(50)]
        public string EmployeeFname { get; set; }
        [StringLength(50)]
        public string EmployeeMname { get; set; }
        [StringLength(50)]
        public string EmployeeLname { get; set; }
        [StringLength(104)]
        public string FullName { get; set; }
        [StringLength(10)]
        public string EmployeeGender { get; set; }
        [Column("EmployeeBDate", TypeName = "date")]
        public DateTime? EmployeeBdate { get; set; }
        [StringLength(50)]
        public string EmployeeEmail { get; set; }
        [StringLength(100)]
        public string EmployeePosition { get; set; }
        [Column("DepartmentID")]
        [StringLength(50)]
        public string DepartmentId { get; set; }
        public bool? EmployeeStatus { get; set; }
        [StringLength(100)]
        public string DepartmentName { get; set; }
        [Column("CompanyID")]
        public Guid? CompanyId { get; set; }
        [StringLength(100)]
        public string CompanyName { get; set; }
        [StringLength(10)]
        public string CompanyInitial { get; set; }
        [StringLength(200)]
        public string CompanyAddress { get; set; }
        public bool? CompanyStatus { get; set; }
        [StringLength(50)]
        public string EnrollNo { get; set; }
        [Required]
        [StringLength(100)]
        public string Attgroup { get; set; }
    }
}
