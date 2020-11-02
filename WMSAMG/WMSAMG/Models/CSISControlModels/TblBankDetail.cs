using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WMSAMG.Models.CSISControlModels
{
    [Table("tblBankDetail")]
    public partial class TblBankDetail
    {
        [StringLength(100)]
        public string AccountNo { get; set; }
        [StringLength(50)]
        public string BankInitial { get; set; }
        [StringLength(100)]
        public string BankName { get; set; }
        [Column("CompanyID")]
        public Guid? CompanyId { get; set; }
    }
}
