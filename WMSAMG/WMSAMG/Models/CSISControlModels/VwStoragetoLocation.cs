using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WMSAMG.Models.CSISControlModels
{
    public partial class VwStoragetoLocation
    {
        [Column("StorageLocationID")]
        public Guid StorageLocationId { get; set; }
        [StringLength(50)]
        public string StorageLocationName { get; set; }
        [Column("StorageID")]
        public Guid? StorageId { get; set; }
        [StringLength(100)]
        public string StorageName { get; set; }
        [Column("StorageTypeID")]
        [StringLength(50)]
        public string StorageTypeId { get; set; }
        [Required]
        [StringLength(50)]
        public string SerialNo { get; set; }
        [Column("RackID")]
        public Guid? RackId { get; set; }
        [StringLength(50)]
        public string RackName { get; set; }
        [StringLength(47)]
        public string RackCapacity { get; set; }
        public int? RackNo { get; set; }
        public int? LevelNo { get; set; }
        public int? AreaNo { get; set; }
        [Column("CompanyID")]
        public Guid? CompanyId { get; set; }
        [StringLength(10)]
        public string CompanyInitial { get; set; }
        [StringLength(100)]
        public string CompanyName { get; set; }
        [Column("LocationID")]
        public Guid? LocationId { get; set; }
        [StringLength(50)]
        public string LocationDescription { get; set; }
        public bool? StorageLocationStatus { get; set; }
        public Guid? ApprovedBy { get; set; }
        [StringLength(104)]
        public string Approver { get; set; }
        public Guid? EncodedBy { get; set; }
        [StringLength(104)]
        public string Encoder { get; set; }
        [Column(TypeName = "date")]
        public DateTime? DateEncoded { get; set; }
        [Column(TypeName = "money")]
        public decimal? FixedRate { get; set; }
        [Column(TypeName = "money")]
        public decimal? HourlyRate { get; set; }
    }
}
