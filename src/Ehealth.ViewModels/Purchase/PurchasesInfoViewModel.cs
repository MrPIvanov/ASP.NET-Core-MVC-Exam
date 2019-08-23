using System;

namespace Ehealth.ViewModels.Purchase
{
    public class PurchasesInfoViewModel
    {
        public string Id { get; set; }

        public DateTime PurchaseDate { get; set; }

        public string DeliveryAddress { get; set; }

        public decimal TotalPrice { get; set; }

        public string UserId { get; set; }

        public string UserUsername { get; set; }
    }
}
