using Ehealth.BindingModels.Blog;
using Ehealth.ViewModels.Blog;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ehealth.Services.Contracts
{
    public interface IBlogService
    {
        Task<List<BlogSingleViewModel>> GetAllNonDeletedBlogsOrderByDateDesc();

        Task<BlogSingleViewModel> GetSingleBlogById(string id);

        Task AddNewBlog(BlogAddNewBingingModel input);

        Task<RemoveRestoreSingleBlogViewModel> GetAllAvtiveAndRemovedBlogs();

        Task RemoveBlogFromActive(string id);

        Task RestoreBlogToActive(string id);

    }
}
