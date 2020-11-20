using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WMSAMG.Models.CSIS2017Models
{
    public partial class VwMasterTransactions
    {
        public Guid RefCode { get; set; }
        [StringLength(50)]
        public string ReferenceNo { get; set; }
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
        public decimal? Qty { get; set; }
        [Column(TypeName = "numeric(18, 4)")]
        public decimal? ActualWeight { get; set; }
        [Column("UOM")]
        [StringLength(3)]
        public string Uom { get; set; }
        public int? Signed { get; set; }
        [Column(TypeName = "date")]
        public DateTime? ProductionDate { get; set; }
        [StringLength(10)]
        public string PalletNo { get; set; }
        [Column("CompanyID")]
        public Guid? CompanyId { get; set; }
        [Column("StorageLocationID")]
        public Guid? StorageLocationId { get; set; }
        [StringLength(50)]
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
        [StringLength(10)]
        public string CompanyInitial { get; set; }
        [StringLength(10)]
        public string LocationInitial { get; set; }
        [Column("isSaved")]
        public bool? IsSaved { get; set; }
    }
}
