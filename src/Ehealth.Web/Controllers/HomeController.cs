using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Ehealth.Web.Models;
using Ehealth.Services.Contracts;
using System.Linq;

namespace Ehealth.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductService productService;
        private readonly ICategoryService categoryService;

        public HomeController(IProductService productService, ICategoryService categoryService)
        {
            this.productService = productService;
            this.categoryService = categoryService;
        }


        public async Task<IActionResult> Index()
        {
            var allProducts = await this.productService.GetRandomProductsForLandingPage();

            var categories = await this.categoryService.GetAll();

            this.ViewData["categoryTypes"] = categories.OrderBy(c => c.Name).ToList();

            return this.View(allProducts);
        }

        public async Task<IActionResult> SingleProduct(string id)
        {
            return this.Content(id);
        }










        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public async Task<IActionResult> Error()
        {
            return this.View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
