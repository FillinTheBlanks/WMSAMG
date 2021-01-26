using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WMSAMG.Models.CSISControlModels
{
    [Table("tblEmployee")]
    public partial class TblEmployee
    {
        [Key]
        [Column("EmployeeID")]
        public Guid EmployeeId { get; set; }
        [StringLength(50)]
        public string EmployeeFname { get; set; }
        [StringLength(50)]
        public string EmployeeMname { get; set; }
        [StringLength(50)]
        public string EmployeeLname { get; set; }
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
        public Guid? ApprovedBy { get; set; }
        public Guid? EncodedBy { get; set; }
        [Column(TypeName = "date")]
        public DateTime? DateEncoded { get; set; }
        [StringLength(50)]
        public string EnrollNo { get; set; }
        [StringLength(10)]
        public string AttGroup { get; set; }
    }
}
