﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WMSAMG.Models.CSIS2017Models
{
    [Table("tblStorageTimeFrame")]
    public partial class TblStorageTimeFrame
    {
        [Key]
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
        [StringLength(10)]
        public string Nature { get; set; }
        [Column("StorageLocationID")]
        public Guid? StorageLocationId { get; set; }
        [Column("StorageID")]
        public Guid? StorageId { get; set; }
        [Column("StorageTypeID")]
        [StringLength(50)]
        public string StorageTypeId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DateTimeFrameFrom { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DateTimeFrameTo { get; set; }
        [Column(TypeName = "money")]
        public decimal? FixedRate { get; set; }
        [Column(TypeName = "money")]
        public decimal? HourlyRate { get; set; }
    }
}