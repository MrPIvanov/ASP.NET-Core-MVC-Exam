using System.Collections.Generic;

namespace Ehealth.Models
{
    public class Category
    {

        public Category()
        {
            this.Products = new HashSet<Product>();
        }

        public string Id { get; set; }

        public string Name { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
