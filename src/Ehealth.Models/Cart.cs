using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ehealth.Models
{
    public class Cart
    {

        public Cart()
        {
            this.Products = new HashSet<CartProduct>();
        }

        [Required]
        public string Id { get; set; }

        [Required]
        public string UserId { get; set; }

        public ICollection<CartProduct> Products { get; set; }
    }
}
