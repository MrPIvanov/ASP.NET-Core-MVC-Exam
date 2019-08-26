using System.ComponentModel.DataAnnotations;

namespace Ehealth.BindingModels.Product
{
    public class AddQuantityToProductBindingModel
    {
        [Required]
        public string Id { get; set; }

        [Required]
        [Range(1, 100, ErrorMessage = "Enter Quantity between 1 and 100")]
        public int Quantity { get; set; }
    }
}
