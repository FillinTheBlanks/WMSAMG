using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WMSAMG.Models.CSISControlModels
{
    [Table("tblEquipment")]
    public partial class TblEquipment
    {
        [Key]
        [Column("EquipmentID")]
        public Guid EquipmentId { get; set; }
        [Column("EquipmentCategoryID")]
        public Guid? EquipmentCategoryId { get; set; }
        [StringLength(10)]
        public string EquipmentInitial { get; set; }
        [StringLength(100)]
        public string EquipmentTitle { get; set; }
        [Column(TypeName = "money")]
        public decimal? EquipmentRate { get; set; }
        [Column(TypeName = "money")]
        public decimal? OvertimeRate { get; set; }
        [Column("CompanyID")]
        public Guid? CompanyId { get; set; }
        public bool? EquipmentStatus { get; set; }
        public bool? AutoAdd { get; set; }
    }
}
