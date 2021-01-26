using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WMSAMG.Models.CSIS2017Models
{
    [Table("tblBMIPList")]
    public partial class TblBmiplist
    {
        [Column("IPAddress")]
        [StringLength(15)]
        public string Ipaddress { get; set; }
        [Column("IPPort")]
        [StringLength(6)]
        public string Ipport { get; set; }
    }
}
