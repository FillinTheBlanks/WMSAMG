using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WMSAMG.Models.CSIS2017Models
{
    [Table("tblTempUserInfo")]
    public partial class TblTempUserInfo
    {
        [Column("UserID")]
        [StringLength(10)]
        public string UserId { get; set; }
        [StringLength(100)]
        public string FullName { get; set; }
        public int? Privilege { get; set; }
        [StringLength(20)]
        public string Passcode { get; set; }
        [StringLength(10)]
        public string CardNo { get; set; }
    }
}
