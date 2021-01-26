using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WMSAMG.Models.CSISControlModels
{
    public partial class VwRequestorApprover
    {
        [Column("IDNo")]
        public Guid Idno { get; set; }
        [StringLength(104)]
        public string FullName { get; set; }
    }
}
