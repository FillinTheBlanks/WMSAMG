using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WMSAMG.Models.CSIS2017Models
{
    [Table("tblLogs")]
    public partial class TblLogs
    {
        [Key]
        [Column("LogID")]
        public Guid LogId { get; set; }
        public string LogDesc { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? LogDateTime { get; set; }
        [StringLength(50)]
        public string LogUser { get; set; }
    }
}
