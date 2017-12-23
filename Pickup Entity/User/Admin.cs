using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pickup_Entity
{
    public class Admin : User
    {
        [Required]
        public int DepartmentId { get; set; }
        public int Salary { get; set; }
        public string DepartmentName { get; set; }
    }
}
