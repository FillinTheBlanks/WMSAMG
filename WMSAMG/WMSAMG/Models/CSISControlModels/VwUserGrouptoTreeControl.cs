using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WMSAMG.Models.CSISControlModels
{
    public partial class VwUserGrouptoTreeControl
    {
        [Column("UserGroupID")]
        public int? UserGroupId { get; set; }
        [StringLength(100)]
        public string UserGroupName { get; set; }
        [StringLength(100)]
        public string UserRole { get; set; }
        [Column("TreeID")]
        public int? TreeId { get; set; }
        [StringLength(100)]
        public string TreeName { get; set; }
        [StringLength(10)]
        public string ParentChild { get; set; }
        public int? ArrangeOrder { get; set; }
        [Column("ParentTreeID")]
        [StringLength(100)]
        public string ParentTreeId { get; set; }
        [StringLength(10)]
        public string Status { get; set; }
        [StringLength(100)]
        public string NavGroupDesc { get; set; }
        public bool? CanAccess { get; set; }
        public bool? CanAdd { get; set; }
        public bool? CanEdit { get; set; }
        public bool? CanDelete { get; set; }
        public bool? CanPrint { get; set; }
    }
}
