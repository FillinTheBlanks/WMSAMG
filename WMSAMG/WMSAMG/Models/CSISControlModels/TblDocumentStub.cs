using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WMSAMG.Models.CSISControlModels
{
    [Table("tblDocumentStub")]
    public partial class TblDocumentStub
    {
        [Key]
        public Guid DocumentStubNo { get; set; }
        [StringLength(10)]
        public string Nature { get; set; }
        [Column("LocationID")]
        public Guid? LocationId { get; set; }
        [StringLength(10)]
        public string LocationInitial { get; set; }
        public int? StartWith { get; set; }
        public int? EndWith { get; set; }
        [Column("EmployeeID")]
        public Guid? EmployeeId { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? EmployeeDate { get; set; }
    }
}
