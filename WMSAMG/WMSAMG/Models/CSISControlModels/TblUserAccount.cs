using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WMSAMG.Models.CSISControlModels
{
    [Table("tblUserAccount")]
    public partial class TblUserAccount
    {
        [Key]
        [Column("UserID")]
        public Guid UserId { get; set; }
        [Key]
        [Column("UserGroupID")]
        public int UserGroupId { get; set; }
        [Column("EmployeeID")]
        public Guid? EmployeeId { get; set; }
        [StringLength(20)]
        public string Username { get; set; }
        [StringLength(64)]
        public string UserPassword { get; set; }
        [Column("CompanyID")]
        public Guid? CompanyId { get; set; }
        [Column("LocationID")]
        public Guid? LocationId { get; set; }
        public bool? UserStatus { get; set; }
    }
}
