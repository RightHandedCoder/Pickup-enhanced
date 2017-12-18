using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pickup_Entity
{
    public class Department : Entity
    {
        [Required]
        public string DepartmentName { get; set; }
        [Required]
        public int DepartmentLocation { get; set; }
    }
}
