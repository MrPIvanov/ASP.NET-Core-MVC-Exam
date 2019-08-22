using System;
using System.Collections.Generic;

namespace Ehealth.Models
{
    public class Purchase
    {

        public Purchase()
        {
            this.Products = new HashSet<PurchaseProduct>();
        }

        public string Id { get; set; }

        public DateTime PurchaseDate { get; set; }

        public string DeliveryAddress { get; set; }

        public decimal TotalPrice { get; set; }

        public string UserId { get; set; }

        public User User { get; set; }

        public ICollection<PurchaseProduct> Products { get; set; }

    }
}
