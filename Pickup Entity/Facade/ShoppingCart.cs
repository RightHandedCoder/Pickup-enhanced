﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pickup_Entity
{
    public class ShoppingCart : Entity
    {
        [Required]
        public int ProductId { get; set; }
        public int Quantity { get; set; }
    }
}