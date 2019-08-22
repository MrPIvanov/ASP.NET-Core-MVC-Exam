using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Ehealth.Web.Controllers
{
    public class CartController : Controller
    {
        public async Task<IActionResult> Index()
        {
            return await Task.Run(() => this.View());
        }
    }
}
