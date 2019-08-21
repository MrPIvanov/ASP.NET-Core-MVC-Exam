using AutoMapper;
using Ehealth.BindingModels.Category;
using Ehealth.Data;
using Ehealth.Models;
using Ehealth.Services.Contracts;
using Ehealth.ViewModels.Category;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Ehealth.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly EhealthDbContext context;
        private readonly IMapper mapper;

        public CategoryService(EhealthDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task AddNewCategoryByName(AddNewCategoryBindingModel input)
        {
            var categoryToAdd = this.mapper.Map<Category>(input);

            await this.context.Categories.AddAsync(categoryToAdd);

            await this.context.SaveChangesAsync();
        }

        public async Task<List<Category>> GetAll()
        {
            return await this.context.Categories.ToListAsync();
        }

        public async Task<List<AllCategoriesByPurchaseCountViewModel>> GetAllByPurchaseCount()
        {
            var mappedCategories = await this.mapper.ProjectTo<AllCategoriesByPurchaseCountViewModel>(this.context.Categories)
                .OrderByDescending(c => c.TotalPurchaseCount).ToListAsync();

            return mappedCategories;
        }

        public async Task<Category> GetCategoryByName(string categoryName)
        {
            return await this.context.Categories
                .FirstOrDefaultAsync(x => x.Name == categoryName);
        }
    }
}