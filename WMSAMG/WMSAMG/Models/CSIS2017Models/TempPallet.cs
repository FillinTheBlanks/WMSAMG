using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
