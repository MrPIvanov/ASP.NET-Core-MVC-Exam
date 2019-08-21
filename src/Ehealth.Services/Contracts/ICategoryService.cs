using Ehealth.BindingModels.Category;
using Ehealth.Models;
using Ehealth.ViewModels.Category;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ehealth.Services.Contracts
{
    public interface ICategoryService
    {
        Task<Category> GetCategoryByName(string categoryName);

        Task<List<Category>> GetAll();

        Task<List<AllCategoriesByPurchaseCountViewModel>> GetAllByPurchaseCount();

        Task AddNewCategoryByName(AddNewCategoryBindingModel input);
    }
}
