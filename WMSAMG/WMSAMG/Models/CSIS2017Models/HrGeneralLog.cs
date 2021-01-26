using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WMSAMG.Models.CSIS2017Models
{
    [Table("HR.GeneralLog")]
    public partial class HrGeneralLog
    {
        [Column("GLCount")]
        [StringLength(50)]
        public string Glcount { get; set; }
        [StringLength(50)]
        public string EnrollNo { get; set; }
        [StringLength(50)]
        public string VerifyMode { get; set; }
        [StringLength(10)]
        public string InOutMode { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DateTimeLog { get; set; }
    }
}
