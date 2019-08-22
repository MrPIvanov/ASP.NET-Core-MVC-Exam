using Ehealth.Models;
using Ehealth.Services.Contracts;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Ehealth.Web.Controllers
{
    public class CartController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly ICartService cartService;

        public CartController(UserManager<User> userManager, ICartService cartService)
        {
            this.userManager = userManager;
            this.cartService = cartService;
        }

        public async Task<IActionResult> Index()
        {
            var currentUser = await this.userManager.GetUserAsync(this.User);

            if (currentUser == null)
            {
                return this.Redirect("/Identity/Account/Login");
            }

            var currentCartProducts = await this.cartService.GetAllProductsForCurrentUser(currentUser);

            return this.View(currentCartProducts);
        }

        [HttpPost]
        public async Task<IActionResult> Index(string id)
        {
            var currentUser = await this.userManager.GetUserAsync(this.User);

            await this.cartService.RemoveProductFromUserCart(id, currentUser);

            return this.Redirect("/Cart/Index");
        }
    }
}
