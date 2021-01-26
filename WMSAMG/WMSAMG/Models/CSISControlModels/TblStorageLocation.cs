using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WMSAMG.Models.CSISControlModels
{
    [Table("tblStorageLocation")]
    public partial class TblStorageLocation
    {
        [Key]
        [Column("StorageLocationID")]
        public Guid StorageLocationId { get; set; }
        [StringLength(50)]
        public string StorageLocationName { get; set; }
        [Column("StorageID")]
        public Guid? StorageId { get; set; }
        [StringLength(50)]
        public string SerialNo { get; set; }
        [Column("RackID")]
        public Guid? RackId { get; set; }
        public int? RackNo { get; set; }
        public int? LevelNo { get; set; }
        public int? AreaNo { get; set; }
        [Column("CompanyID")]
        public Guid? CompanyId { get; set; }
        [Column("LocationID")]
        public Guid? LocationId { get; set; }
        public Guid? ApprovedBy { get; set; }
        public Guid? EncodedBy { get; set; }
        [Column(TypeName = "date")]
        public DateTime? DateEncoded { get; set; }
        public bool? StorageLocationStatus { get; set; }
    }
}
