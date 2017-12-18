using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pickup_Entity
{
    public class Product : Entity
    {
        [Required]
        public string ProductName { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public int SellerId { get; set; }
    }
}
