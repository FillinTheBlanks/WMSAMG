using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WMSAMG.Models.CSIS2017Models
{
    public partial class VwGllog
    {
        [Column("GLCount")]
        [StringLength(50)]
        public string Glcount { get; set; }
        [StringLength(50)]
        public string EnrollNo { get; set; }
        [StringLength(104)]
        public string FullName { get; set; }
        [StringLength(50)]
        public string VerifyMode { get; set; }
        [StringLength(10)]
        public string InOutMode { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DateTimeLog { get; set; }
        [Required]
        [StringLength(100)]
        public string Attgroup { get; set; }
        [StringLength(4000)]
        public string RegTimeIn { get; set; }
        [StringLength(4000)]
        public string RegTimeOut { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? OverTimeIn { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? OverTimeOut { get; set; }
        [StringLength(4000)]
        public string NightDiffIn { get; set; }
        [StringLength(4000)]
        public string NightDiffOut { get; set; }
        [Column("isAllowedOT")]
        public bool? IsAllowedOt { get; set; }
    }
}
