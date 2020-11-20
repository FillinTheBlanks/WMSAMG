using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WMSAMG.Models.CSIS2017Models
{
    [Table("tblTempUserFP")]
    public partial class TblTempUserFp
    {
        [Column("UserID")]
        [StringLength(10)]
        public string UserId { get; set; }
        [Column("isValid")]
        [StringLength(10)]
        public string IsValid { get; set; }
        [Column("isDuress")]
        [StringLength(10)]
        public string IsDuress { get; set; }
        [StringLength(100)]
        public string BioType { get; set; }
        [StringLength(100)]
        public string TmpVersion { get; set; }
        [StringLength(20)]
        public string TmpFormat { get; set; }
        [StringLength(10)]
        public string TmpNo { get; set; }
        [Column("FPIndex")]
        [StringLength(10)]
        public string Fpindex { get; set; }
        [StringLength(1000)]
        public string Tmp { get; set; }
    }
}
