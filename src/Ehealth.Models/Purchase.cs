using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ehealth.Models
{
    public class Purchase
    {

        public Purchase()
        {
            this.Products = new HashSet<PurchaseProduct>();
        }

        [Required]
        public string Id { get; set; }

        [Required]
        public DateTime PurchaseDate { get; set; }

        [Required]
        public string DeliveryAddress { get; set; }

        [Required]
        public decimal TotalPrice { get; set; }

        public string UserId { get; set; }

        public User User { get; set; }

        public ICollection<PurchaseProduct> Products { get; set; }

    }
}
