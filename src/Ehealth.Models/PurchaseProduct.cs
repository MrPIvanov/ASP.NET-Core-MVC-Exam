namespace Ehealth.Models
{
    public class PurchaseProduct
    {
        public string PurchaseId { get; set; }

        public Purchase Purchase { get; set; }

        public string ProductId { get; set; }

        public Product Product { get; set; }

        public int Quantity { get; set; }
    }
}
