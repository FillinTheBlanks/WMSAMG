using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WMSAMG.Models.CSIS2017Models
{
    public partial class VwManpowerCharges
    {
        public Guid RefNum { get; set; }
        [StringLength(50)]
        public string ReferenceNo { get; set; }
        [Column("ManpowerID")]
        public Guid? ManpowerId { get; set; }
        [StringLength(100)]
        public string EmployeePosition { get; set; }
        [Column(TypeName = "money")]
        public decimal? FixedRate { get; set; }
        [Column(TypeName = "money")]
        public decimal? HourlyRate { get; set; }
        [Column(TypeName = "money")]
        public decimal? Qty { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? StartDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? StartTime { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? EndDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? EndTime { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? TransactionDate { get; set; }
        [Column("EmployeeID")]
        public Guid? EmployeeId { get; set; }
        [Column("LocationID")]
        public Guid? LocationId { get; set; }
    }
}
