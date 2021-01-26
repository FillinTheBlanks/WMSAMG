using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WMSAMG.Models.CSISControlModels
{
    public partial class VwStorageRack
    {
        [Column("RackID")]
        public Guid RackId { get; set; }
        [StringLength(50)]
        public string RackName { get; set; }
        public int? LevelCapacity { get; set; }
        public int? AreaCapacity { get; set; }
        [Required]
        [StringLength(31)]
        public string RackCapacity { get; set; }
        public bool? RackStatus { get; set; }
    }
}
