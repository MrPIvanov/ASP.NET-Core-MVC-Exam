using Ehealth.ViewModels.Blog;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ehealth.Services.Contracts
{
    public interface IBlogService
    {
        Task<List<BlogSingleViewModel>> GetAllBlogsOrderByDateDesc();

        Task<BlogSingleViewModel> GetSingleBlogById(string id);
    }
}
