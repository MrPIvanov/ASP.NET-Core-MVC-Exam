using Ehealth.BindingModels.Purchase;
using Ehealth.Models;
using Ehealth.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Ehealth.Web.Controllers
{
    public class PurchaseController : Controller
    {
        private readonly UserManager<User> userManager;
        private readonly ICartService cartService;
        private readonly IPurchaseService purchaseService;

        public PurchaseController(UserManager<User> userManager, ICartService cartService, IPurchaseService purchaseService)
        {
            this.userManager = userManager;
            this.cartService = cartService;
            this.purchaseService = purchaseService;
        }

        [Authorize]
        public async Task<IActionResult> BuyAll()
        {
            var currentUser = await this.userManager.GetUserAsync(this.User);

            this.ViewData["currentUser"] = currentUser;

            this.ViewData["allProducts"] = await this.cartService.GetAllProductsForCurrentUser(currentUser);

            return this.View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> BuyAll(BuyAllPurchaseBindingModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return await this.BuyAll();
            }

            var currentUser = await this.userManager.GetUserAsync(this.User);

            var deliveryAddress = model.DeliveryAddress;

            await this.purchaseService.CreatePurchaseByUserId(currentUser, deliveryAddress);

            return this.Redirect("/Purchase/ThankYou");
        }

        public async Task<IActionResult> ThankYou()
        {
            return await Task.Run(() => this.View());
        }
    }
}
