using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WMSAMG.Models.CSISControlModels
{
    [Table("tblStorageType")]
    public partial class TblStorageType
    {
        [Key]
        [Column("StorageTypeID")]
        [StringLength(50)]
        public string StorageTypeId { get; set; }
        [StringLength(50)]
        public string StorageTypeName { get; set; }
        public bool? StorageTypeStatus { get; set; }
    }
}
