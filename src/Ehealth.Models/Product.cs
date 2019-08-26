using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Ehealth.Models
{
    public class Product
    {
        public Product()
        {
            this.Carts = new HashSet<CartProduct>();
            this.Purchases = new HashSet<PurchaseProduct>();
        }

        [Required]
        public string Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public int Quantity { get; set; }

        [Required]
        public string ProductUrl { get; set; }

        public string Description { get; set; }

        [Required]
        public bool isDeleted { get; set; }

        public int PurchaseCount { get; set; }

        public string CategoryId { get; set; }
        public Category Category { get; set; }

        public ICollection<CartProduct> Carts{ get; set; }

        public ICollection<PurchaseProduct> Purchases { get; set; }

    }
}
