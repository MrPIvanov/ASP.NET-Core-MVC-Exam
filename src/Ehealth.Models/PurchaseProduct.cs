using System.ComponentModel.DataAnnotations;

namespace Ehealth.Models
{
    public class PurchaseProduct
    {
        [Required]
        public string PurchaseId { get; set; }

        public Purchase Purchase { get; set; }

        [Required]
        public string ProductId { get; set; }

        public Product Product { get; set; }

        [Required]
        public int Quantity { get; set; }
    }
}
