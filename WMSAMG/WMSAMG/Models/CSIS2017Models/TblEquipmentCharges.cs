using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WMSAMG.Models.CSIS2017Models
{
    [Table("tblEquipmentCharges")]
    public partial class TblEquipmentCharges
    {
        [Key]
        public Guid RefNum { get; set; }
        [StringLength(50)]
        public string ReferenceNo { get; set; }
        [Column("EquipmentID")]
        public Guid? EquipmentId { get; set; }
        [Column(TypeName = "money")]
        public decimal? Qty { get; set; }
        [Column(TypeName = "money")]
        public decimal? EquipmentRate { get; set; }
        [Column(TypeName = "money")]
        public decimal? OvertimeRate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? TransactionDate { get; set; }
        [Column("EmployeeID")]
        public Guid? EmployeeId { get; set; }
        [Column("LocationID")]
        public Guid? LocationId { get; set; }
    }
}
