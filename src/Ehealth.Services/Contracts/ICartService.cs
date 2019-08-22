using Ehealth.BindingModels.Product;
using Ehealth.Models;
using Ehealth.ViewModels.Cart;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ehealth.Services.Contracts
{
    public interface ICartService
    {
        Task AddProductToUserCart(BuyProductBindingModel model, User user);

        Task RemoveProductFromUserCart(string id, User user);

        Task<List<CartSingleProductViewModel>> GetAllProductsForCurrentUser(User user);
    }
}
