using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WMSAMG.Models.CSIS2017Models
{
    [Table("tblTempUserFP_08262019")]
    public partial class TblTempUserFp08262019
    {
        [Column("UserID")]
        [StringLength(10)]
        public string UserId { get; set; }
        [StringLength(10)]
        public string StatusMsg { get; set; }
        [StringLength(100)]
        public string FullName { get; set; }
        [StringLength(100)]
        public string CardNo { get; set; }
        [StringLength(100)]
        public string Passcode { get; set; }
        [StringLength(300)]
        public string FingerIndex { get; set; }
        [StringLength(10)]
        public string Flag { get; set; }
        [Column("FP")]
        [StringLength(100)]
        public string Fp { get; set; }
        [StringLength(10)]
        public string Privilege { get; set; }
    }
}
