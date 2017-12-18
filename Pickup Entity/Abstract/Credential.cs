using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pickup_Entity
{
    public abstract class Credential : Entity
    {
        [Required]
        public string Username { get; set; }
        [Required,MinLength(4)]
        public string Password { get; set; }
        public bool Status { get; set; }
    }
}
