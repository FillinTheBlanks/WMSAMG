using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WMSAMG.Models.CSISControlModels
{
    [Table("tblNature")]
    public partial class TblNature
    {
        [Key]
        [StringLength(10)]
        public string Nature { get; set; }
        [StringLength(50)]
        public string NatureDescription { get; set; }
        public int? Signed { get; set; }
    }
}
