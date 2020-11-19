using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WMSAMG.Models.CSISControlModels
{
    [Table("tblStock")]
    public partial class TblStock
    {
        public List<SelectListItem> Companies { get; set; }
        public List<SelectListItem> Customers { get; set; }
        [Key]
        [Column("StockID")]
        public Guid StockId { get; set; }
        [Column("StockSKU")]
        [StringLength(100)]
        [Required]
        //[Range(3,200,ErrorMessage ="Should be more than 3 characters")]
        public string StockSku { get; set; }
        [StringLength(200)]
        [Required]
        public string StockDescription { get; set; }
        [Column("StockGroupID")]
        public Guid? StockGroupId { get; set; }
        [Column(TypeName = "money")]
        public decimal? StockPcsperPack { get; set; }
        [Column(TypeName = "money")]
        public decimal? StockPackperCase { get; set; }
        [Column(TypeName = "money")]
        public decimal? StockWeightinKilosperPack { get; set; }
        [Column(TypeName = "money")]
        public decimal? StockWeightinKilosperCase { get; set; }
        public int? ShelfLifeinDays { get; set; }
        [Column("CustomerID")]
        [StringLength(50)]
        public string CustomerId { get; set; }
        [Column("CompanyID")]
        public Guid? CompanyId { get; set; }
        public bool? StockStatus { get; set; }
    }
}
