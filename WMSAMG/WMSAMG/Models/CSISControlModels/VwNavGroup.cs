using System.ComponentModel.DataAnnotations;

namespace WMSAMG.Models.CSISControlModels
{
    public partial class VwNavGroup
    {
        [StringLength(100)]
        public string NavGroupDesc { get; set; }
    }
}
