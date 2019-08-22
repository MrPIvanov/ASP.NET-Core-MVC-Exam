using System.Collections.Generic;

namespace Ehealth.Models
{
    public class Cart
    {

        public Cart()
        {
            this.Products = new HashSet<CartProduct>();
        }

        public string Id { get; set; }

        public string UserId { get; set; }

        public ICollection<CartProduct> Products { get; set; }
    }
}
