using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WMSAMG.Models.CSIS2017Models
{
    public partial class VwReceivingDetail
    {
        public Guid ReferenceCode { get; set; }
        [Column("RRCode")]
        [StringLength(50)]
        public string Rrcode { get; set; }
        [Column("RRNumber")]
        [StringLength(50)]
        public string Rrnumber { get; set; }
        public Guid? CarrierReferenceCode { get; set; }
        [Column("CustomerID")]
        [StringLength(50)]
        public string CustomerId { get; set; }
        [StringLength(100)]
        public string CustomerName { get; set; }
        [StringLength(5)]
        public string PayTypeInitial { get; set; }
        [Column("StockID")]
        public Guid? StockId { get; set; }
        [StringLength(200)]
        public string StockDescription { get; set; }
        [Column("StockSKU")]
        [StringLength(100)]
        public string StockSku { get; set; }
        [Column("StockGroupID")]
        public Guid? StockGroupId { get; set; }
        [Column(TypeName = "money")]
        public decimal? StockPcsperPack { get; set; }
        [Column(TypeName = "money")]
        public decimal? StockPackperCase { get; set; }
        [Column(TypeName = "money")]
        public decimal? Qty { get; set; }
        [Column(TypeName = "decimal(18, 4)")]
        public decimal? ActualWeight { get; set; }
        [Column("UOM")]
        [StringLength(3)]
        public string Uom { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? ReceivingTime { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? EndTime { get; set; }
        [StringLength(500)]
        public string Remarks { get; set; }
        [Column(TypeName = "money")]
        public decimal? StockWeightinKilosperPack { get; set; }
        [Column(TypeName = "money")]
        public decimal? StockWeightinKilosperCase { get; set; }
        [StringLength(10)]
        public string PalletNo { get; set; }
        [Column("StorageLocationID")]
        public Guid? StorageLocationId { get; set; }
        [StringLength(153)]
        public string StorageLocationName { get; set; }
        [StringLength(100)]
        public string StorageName { get; set; }
        [Column("StorageID")]
        public Guid? StorageId { get; set; }
        [Column("StorageTypeID")]
        [StringLength(50)]
        public string StorageTypeId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? TransactionDate { get; set; }
        [StringLength(10)]
        public string Nature { get; set; }
        [StringLength(10)]
        public string Source { get; set; }
        [Column("EmployeeID")]
        public Guid? EmployeeId { get; set; }
        [StringLength(104)]
        public string Encoder { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? EmployeeDate { get; set; }
        public Guid? ApprovedBy { get; set; }
        [StringLength(104)]
        public string Approver { get; set; }
        [Column("isSaved")]
        public bool? IsSaved { get; set; }
        [Column("CompanyID")]
        public Guid? CompanyId { get; set; }
        [StringLength(10)]
        public string CompanyInitial { get; set; }
        [StringLength(100)]
        public string CompanyName { get; set; }
        [Column("LocationID")]
        public Guid? LocationId { get; set; }
        [StringLength(10)]
        public string LocationInitial { get; set; }
        [StringLength(50)]
        public string LocationDescription { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DateTimeFrameFrom { get; set; }
        [Column(TypeName = "date")]
        public DateTime? DateSchedule { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? TimeSchedule { get; set; }
    }
}
