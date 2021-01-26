using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WMSAMG.Models.CSISControlModels
{
    [Table("tblPallet")]
    public partial class TblPallet
    {
        [Key]
        [StringLength(10)]
        public string PalletNo { get; set; }
        [StringLength(50)]
        public string PalletDescription { get; set; }
        [StringLength(50)]
        public string PalletType { get; set; }
        [Column("CompanyID")]
        public Guid? CompanyId { get; set; }
        [Column("LocationID")]
        public Guid? LocationId { get; set; }
    }
}
