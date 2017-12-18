using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pickup_Entity
{
    public class Area : Entity
    {
        [Required]
        public string AreaName { get; set; }
    }
}
