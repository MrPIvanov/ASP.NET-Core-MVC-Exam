namespace Ehealth.Models
{
    public class CartProduct
    {
        public string CartId { get; set; }

        public Cart Cart { get; set; }

        public string ProductId { get; set; }

        public Product Product { get; set; }

        public int Quantity { get; set; }
    }
}
