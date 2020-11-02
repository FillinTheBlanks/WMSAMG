using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WMSAMG.Models.CSISControlModels
{
    [Table("tblEquipmentCategory")]
    public partial class TblEquipmentCategory
    {
        [Key]
        [Column("EquipmentCategoryID")]
        public Guid EquipmentCategoryId { get; set; }
        [StringLength(50)]
        public string EquipmentCategory { get; set; }
    }
}
