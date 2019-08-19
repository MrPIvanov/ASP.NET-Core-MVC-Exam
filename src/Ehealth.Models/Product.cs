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

        public ICollection<CartProduct> Carts{ get; set; }
    }
}
