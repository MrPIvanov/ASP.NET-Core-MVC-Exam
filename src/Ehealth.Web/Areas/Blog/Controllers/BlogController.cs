using Ehealth.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Ehealth.Web.Areas.Blog.Controllers
{
    public class BlogController : Controller
    {
        private readonly IBlogService blogService;

        public BlogController(IBlogService blogService)
        {
            this.blogService = blogService;
        }

        [Area("Blog")]
        public async Task<IActionResult> Index()
        {
            var allBlogs = await this.blogService.GetAllNonDeletedBlogsOrderByDateDesc();

            return this.View(allBlogs);
        }

        [Area("Blog")]
        public async Task<IActionResult> SingleBlog(string id)
        {
            var currentBlog = await this.blogService.GetSingleBlogById(id);

            return this.View(currentBlog);
        }
    }
}
