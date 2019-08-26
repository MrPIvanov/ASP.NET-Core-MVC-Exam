using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ehealth.Models
{
    public class Category
    {

        public Category()
        {
            this.Products = new HashSet<Product>();
        }

        [Required]
        public string Id { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
