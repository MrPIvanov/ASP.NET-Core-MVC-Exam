using Ehealth.Models;
using System.Threading.Tasks;

namespace Ehealth.Services.Contracts
{
    public interface ICategoryService
    {
        Task<Category> GetCategoryByName(string categoryName);
    }
}
