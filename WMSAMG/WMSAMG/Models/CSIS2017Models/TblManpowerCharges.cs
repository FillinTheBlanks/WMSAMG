using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WMSAMG.Models.CSIS2017Models
{
    [Table("tblManpowerCharges")]
    public partial class TblManpowerCharges
    {
        [Key]
        public Guid RefNum { get; set; }
        [StringLength(50)]
        public string ReferenceNo { get; set; }
        [Column("ManpowerID")]
        public Guid? ManpowerId { get; set; }
        [Column(TypeName = "money")]
        public decimal? Qty { get; set; }
        [Column(TypeName = "money")]
        public decimal? FixedRate { get; set; }
        [Column(TypeName = "money")]
        public decimal? HourlyRate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? StartDateTime { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? EndDateTime { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? TransactionDate { get; set; }
        [Column("EmployeeID")]
        public Guid? EmployeeId { get; set; }
        [Column("LocationID")]
        public Guid? LocationId { get; set; }
    }
}
