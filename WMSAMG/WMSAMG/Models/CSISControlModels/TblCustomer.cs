using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WMSAMG.Models.CSISControlModels
{
    [Table("tblCustomer")]
    public partial class TblCustomer
    {
        [Key]
        [Column("CustomerID")]
        [StringLength(50)]
        public string CustomerId { get; set; }
        [StringLength(100)]
        public string CustomerName { get; set; }
        [StringLength(100)]
        public string CustomerAddress { get; set; }
        [StringLength(5)]
        public string PayTypeInitial { get; set; }
        [Column("CompanyID")]
        public Guid? CompanyId { get; set; }
        [Column("LocationID")]
        public Guid? LocationId { get; set; }
        [StringLength(50)]
        public string CustomerEmail { get; set; }
        public bool? CustomerStatus { get; set; }
    }
}
