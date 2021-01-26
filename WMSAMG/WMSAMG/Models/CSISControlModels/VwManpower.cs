using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WMSAMG.Models.CSISControlModels
{
    public partial class VwManpower
    {
        [Column("ManpowerID")]
        public Guid ManpowerId { get; set; }
        [StringLength(100)]
        public string EmployeePosition { get; set; }
        [Column(TypeName = "money")]
        public decimal? FixedRate { get; set; }
        [Column(TypeName = "money")]
        public decimal? HourlyRate { get; set; }
        [Column("LocationID")]
        public Guid? LocationId { get; set; }
        [StringLength(50)]
        public string LocationDescription { get; set; }
        [StringLength(10)]
        public string LocationInitial { get; set; }
        [Column("CompanyID")]
        public Guid? CompanyId { get; set; }
        [StringLength(10)]
        public string CompanyInitial { get; set; }
        [StringLength(100)]
        public string CompanyName { get; set; }
        [StringLength(100)]
        public string Remarks { get; set; }
        public bool? ManpowerStatus { get; set; }
    }
}
