using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pickup_Entity
{
    public class Admin : User
    {
        [Required]
        public int DepartmentId { get; set; }
        [NotMapped]
        public string DepartmentName { get; set; }
    }
}
