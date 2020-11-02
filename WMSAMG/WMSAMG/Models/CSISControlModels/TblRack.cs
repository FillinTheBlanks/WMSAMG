﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WMSAMG.Models.CSISControlModels
{
    [Table("tblRack")]
    public partial class TblRack
    {
        [Key]
        [Column("RackID")]
        public Guid RackId { get; set; }
        [StringLength(50)]
        public string RackName { get; set; }
        public int? LevelCapacity { get; set; }
        public int? AreaCapacity { get; set; }
        public bool? RackStatus { get; set; }
    }
}
