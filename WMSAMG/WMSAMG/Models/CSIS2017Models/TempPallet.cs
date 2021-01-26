using System.ComponentModel.DataAnnotations;

namespace WMSAMG.Models.CSIS2017Models
{
    public partial class TempPallet
    {
        [StringLength(4000)]
        public string PalletNo { get; set; }
        [StringLength(4000)]
        public string PalletDescription { get; set; }
        [Required]
        [StringLength(17)]
        public string PalletType { get; set; }
    }
}
