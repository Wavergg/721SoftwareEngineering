using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace HomeSquareApp.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        [MaxLength(64)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(64)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(128)]
        public string Address { get; set; }

        [MaxLength(128)]
        public string DeliveryAddress { get; set; }

        [MaxLength(16)]
        public string Suburb { get; set; }

        [MaxLength(8)]
        public string ZipCode { get; set; }

        [MaxLength(8)]
        public string Unit { get; set; }

        [MaxLength(256)]
        public string PictureUrl { get; set; }

        [MaxLength(18)]
        public string DisplayName { get; set; }

        public IEnumerable<Order> Orders { get; set; }

        public IEnumerable<Reward> Rewards { get; set; }
    }
}
