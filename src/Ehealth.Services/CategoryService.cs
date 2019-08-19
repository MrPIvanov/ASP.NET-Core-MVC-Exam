using Ehealth.Data;
using Ehealth.Models;
using Ehealth.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Ehealth.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly EhealthDbContext context;

        public CategoryService(EhealthDbContext context)
        {
            this.context = context;
        }

        public async Task<Category> GetCategoryByName(string categoryName)
        {
            return await this.context.Categories
                .FirstOrDefaultAsync(x => x.Name == categoryName);
        }
    }
}