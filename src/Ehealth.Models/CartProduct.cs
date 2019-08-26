using System.ComponentModel.DataAnnotations;

namespace Ehealth.Models
{
    public class CartProduct
    {
        [Required]
        public string CartId { get; set; }

        public Cart Cart { get; set; }

        [Required]
        public string ProductId { get; set; }

        public Product Product { get; set; }

        [Required]
        public int Quantity { get; set; }
    }
}
