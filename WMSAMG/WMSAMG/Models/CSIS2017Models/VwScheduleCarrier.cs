using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WMSAMG.Models.CSIS2017Models
{
    public partial class VwScheduleCarrier
    {
        public Guid ReferenceCode { get; set; }
        [Column("CustomerID")]
        [StringLength(50)]
        public string CustomerId { get; set; }
        [StringLength(100)]
        public string CustomerName { get; set; }
        [StringLength(5)]
        public string PayTypeInitial { get; set; }
        [Column("CompanyID")]
        public Guid? CompanyId { get; set; }
        [StringLength(100)]
        public string CompanyName { get; set; }
        [StringLength(10)]
        public string CompanyInitial { get; set; }
        [Column("LocationID")]
        public Guid? LocationId { get; set; }
        [StringLength(50)]
        public string LocationDescription { get; set; }
        [StringLength(10)]
        public string LocationInitial { get; set; }
        [Column(TypeName = "date")]
        public DateTime? DateSchedule { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? TimeSchedule { get; set; }
        [Column("isActive")]
        public bool? IsActive { get; set; }
        public Guid? ApprovedBy { get; set; }
        public Guid? EncodedBy { get; set; }
        [Column(TypeName = "date")]
        public DateTime? DateEncoded { get; set; }
    }
}
