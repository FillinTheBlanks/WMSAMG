using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WMSAMG.Models.CSIS2017Models
{
    [Table("tblReceivingDetail_Deleted")]
    public partial class TblReceivingDetailDeleted
    {
        public Guid ReferenceCode { get; set; }
        [Column("RRCode")]
        [StringLength(50)]
        public string Rrcode { get; set; }
        public Guid? CarrierReferenceCode { get; set; }
        [Column("CustomerID")]
        [StringLength(50)]
        public string CustomerId { get; set; }
        [StringLength(5)]
        public string PayTypeInitial { get; set; }
        [Column("StockID")]
        public Guid? StockId { get; set; }
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
        [Column(TypeName = "money")]
        public decimal? StockWeightinKilosperPack { get; set; }
        [Column(TypeName = "money")]
        public decimal? StockWeightinKilosperCase { get; set; }
        [StringLength(10)]
        public string PalletNo { get; set; }
        [Column("CompanyID")]
        public Guid? CompanyId { get; set; }
        [Column("StorageLocationID")]
        public Guid? StorageLocationId { get; set; }
        [Column("StorageID")]
        public Guid? StorageId { get; set; }
        [Column("StorageTypeID")]
        [StringLength(50)]
        public string StorageTypeId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? TransactionDate { get; set; }
        [Column("LocationID")]
        public Guid? LocationId { get; set; }
        [StringLength(10)]
        public string Nature { get; set; }
        [StringLength(10)]
        public string Source { get; set; }
        [StringLength(500)]
        public string Remarks { get; set; }
        public Guid? ApprovedBy { get; set; }
        [Column("EmployeeID")]
        public Guid? EmployeeId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? EmployeeDate { get; set; }
        [Column("isSaved")]
        public bool? IsSaved { get; set; }
    }
}
