using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WMSAMG.Models.CSISControlModels
{
    public partial class VwCustomerPersonnel
    {
        [Column("CustomerPersonnelID")]
        public Guid CustomerPersonnelId { get; set; }
        [Column("CustomerID")]
        [StringLength(50)]
        public string CustomerId { get; set; }
        [StringLength(100)]
        public string CustomerName { get; set; }
        [StringLength(100)]
        public string CustomerAddress { get; set; }
        [StringLength(50)]
        public string CustomerPersonnelFirstName { get; set; }
        [StringLength(50)]
        public string CustomerPersonnelMiddleName { get; set; }
        [StringLength(50)]
        public string CustomerPersonnelLastName { get; set; }
        [Required]
        [StringLength(101)]
        public string FullName { get; set; }
        [StringLength(50)]
        public string CustomerPersonnelPosition { get; set; }
        [StringLength(50)]
        public string CustomerPersonnelContact { get; set; }
    }
}
