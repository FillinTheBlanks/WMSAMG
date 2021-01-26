using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WMSAMG.Models.CSIS2017Models
{
    [Table("tblTruckDetails")]
    public partial class TblTruckDetails
    {
        [Key]
        [Column("RefID")]
        public Guid RefId { get; set; }
        public Guid? CarrierReferenceCode { get; set; }
        [StringLength(50)]
        public string TruckPlateNo { get; set; }
        [StringLength(50)]
        public string Color { get; set; }
        [StringLength(50)]
        public string Type { get; set; }
        [Column("CustomerPersonnelID")]
        public Guid? CustomerPersonnelId { get; set; }
        [StringLength(50)]
        public string CustomerPersonnelFirstName { get; set; }
        [StringLength(50)]
        public string CustomerPersonnelMiddleName { get; set; }
        [StringLength(50)]
        public string CustomerPersonnelLastName { get; set; }
        [StringLength(50)]
        public string CustomerPersonnelPosition { get; set; }
        public bool? Status { get; set; }
    }
}
