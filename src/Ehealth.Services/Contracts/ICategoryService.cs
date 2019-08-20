using Ehealth.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ehealth.Services.Contracts
{
    public interface ICategoryService
    {
        Task<Category> GetCategoryByName(string categoryName);

        Task<List<Category>> GetAll();
    }
}
