using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WMSAMG.Models.CSIS2017Models
{
    [Table("tblChargingLogs")]
    public partial class TblChargingLogs
    {
        [Key]
        public Guid RefNum { get; set; }
        [Column("RRNumber")]
        [StringLength(50)]
        public string Rrnumber { get; set; }
        [StringLength(50)]
        public string ReferenceNo { get; set; }
        public Guid? ChargeRefNum { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LogDate { get; set; }
    }
}
