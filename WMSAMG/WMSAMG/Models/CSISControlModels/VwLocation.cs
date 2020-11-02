using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WMSAMG.Models.CSISControlModels
{
    public partial class VwLocation
    {
        [Column("LocationID")]
        public Guid LocationId { get; set; }
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
        [Column(TypeName = "datetime")]
        public DateTime? OfficeHourTimeIn { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? OfficeHourTimeOut { get; set; }
    }
}
