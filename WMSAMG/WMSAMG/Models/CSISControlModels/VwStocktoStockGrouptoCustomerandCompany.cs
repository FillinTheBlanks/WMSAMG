using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WMSAMG.Models.CSISControlModels
{
    public partial class VwStocktoStockGrouptoCustomerandCompany
    {
        [Column("StockID")]
        public Guid StockId { get; set; }
        [Column("StockSKU")]
        [StringLength(100)]
        public string StockSku { get; set; }
        [StringLength(200)]
        public string StockDescription { get; set; }
        [Column(TypeName = "money")]
        public decimal? StockPackperCase { get; set; }
        [Column(TypeName = "money")]
        public decimal? StockPcsperPack { get; set; }
        [Column(TypeName = "money")]
        public decimal? StockWeightinKilosperCase { get; set; }
        [Column(TypeName = "money")]
        public decimal? StockWeightinKilosperPack { get; set; }
        public int? ShelfLifeinDays { get; set; }
        public bool? StockStatus { get; set; }
        [Column("StockGroupID")]
        public Guid? StockGroupId { get; set; }
        [StringLength(50)]
        public string StockGroupCategory { get; set; }
        [StringLength(50)]
        public string StockGroupSpecie { get; set; }
        [Column("CustomerID")]
        [StringLength(50)]
        public string CustomerId { get; set; }
        [StringLength(100)]
        public string CustomerName { get; set; }
        [StringLength(100)]
        public string CustomerAddress { get; set; }
        [Column("CompanyID")]
        public Guid? CompanyId { get; set; }
        [StringLength(100)]
        public string CompanyName { get; set; }
        [StringLength(10)]
        public string CompanyInitial { get; set; }
        [StringLength(200)]
        public string CompanyAddress { get; set; }
    }
}
