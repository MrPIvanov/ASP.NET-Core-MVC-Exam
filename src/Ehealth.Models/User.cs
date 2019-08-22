using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ehealth.Models
{
    public class User : IdentityUser
    {

        public User()
        {
            this.PurchaseHistory = new HashSet<Purchase>();
        }

        [Required]
        public DateTime RegisteredOn { get; set; }

        public ICollection<Purchase> PurchaseHistory { get; set; }

        public string CartId { get; set; }
    }
}
