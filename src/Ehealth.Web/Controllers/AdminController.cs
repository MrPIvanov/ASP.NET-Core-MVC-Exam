using Ehealth.BindingModels.Blog;
using Ehealth.BindingModels.Category;
using Ehealth.BindingModels.Product;
using Ehealth.Services.Contracts;
using Ehealth.ViewModels.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Ehealth.Web.Controllers
{
    [Authorize(Roles = "Admin, Root")]
    public class AdminController : Controller
    {
        private readonly ICategoryService categoryService;
        private readonly IProductService productService;
        private readonly IUserService userService;
        private readonly IPurchaseService purchaseService;
        private readonly IBlogService blogService;

        public AdminController(ICategoryService categoryService, IProductService productService,
            IUserService userService, IPurchaseService purchaseService, IBlogService blogService)
        {
            this.categoryService = categoryService;
            this.productService = productService;
            this.userService = userService;
            this.purchaseService = purchaseService;
            this.blogService = blogService;
        }

        public async Task<IActionResult> Index()
        {
            return await Task.Run(() => this.View());
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
            return await Task.Run(() => this.View());
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
            var products = await this.productService.GetAllNotDeletedOrderByName();

            return this.View(products);
        }

        public async Task<IActionResult> ProductSingleEdit(string id)
        {
            var product = await this.productService.GetEditBindingModelProductEntity(id);

            return this.View(product);
        }

        [HttpPost]
        public async Task<IActionResult> ProductSingleEdit(EditProductBindingModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return await this.ProductSingleEdit(input.Id);
            }

            await this.productService.UpdateProduct(input);

            return this.Redirect("/Admin/ProductEdit");
        }

        public async Task<IActionResult> ProductInfo()
        {
            var products = await this.productService.GetAllNotDeletedOrderByPurchaseCount();

            return this.View(products);
        }

        public async Task<IActionResult> ProductSingleDelete()
        {
            return await Task.Run(() => this.View());
        }

        [HttpPost]
        public async Task<IActionResult> ProductSingleDelete(string id)
        {
            await this.productService.ToggleIsDeletedOnProduct(id);

            return this.Redirect("/Admin/ProductEdit");
        }

        public async Task<IActionResult> ProductDeleted()
        {
            var products = await this.productService.GetAllDeletedOrderByName();

            return this.View(products);
        }

        public async Task<IActionResult> ProductSingleRestore()
        {
            return await Task.Run(() => this.View());
        }

        [HttpPost]
        public async Task<IActionResult> ProductSingleRestore(string id)
        {
            await this.productService.ToggleIsDeletedOnProduct(id);

            return this.Redirect("/Admin/ProductDeleted");
        }


        // CATEGORIES


        public async Task<IActionResult> CategoryAddNew()
        {
            return await Task.Run(() => this.View());
        }

        [HttpPost]
        public async Task<IActionResult> CategoryAddNew(AddNewCategoryBindingModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return await this.CategoryAddNew();
            }

            await this.categoryService.AddNewCategoryByName(input);

            return this.Redirect("/Admin/CategoryInfo");
        }

        public async Task<IActionResult> CategoryInfo()
        {
            var allCategories = await this.categoryService.GetAllByPurchaseCount();

            return this.View(allCategories);
        }


        // USERS


        public async Task<IActionResult> UserInfo()
        {
            var allUsers = await this.userService.GetAllUsersByName();

            return this.View(allUsers);
        }

        public async Task<IActionResult> UserAdmins()
        {
            var allAdmins = await this.userService.GetAllAdminsByName();

            return this.View(allAdmins);
        }

        public async Task<IActionResult> UserUpdateRole()
        {
            var model = new AllUsersAndAdminsRoleChangeViewModel
            {
                Admins = await this.userService.GetAllAdminsByName(),
                Users = await this.userService.GetAllUsersByName(),
            };

            return this.View(model);
        }

        public async Task<IActionResult> UserSinglePromote()
        {
            return await Task.Run(() => this.View());
        }

        [HttpPost]
        public async Task<IActionResult> UserSinglePromote(string id)
        {
            await this.userService.PromoteUserToAdmin(id);

            return this.Redirect("/Admin/UserUpdateRole");
        }

        public async Task<IActionResult> UserSingleDemote()
        {
            return await Task.Run(() => this.View());
        }

        [HttpPost]
        public async Task<IActionResult> UserSingleDemote(string id)
        {
            await this.userService.DemoteAdminToUser(id);

            return this.Redirect("/Admin/UserUpdateRole");
        }


        // SALES


        public async Task<IActionResult> SalesLastMonth()
        {
            var allPurchases = await this.purchaseService.GetAllPurchasesInfo();

            var filteredPurchases = allPurchases
                .Where(p => p.PurchaseDate > DateTime.UtcNow.AddDays(-30))
                .OrderByDescending(d => d.PurchaseDate)
                .ToList();

            return this.View(filteredPurchases);
        }

        public async Task<IActionResult> SalesAll()
        {
            var allPurchases = await this.purchaseService.GetAllPurchasesInfo();

            allPurchases = allPurchases.OrderByDescending(d => d.PurchaseDate).ToList();

            return this.View(allPurchases);
        }

        // BLOGS


        public async Task<IActionResult> BlogAddNew()
        {
            return await Task.Run(() => this.View());
        }

        [HttpPost]
        public async Task<IActionResult> BlogAddNew(BlogAddNewBingingModel input)
        {
            if (!this.ModelState.IsValid)
            {
                return await this.BlogAddNew();
            }

            await this.blogService.AddNewBlog(input);

            return this.Redirect("/Blog");
        }

        public async Task<IActionResult> BlogRemoveRestore()
        {
            var viewModel = await this.blogService.GetAllAvtiveAndRemovedBlogs();

            return this.View(viewModel);
        }

        public async Task<IActionResult> BlogSingleRemove()
        {
            return await Task.Run(() => this.View());
        }

        [HttpPost]
        public async Task<IActionResult> BlogSingleRemove(string id)
        {
            await this.blogService.RemoveBlogFromActive(id);

            return this.Redirect("/Admin/BlogRemoveRestore");
        }

        public async Task<IActionResult> BlogSingleRestore()
        {
            return await Task.Run(() => this.View());
        }

        [HttpPost]
        public async Task<IActionResult> BlogSingleRestore(string id)
        {
            await this.blogService.RestoreBlogToActive(id);

            return this.Redirect("/Admin/BlogRemoveRestore");
        }
    }
}
