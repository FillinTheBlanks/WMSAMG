using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WMSAMG.Models.CSISControlModels
{
    [Table("tblStockGroup")]
    public partial class TblStockGroup
    {
        [Key]
        [Column("StockGroupID")]
        public Guid StockGroupId { get; set; }
        [StringLength(50)]
        public string StockGroupCategory { get; set; }
        [StringLength(50)]
        public string StockGroupSpecie { get; set; }
    }
}
