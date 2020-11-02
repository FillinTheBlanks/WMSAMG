using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WMSAMG.Models.CSISControlModels
{
    [Table("tblDepartment")]
    public partial class TblDepartment
    {
        [Key]
        [Column("DepartmentID")]
        public Guid DepartmentId { get; set; }
        [Key]
        [Column("CompanyID")]
        public Guid CompanyId { get; set; }
        [StringLength(100)]
        public string DepartmentName { get; set; }
        public bool? DepartmentStatus { get; set; }
    }
}
