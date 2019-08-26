using Ehealth.Services.Contracts;
using Ehealth.ViewModels.Category;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace Ehealth.Web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IProductService productService;
        private readonly ICategoryService categoryService;

        public CategoryController(IProductService productService, ICategoryService categoryService)
        {
            this.productService = productService;
            this.categoryService = categoryService;
        }

        [Route("/Category/{id}")]
        public async Task<IActionResult> Category(string id, string orderBy)
        {
            var categories = await this.categoryService.GetAll();

            this.ViewData["categoryTypes"] = categories.OrderBy(c => c.Name).ToList();

            if (id.ToLower() == "all")
            {
                this.ViewData["categoryName"] = "All Products";
            }
            else
            {
                this.ViewData["categoryName"] = categories.FirstOrDefault(c => c.Id == id).Name;
            }

            var products = await this.productService.GetAllProductsByCategoryNameAndSortCriteria(id, orderBy);

            var categoryToReturn = new CategoryForSortAndFilterViewModel
            {
                Id = id,
                Products = products
            };

            return this.View(categoryToReturn);
        }
    }
}
