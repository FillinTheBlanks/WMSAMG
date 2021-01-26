using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WMSAMG.Models.CSISControlModels
{
    [Table("tblLocation")]
    public partial class TblLocation
    {
        [Key]
        [Column("LocationID")]
        public Guid LocationId { get; set; }
        [StringLength(50)]
        public string LocationDescription { get; set; }
        [StringLength(10)]
        public string LocationInitial { get; set; }
        [Column("CompanyID")]
        public Guid? CompanyId { get; set; }
    }
}
