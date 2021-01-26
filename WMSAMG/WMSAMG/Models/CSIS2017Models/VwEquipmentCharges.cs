using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WMSAMG.Models.CSIS2017Models
{
    public partial class VwEquipmentCharges
    {
        public Guid RefNum { get; set; }
        [StringLength(50)]
        public string ReferenceNo { get; set; }
        [Column("EquipmentID")]
        public Guid? EquipmentId { get; set; }
        [StringLength(10)]
        public string EquipmentInitial { get; set; }
        [StringLength(100)]
        public string EquipmentTitle { get; set; }
        [StringLength(50)]
        public string EquipmentCategory { get; set; }
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
        [Column(TypeName = "datetime")]
        public DateTime? OfficeHourTimeIn { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? OfficeHourTimeOut { get; set; }
    }
}
