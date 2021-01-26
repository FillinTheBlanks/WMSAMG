using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WMSAMG.Models.CSISControlModels
{
    public partial class VwPallet
    {
        [Required]
        [StringLength(10)]
        public string PalletNo { get; set; }
        [StringLength(50)]
        public string PalletDescription { get; set; }
        [StringLength(50)]
        public string PalletType { get; set; }
        [Column("LocationID")]
        public Guid? LocationId { get; set; }
        [StringLength(50)]
        public string LocationDescription { get; set; }
        [StringLength(10)]
        public string LocationInitial { get; set; }
        [Column("CompanyID")]
        public Guid? CompanyId { get; set; }
        [StringLength(100)]
        public string CompanyName { get; set; }
        [StringLength(10)]
        public string CompanyInitial { get; set; }
    }
}
