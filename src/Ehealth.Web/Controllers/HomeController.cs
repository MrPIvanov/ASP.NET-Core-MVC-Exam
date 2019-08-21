using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Ehealth.Web.Models;
using Ehealth.Services.Contracts;
using System.Linq;
using Ehealth.BindingModels.Product;

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

        public async Task<IActionResult> SingleProduct(string id, int Quant)
        {
            var viewModel = await this.productService.GetSingleProductViewModelById(id);

            var categories = await this.categoryService.GetAll();

            this.ViewData["categoryTypes"] = categories.OrderBy(c => c.Name).ToList();

            viewModel.Quant = Quant;

            return this.View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> SingleProduct(BuyProductBindingModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return await this.SingleProduct(model.Id, model.Quant);
            }

            //TODO Handle Purchase here !!!



            return this.View(model);
        }

            








        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public async Task<IActionResult> Error()
        {
            return this.View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
