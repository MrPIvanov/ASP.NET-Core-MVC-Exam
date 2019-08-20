using System.ComponentModel.DataAnnotations;

namespace Ehealth.BindingModels.Product
{
    public class EditProductBindingModel
    {
        [Required]
        public string Id { get; set; }

        [Required(ErrorMessage = "Enter product name!")]
        [StringLength(100, ErrorMessage = "Product name length must be between {2} and {1} characters.", MinimumLength = 5)]
        public string Name { get; set; }

        [Range(typeof(decimal), "0.01", "100000", ErrorMessage = "Please enter a valid price.")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Enter product URL!")]
        [StringLength(255, ErrorMessage = "Product URL length must be between {2} and {1} characters.", MinimumLength = 10)]
        public string ProductUrl { get; set; }

        [Required]
        [Range(1, 100, ErrorMessage = "Enter Quantity between 1 and 100")]
        public int Quantity { get; set; }

    }
}
