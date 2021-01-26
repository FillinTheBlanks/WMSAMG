using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WMSAMG.Models.CSISControlModels
{
    [Table("tblCustomerPersonnel")]
    public partial class TblCustomerPersonnel
    {
        [Key]
        [Column("CustomerPersonnelID")]
        public Guid CustomerPersonnelId { get; set; }
        [StringLength(50)]
        public string CustomerPersonnelFirstName { get; set; }
        [StringLength(50)]
        public string CustomerPersonnelMiddleName { get; set; }
        [StringLength(50)]
        public string CustomerPersonnelLastName { get; set; }
        [StringLength(50)]
        public string CustomerPersonnelPosition { get; set; }
        [StringLength(50)]
        public string CustomerPersonnelContact { get; set; }
        [Column("CustomerID")]
        [StringLength(50)]
        public string CustomerId { get; set; }
    }
}
