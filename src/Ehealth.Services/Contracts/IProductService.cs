using Ehealth.BindingModels.Product;
using Ehealth.ViewModels.Product;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ehealth.Services.Contracts
{
    public interface IProductService
    {
        Task AddNewProductFromInputModel(AddNewProductBindingModel input);

        Task<List<AllProductsViewModel>> GetAllNotDeletedOrderByQuantity();

        Task AddQuantityToItem(AddQuantityToProductBindingModel input);
    }
}
