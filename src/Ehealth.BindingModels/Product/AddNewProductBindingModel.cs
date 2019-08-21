using System.ComponentModel.DataAnnotations;

namespace Ehealth.BindingModels.Product
{
    public class AddNewProductBindingModel
    {
        [Required(ErrorMessage = "Enter product name!")]
        [StringLength(100, ErrorMessage = "Product name length must be between {2} and {1} characters.", MinimumLength = 5)]
        public string Name { get; set; }

        [Required(ErrorMessage = "Enter product description!")]
        [StringLength(1000, ErrorMessage = "Product description length must be between {2} and {1} characters.", MinimumLength = 10)]
        public string Description { get; set; }

        [Range(typeof(decimal), "0.01", "100000", ErrorMessage = "Please enter a valid price.")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Enter product URL!")]
        [StringLength(255, ErrorMessage = "Product URL length must be between {2} and {1} characters.", MinimumLength = 10)]
        public string ProductUrl { get; set; }

        [Required(ErrorMessage = "Select category!")]
        public string CategoryIdString { get; set; }
    }
}
