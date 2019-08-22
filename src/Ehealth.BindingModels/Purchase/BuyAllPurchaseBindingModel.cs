using System.ComponentModel.DataAnnotations;

namespace Ehealth.BindingModels.Purchase
{
    public class BuyAllPurchaseBindingModel
    {
        [Required(ErrorMessage = "Enter Delivery Address!")]
        [StringLength(100, ErrorMessage = "Delivery Address length must be between {2} and {1} characters.", MinimumLength = 10)]
        public string DeliveryAddress { get; set; }
    }
}
