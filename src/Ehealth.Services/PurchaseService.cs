using System;
using System.Linq;
using System.Threading.Tasks;
using Ehealth.Data;
using Ehealth.Models;
using Ehealth.Services.Contracts;
using Microsoft.EntityFrameworkCore;

namespace Ehealth.Services
{
    public class PurchaseService : IPurchaseService
    {
        private readonly EhealthDbContext context;
        private readonly ICartService cartService;

        public PurchaseService(EhealthDbContext context, ICartService cartService)
        {
            this.context = context;
            this.cartService = cartService;
        }

        public async Task CreatePurchaseByUserId(User user, string address)
        {
            var products = await this.cartService.GetAllProductsForCurrentUser(user);

            var currentPurchase = new Purchase
            {
                DeliveryAddress = address,
                PurchaseDate = DateTime.UtcNow,
                User = user,
                UserId = user.Id,
                TotalPrice = products.Sum(p => p.TotalPrice)
            };

            await this.context.Purchases.AddAsync(currentPurchase);
            await this.context.SaveChangesAsync();

            foreach (var product in products)
            {
                var curentProduct = await this.context.Products.FirstOrDefaultAsync(p => p.Id == product.Id);

                curentProduct.Quantity -= product.PurchasedQuantity;
                curentProduct.PurchaseCount += product.PurchasedQuantity;

                await this.cartService.RemoveProductFromUserCart(product.Id, user);

                var purchaseProduct = new PurchaseProduct
                {
                    ProductId = product.Id,
                    Quantity = product.PurchasedQuantity,
                    PurchaseId = currentPurchase.Id,
                };

                await this.context.PurchaseProducts.AddAsync(purchaseProduct);
                await this.context.SaveChangesAsync();
            }
        }
    }
}
