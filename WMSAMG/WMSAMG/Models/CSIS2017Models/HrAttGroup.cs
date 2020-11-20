using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WMSAMG.Models.CSIS2017Models
{
    [Table("HR.AttGroup")]
    public partial class HrAttGroup
    {
        [Key]
        [StringLength(100)]
        public string AttGroup { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? RegTimeIn { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? RegTimeOut { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? OverTimeIn { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? OverTimeOut { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? NightDiffIn { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? NightDiffOut { get; set; }
        [Column("isAllowedOT")]
        public bool? IsAllowedOt { get; set; }
        [Column("isEnabled")]
        public bool? IsEnabled { get; set; }
    }
}
