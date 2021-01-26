using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WMSAMG.Models.CSIS2017Models
{
    [Table("tblDTRReport")]
    public partial class TblDtrreport
    {
        public int? EnrollNo { get; set; }
        [StringLength(100)]
        public string FullName { get; set; }
        public int? DateYear { get; set; }
        [StringLength(50)]
        public string DateMonth { get; set; }
        public int? DateDay { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? In1 { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? Out1 { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? In2 { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? Out2 { get; set; }
        [Column("OTIn", TypeName = "datetime")]
        public DateTime? Otin { get; set; }
        [Column("OTOut", TypeName = "datetime")]
        public DateTime? Otout { get; set; }
    }
}
