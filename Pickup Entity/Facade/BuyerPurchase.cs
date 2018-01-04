using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pickup_Entity
{
    public class BuyerPurchase : Entity
    {
        [Required]
        public int BuyerId { get; set; }
        [Required]
        public int ProductId { get; set; }
        [Required]
        public string Date { get; set; }
        [NotMapped]
        public string BuyerName { get; set; }
        [NotMapped]
        public string ProductName { get; set; }
    }
}
