using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WMSAMG.Models.CSISControlModels
{
    public partial class VwUserAccounttoEmployeetoGrouptoTree
    {
        [Column("CompanyID")]
        [StringLength(10)]
        public string CompanyId { get; set; }
        [StringLength(10)]
        public string Expr1 { get; set; }
        [Column("TreeID")]
        [StringLength(10)]
        public string TreeId { get; set; }
        [StringLength(10)]
        public string Expr2 { get; set; }
        [Column("UserGroupID")]
        [StringLength(10)]
        public string UserGroupId { get; set; }
        [StringLength(10)]
        public string Expr3 { get; set; }
        [Column("EmployeeID")]
        [StringLength(10)]
        public string EmployeeId { get; set; }
        [StringLength(10)]
        public string Expr4 { get; set; }
    }
}
