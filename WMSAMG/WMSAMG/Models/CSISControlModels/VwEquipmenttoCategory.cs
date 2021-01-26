using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WMSAMG.Models.CSISControlModels
{
    public partial class VwEquipmenttoCategory
    {
        [Column("CompanyID")]
        public Guid? CompanyId { get; set; }
        [StringLength(100)]
        public string CompanyName { get; set; }
        [StringLength(10)]
        public string CompanyInitial { get; set; }
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
        public bool? EquipmentStatus { get; set; }
        public bool? AutoAdd { get; set; }
        [StringLength(50)]
        public string EquipmentCategory { get; set; }
    }
}
