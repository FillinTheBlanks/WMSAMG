using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WMSAMG.Models.CSISControlModels
{
    [Table("tblTreeControl")]
    public partial class TblTreeControl
    {
        [Key]
        [Column("TreeID")]
        public int TreeId { get; set; }
        [StringLength(100)]
        public string TreeName { get; set; }
        [StringLength(10)]
        public string ParentChild { get; set; }
        public int? ArrangeOrder { get; set; }
        [Column("ParentTreeID")]
        public int? ParentTreeId { get; set; }
        [StringLength(10)]
        public string Status { get; set; }
        [StringLength(100)]
        public string NavGroupDesc { get; set; }
    }
}
