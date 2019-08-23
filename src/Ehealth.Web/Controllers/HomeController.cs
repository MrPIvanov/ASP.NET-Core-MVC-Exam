using System.Diagnostics;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Ehealth.Web.Models;
using Ehealth.Services.Contracts;
using System.Linq;
using Ehealth.BindingModels.Product;
using Microsoft.AspNetCore.Identity;
using Ehealth.Models;
using Microsoft.AspNetCore.Authorization;

namespace Ehealth.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IProductService productService;
        private readonly ICategoryService categoryService;
        private readonly UserManager<User> userManager;
        private readonly ICartService cartService;

        public HomeController(IProductService productService, ICategoryService categoryService, UserManager<User> userManager, ICartService cartService)
        {
            this.productService = productService;
            this.categoryService = categoryService;
            this.userManager = userManager;
            this.cartService = cartService;
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

            var currentUser = await this.userManager.GetUserAsync(this.User);

            if (currentUser == null)
            {
                return this.Redirect("/Identity/Account/Login");
            }

            await this.cartService.AddProductToUserCart(model, currentUser);

            return this.Redirect("/Cart/Index");
        }

        [Authorize]
        public async Task<IActionResult> Messages()
        {
            return await Task.Run(() => this.View());
        }    

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public async Task<IActionResult> Error()
        {
            return await Task.Run(() => this.View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier }));
        }
    }
}
