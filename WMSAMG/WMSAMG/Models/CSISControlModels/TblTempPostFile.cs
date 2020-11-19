﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WMSAMG.Models.CSISControlModels
{
    [Table("tblTempPostFile")]
    public partial class TblTempPostFile
    {
        [StringLength(8)]
        public string YearQtrWk { get; set; }
        public int? Year { get; set; }
        public int? Quarter { get; set; }
        public int? Week { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? StartDate { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? EndDate { get; set; }
        public bool? Status { get; set; }
        [StringLength(50)]
        public string Username { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? UserDate { get; set; }
    }
}