using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WMSAMG.Models.CSISControlModels
{
    public partial class VwUserAccount
    {
        [Column("UserID")]
        public Guid UserId { get; set; }
        [Column("UserGroupID")]
        public int UserGroupId { get; set; }
        [StringLength(100)]
        public string UserGroupName { get; set; }
        [StringLength(100)]
        public string UserRole { get; set; }
        [Column("EmployeeID")]
        public Guid? EmployeeId { get; set; }
        [StringLength(50)]
        public string EmployeeFname { get; set; }
        [StringLength(50)]
        public string EmployeeMname { get; set; }
        [StringLength(50)]
        public string EmployeeLname { get; set; }
        [StringLength(100)]
        public string EmployeePosition { get; set; }
        [StringLength(100)]
        public string DepartmentName { get; set; }
        [StringLength(20)]
        public string Username { get; set; }
        [StringLength(64)]
        public string UserPassword { get; set; }
        [Column("CompanyID")]
        public Guid? CompanyId { get; set; }
        [StringLength(100)]
        public string CompanyName { get; set; }
        [StringLength(10)]
        public string CompanyInitial { get; set; }
        [Column("LocationID")]
        public Guid? LocationId { get; set; }
        [StringLength(10)]
        public string LocationInitial { get; set; }
        [StringLength(50)]
        public string LocationDescription { get; set; }
        public bool? UserStatus { get; set; }
    }
}
