using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WMSAMG.Models.CSISControlModels
{
    public partial class VwDepartmenttoCompany
    {
        [Column("DepartmentID")]
        public Guid DepartmentId { get; set; }
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
        public bool? DepartmentStatus { get; set; }
    }
}
