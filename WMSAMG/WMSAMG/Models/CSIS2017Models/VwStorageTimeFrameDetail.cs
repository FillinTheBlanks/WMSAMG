using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WMSAMG.Models.CSIS2017Models
{
    public partial class VwStorageTimeFrameDetail
    {
        [Column("StorageTimeFrameID")]
        public Guid StorageTimeFrameId { get; set; }
        public Guid? RefCode { get; set; }
        [StringLength(50)]
        public string ReferenceNo { get; set; }
        [Column("CustomerID")]
        [StringLength(50)]
        public string CustomerId { get; set; }
        [StringLength(5)]
        public string PayTypeInitial { get; set; }
        [Column(TypeName = "decimal(18, 4)")]
        public decimal? ActualWeight { get; set; }
        [StringLength(10)]
        public string Nature { get; set; }
        [Column("StorageLocationID")]
        public Guid? StorageLocationId { get; set; }
        [StringLength(153)]
        public string StorageLocationName { get; set; }
        [Column("StorageID")]
        public Guid? StorageId { get; set; }
        [Column("StorageTypeID")]
        [StringLength(50)]
        public string StorageTypeId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DateTimeFrameFrom { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime DateTimeFrameTo { get; set; }
        [Column(TypeName = "money")]
        public decimal? FixedRate { get; set; }
        [Column(TypeName = "money")]
        public decimal? HourlyRate { get; set; }
        public int? TotalHours { get; set; }
        public int? TotalDays { get; set; }
        [Column(TypeName = "money")]
        public decimal? FixedRateperDay { get; set; }
        [Column(TypeName = "money")]
        public decimal? FixedRateAmount { get; set; }
        [Column(TypeName = "decimal(38, 6)")]
        public decimal? HourlyRateAmount { get; set; }
    }
}
