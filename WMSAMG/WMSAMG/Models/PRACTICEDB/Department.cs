using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WMSAMG.Models.PRACTICEDB
{
    public partial class Department
    {
        public Department()
        {
            Employee = new HashSet<Employee>();
        }

        [Key]
        [Column("Dept_Code")]
        public int DeptCode { get; set; }
        [Column("Dept_Name")]
        [StringLength(50)]
        public string DeptName { get; set; }

        [InverseProperty("DeptCodeNavigation")]
        public virtual ICollection<Employee> Employee { get; set; }
    }
}
