using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WMSAMG.Models.CSIS2017Models
{
    [Table("tblDashboardDefault")]
    public partial class TblDashboardDefault
    {
        public string DashboardPath { get; set; }
        [StringLength(100)]
        public string DashboardTitle { get; set; }
        public bool? Status { get; set; }
    }
}
