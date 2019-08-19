using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Ehealth.Web.Controllers
{
    public class AdminController : Controller
    {
        public async Task<IActionResult> Index()
        {
            return this.Content("Admin");
        }
    }
}
