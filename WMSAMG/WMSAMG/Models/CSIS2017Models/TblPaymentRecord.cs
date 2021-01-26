using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WMSAMG.Models.CSIS2017Models
{
    [Table("tblPaymentRecord")]
    public partial class TblPaymentRecord
    {
        [Key]
        public Guid PaymentNo { get; set; }
        [StringLength(50)]
        public string InvoiceNo { get; set; }
        [Column("CustomerID")]
        [StringLength(50)]
        public string CustomerId { get; set; }
        [StringLength(50)]
        public string BillingNo { get; set; }
        [StringLength(50)]
        public string BankInitial { get; set; }
        [StringLength(50)]
        public string TransactionType { get; set; }
        [Column(TypeName = "money")]
        public decimal? Amount { get; set; }
        [StringLength(100)]
        public string Remarks { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DateTransaction { get; set; }
        [Column("EmployeeID")]
        public Guid? EmployeeId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? DateEncoded { get; set; }
        [Column("LocationID")]
        public Guid? LocationId { get; set; }
    }
}
