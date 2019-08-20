using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Ehealth.Web.Controllers
{
    public class AdminController : Controller
    {
        public async Task<IActionResult> Index()
        {
            return this.View();
        }


        // PRODUCTS


        public async Task<IActionResult> ProductAddNew()
        {
            return this.View();
        }

        public async Task<IActionResult> ProductOrder()
        {
            return this.View();
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
