using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WMSAMG.Models.CSISControlModels
{
    [Table("tblPayType")]
    public partial class TblPayType
    {
        [StringLength(5)]
        public string PayTypeInitial { get; set; }
        [StringLength(50)]
        public string PayTypeDesc { get; set; }
    }
}
