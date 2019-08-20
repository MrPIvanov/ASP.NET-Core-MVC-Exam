using System.Collections.Generic;

namespace Ehealth.Models
{
    public class Product
    {
        public Product()
        {
            this.Carts = new HashSet<CartProduct>();
        }

        public string Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }

        public string ProductUrl { get; set; }

        public bool isDeleted { get; set; }

        public int PurchaseCount { get; set; }

        public string CategoryId { get; set; }
        public Category Category { get; set; }

        public ICollection<CartProduct> Carts{ get; set; }
    }
}
