using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Ehealth.BindingModels.Product;
using Ehealth.Data;
using Ehealth.Models;
using Ehealth.Services.Contracts;
using Ehealth.ViewModels.Cart;
using Microsoft.EntityFrameworkCore;

namespace Ehealth.Services
{
    public class CartService : ICartService
    {
        private readonly EhealthDbContext context;
        private readonly IMapper mapper;

        public CartService(EhealthDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task AddProductToUserCart(BuyProductBindingModel model, User user)
        {
            var currentOrder = await this.context.CartProducts
                .FirstOrDefaultAsync(cp => cp.CartId == user.CartId && cp.ProductId == model.Id);

            if (currentOrder == null)
            {
                await this.context.CartProducts.AddAsync(new CartProduct
                {
                    CartId = user.CartId,
                    ProductId = model.Id,
                    Quantity = model.Quant,
                });
            }
            else
            {
                currentOrder.Quantity = model.Quant;
            }

            await this.context.SaveChangesAsync();
        }

        public async Task RemoveProductFromUserCart(string id, User user)
        {
            var currentRecordToRemove = await this.context.CartProducts
                .FirstOrDefaultAsync(cp => cp.CartId == user.CartId && cp.ProductId == id);

            this.context.CartProducts.Remove(currentRecordToRemove);

            await this.context.SaveChangesAsync();
        }

        public async Task<List<CartSingleProductViewModel>> GetAllProductsForCurrentUser(User user)
        {
            var resultToReturn = new List<CartSingleProductViewModel>();

            var allCartProductsRecords = await this.context.CartProducts.Where(cp => cp.CartId == user.CartId).ToListAsync();

            foreach (var record in allCartProductsRecords)
            {
               var currentProductEntity = await this.context.Products.FirstOrDefaultAsync(p => p.Id == record.ProductId);

                var resultProduct = this.mapper.Map<CartSingleProductViewModel>(currentProductEntity);

                resultProduct.PurchasedQuantity = record.Quantity;

                resultToReturn.Add(resultProduct);
            }

            return resultToReturn;
        }
    }
}
