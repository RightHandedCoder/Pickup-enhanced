using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Pickup.Models
{
    public class BuyerRegistrationViewModel
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
        public string Address { get; set; }
        [Required]
        public string AreaId { get; set; }
        public string AreaName { get; set; }
        [Required]
        public string Username { get; set; }
        [Required,DataType("Password")]
        public string Password { get; set; }
    }
}