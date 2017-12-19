using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pickup_Entity
{
    public class Catagory : Entity
    {
        [Required]
        public string CatagoryName { get; set; }
    }
}
