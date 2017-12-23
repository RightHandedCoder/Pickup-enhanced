using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Pickup
{
    public class SellerViewModel
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string Email { get; set; }
        [Required, MaxLength(12), MinLength(11)]
        public string Phone { get; set; }
        [Required]
        public string ShopName { get; set; }
        [Required]
        public int AreaId { get; set; }
        [NotMapped]
        public string AreaName { get; set; }
        [Required]
        public string Username { get; set; }
        [Required, MinLength(4)]
        public string Password { get; set; }
    }
}