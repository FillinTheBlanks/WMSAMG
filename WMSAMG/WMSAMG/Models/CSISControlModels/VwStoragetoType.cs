using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WMSAMG.Models.CSISControlModels
{
    public partial class VwStoragetoType
    {
        [Column("StorageID")]
        public Guid StorageId { get; set; }
        [Required]
        [Column("StorageTypeID")]
        [StringLength(50)]
        public string StorageTypeId { get; set; }
        [StringLength(50)]
        public string StorageTypeName { get; set; }
        [Required]
        [StringLength(100)]
        public string StorageName { get; set; }
        [Column(TypeName = "money")]
        public decimal FixedRate { get; set; }
        [Column(TypeName = "money")]
        public decimal HourlyRate { get; set; }
        [Column("CompanyID")]
        public Guid CompanyId { get; set; }
        [StringLength(10)]
        public string CompanyInitial { get; set; }
        [StringLength(100)]
        public string CompanyName { get; set; }
        public bool StorageStatus { get; set; }
    }
}
