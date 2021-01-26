using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WMSAMG.Models.CSISControlModels
{
    public partial class VwCustomertoPersonnel
    {
        [StringLength(10)]
        public string CustomerEmail { get; set; }
        [Column("CompanyID")]
        [StringLength(10)]
        public string CompanyId { get; set; }
        [Column("CustomerID")]
        [StringLength(10)]
        public string CustomerId { get; set; }
        [StringLength(10)]
        public string Expr1 { get; set; }
    }
}
