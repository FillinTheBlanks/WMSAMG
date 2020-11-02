using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WMSAMG.Models.CSISControlModels
{
    [Table("tblUserGroup")]
    public partial class TblUserGroup
    {
        [Key]
        [Column("UserGroupID")]
        public int UserGroupId { get; set; }
        [StringLength(100)]
        public string UserGroupName { get; set; }
        [StringLength(100)]
        public string UserRole { get; set; }
    }
}
