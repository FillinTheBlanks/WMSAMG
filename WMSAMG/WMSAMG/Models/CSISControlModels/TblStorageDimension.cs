using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WMSAMG.Models.CSISControlModels
{
    [Table("tblStorageDimension")]
    public partial class TblStorageDimension
    {
        [Key]
        [StringLength(10)]
        public string StorageDimensionInitial { get; set; }
        [StringLength(50)]
        public string StorageDimensionName { get; set; }
        [Column(TypeName = "money")]
        public decimal? StorageDimensionQty { get; set; }
        public bool? StorageDimensionStatus { get; set; }
    }
}
