using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WMSAMG.Models.CSISControlModels
{
    [Table("tblPermissionSet")]
    public partial class TblPermissionSet
    {
        [Key]
        public Guid No { get; set; }
        [Column("UserGroupID")]
        public int? UserGroupId { get; set; }
        [Column("TreeID")]
        public int? TreeId { get; set; }
        public bool? CanAccess { get; set; }
        public bool? CanAdd { get; set; }
        public bool? CanEdit { get; set; }
        public bool? CanDelete { get; set; }
        public bool? CanPrint { get; set; }
    }
}
