using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WMSAMG.Models.CSIS2017Models
{
    [Table("tblBillingStatementRecord")]
    public partial class TblBillingStatementRecord
    {
        [Key]
        public Guid No { get; set; }
        [StringLength(50)]
        public string BillingNo { get; set; }
        [StringLength(50)]
        public string ReferenceNo { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DateBilling { get; set; }
    }
}
