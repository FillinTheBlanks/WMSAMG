using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WMSAMG.Models.CSISControlModels
{
    [Table("tblNavGroup")]
    public partial class TblNavGroup
    {
        [StringLength(100)]
        public string NavGroupDesc { get; set; }
    }
}
