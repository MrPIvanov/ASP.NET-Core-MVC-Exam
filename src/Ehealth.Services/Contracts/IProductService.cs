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

        Task<List<AllProductsViewModel>> GetAllNotDeletedOrderByName();

        Task<List<AllProductsViewModel>> GetAllNotDeletedOrderByPurchaseCount();

        Task<List<AllProductsViewModel>> GetAllDeletedOrderByName();

        Task<List<AllProductsViewModel>> GetRandomProductsForLandingPage();

        Task<List<AllProductsViewModel>> GetAllProductsByCategoryNameAndSortCriteria(string id, string orderBy);
               
        Task ToggleIsDeletedOnProduct(string id);

        Task AddQuantityToItem(AddQuantityToProductBindingModel input);

        Task<EditProductBindingModel> GetEditBindingModelProductEntity(string id);

        Task UpdateProduct(EditProductBindingModel input);

        Task<SingleProductViewModel> GetSingleProductViewModelById(string id);

        Task<List<SingleProductViewModel>> GetAllPurchasedProductsByPurchaseId(string id);


    }
}
