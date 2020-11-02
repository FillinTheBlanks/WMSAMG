using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WMSAMG.Models.CSISControlModels
{
    [Table("tblManpower")]
    public partial class TblManpower
    {
        [Key]
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
        [Column("CompanyID")]
        public Guid? CompanyId { get; set; }
        [StringLength(100)]
        public string Remarks { get; set; }
        public bool? ManpowerStatus { get; set; }
    }
}
