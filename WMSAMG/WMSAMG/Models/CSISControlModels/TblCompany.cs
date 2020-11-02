using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WMSAMG.Models.CSISControlModels
{
    [Table("tblCompany")]
    public partial class TblCompany
    {
        [Key]
        [Column("CompanyID")]
        public Guid CompanyId { get; set; }
        [StringLength(100)]
        public string CompanyName { get; set; }
        [StringLength(10)]
        public string CompanyInitial { get; set; }
        [StringLength(200)]
        public string CompanyAddress { get; set; }
        public bool? CompanyStatus { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? OfficeHourTimeIn { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? OfficeHourTimeOut { get; set; }
    }
}
