using Ehealth.BindingModels.Product;
using Ehealth.Services.Contracts;
using Ehealth.ViewModels.Product;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ehealth.Web.Controllers
{
    [Authorize(Roles = "Admin, Root")]
    public class AdminController : Controller
    {
        private readonly ICategoryService categoryService;
        private readonly IProductService productService;

        public AdminController(ICategoryService categoryService, IProductService productService)
        {
            this.categoryService = categoryService;
            this.productService = productService;
        }

        public async Task<IActionResult> Index()
        {
            return this.View();
        }


        // PRODUCTS


        public async Task<IActionResult> ProductAddNew()
        {
            var categories = await this.categoryService.GetAll();

            this.ViewData["categoryTypes"] = categories;

            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> ProductAddNew(AddNewProductBindingModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return await this.ProductAddNew();
            }

            await this.productService.AddNewProductFromInputModel(input);

            return this.Redirect("/Admin/ProductOrder");
        }

        public async Task<IActionResult> ProductOrder()
        {
            var products = await this.productService.GetAllNotDeletedOrderByQuantity();

            return this.View(products);
        }

        public async Task<IActionResult> ProductSingleOrder()
        {
            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> ProductSingleOrder(AddQuantityToProductBindingModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return await this.ProductSingleOrder();
            }

            await this.productService.AddQuantityToItem(input);

            return this.Redirect("/Admin/ProductOrder");
        }

        public async Task<IActionResult> ProductEdit()
        {
            return this.View();
        }

        public async Task<IActionResult> ProductInfo()
        {
            return this.View();
        }

        public async Task<IActionResult> ProductDeleted()
        {
            return this.View();
        }


        // CATEGORIES


        public async Task<IActionResult> CategoryAddNew()
        {
            return this.View();
        }

        public async Task<IActionResult> CategoryInfo()
        {
            return this.View();
        }


        // USERS


        public async Task<IActionResult> UserInfo()
        {
            return this.View();
        }

        public async Task<IActionResult> UserAdmins()
        {
            return this.View();
        }

        public async Task<IActionResult> UserUpdateRole()
        {
            return this.View();
        }


        // SALES


        public async Task<IActionResult> SalesLastMonth()
        {
            return this.View();
        }

        public async Task<IActionResult> SalesAll()
        {
            return this.View();
        }
    }
}
