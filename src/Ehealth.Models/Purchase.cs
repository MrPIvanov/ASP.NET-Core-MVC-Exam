using System;
using System.Collections.Generic;
using System.Linq;

namespace Ehealth.Models
{
    public class Purchase
    {

        public Purchase()
        {
            this.ProductsBought = new HashSet<Product>();
        }

        public string Id { get; set; }

        public DateTime PurchaseDate { get; set; }

        public string DeliveryAddress { get; set; }

        public decimal TotalPrice => this.ProductsBought.Sum(p => p.Price);

        public string UserId { get; set; }

        public User User { get; set; }

        public ICollection<Product> ProductsBought { get; set; }

    }
}
