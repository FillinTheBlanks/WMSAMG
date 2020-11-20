using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WMSAMG.Models.CSIS2017Models
{
    public partial class VwGllogTemp
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
    }
}
