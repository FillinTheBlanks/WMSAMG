using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WMSAMG.Models.CSISControlModels
{
    public partial class VwNavGroup
    {
        [StringLength(100)]
        public string NavGroupDesc { get; set; }
    }
}
