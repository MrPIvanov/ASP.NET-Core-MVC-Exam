using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Ehealth.Data;
using Ehealth.Models;
using Ehealth.Services.Contracts;
using Ehealth.ViewModels.Purchase;
using Microsoft.EntityFrameworkCore;

namespace Ehealth.Services
{
    public class PurchaseService : IPurchaseService
    {
        private readonly EhealthDbContext context;
        private readonly ICartService cartService;
        private readonly IMapper mapper;

        public PurchaseService(EhealthDbContext context, ICartService cartService, IMapper mapper)
        {
            this.context = context;
            this.cartService = cartService;
            this.mapper = mapper;
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

        public async Task<List<PurchasesInfoViewModel>> GetAllPurchasesInfo()
        {
            var allPurchases = this.context.Purchases;

            var mappedPurchases = await this.mapper.ProjectTo<PurchasesInfoViewModel>(allPurchases).ToListAsync();

            return mappedPurchases;
        }
    }
}
