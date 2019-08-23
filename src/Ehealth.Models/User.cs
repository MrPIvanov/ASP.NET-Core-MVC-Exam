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
            this.Messages = new HashSet<Message>();
        }

        [Required]
        public DateTime RegisteredOn { get; set; }

        public string CartId { get; set; }

        public ICollection<Purchase> PurchaseHistory { get; set; }

        public ICollection<Message> Messages { get; set; }
    }
}
