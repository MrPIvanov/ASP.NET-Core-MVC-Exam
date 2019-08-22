namespace Ehealth.ViewModels.Cart
{
    public class CartSingleProductViewModel
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }

        public int PurchasedQuantity { get; set; }

        public string ProductUrl { get; set; }

        public decimal TotalPrice => this.Price * this.PurchasedQuantity;
    }
}
