using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Ehealth.Data;
using Ehealth.Services.Contracts;
using Ehealth.ViewModels.Blog;
using Microsoft.EntityFrameworkCore;

namespace Ehealth.Services
{
    public class BlogService : IBlogService
    {
        private readonly EhealthDbContext context;
        private readonly IMapper mapper;

        public BlogService(EhealthDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<List<BlogSingleViewModel>> GetAllBlogsOrderByDateDesc()
        {
            var allBlogs = this.context.Blogs.OrderByDescending(b => b.PublishOn);

            var mappedBlogs = await this.mapper.ProjectTo<BlogSingleViewModel>(allBlogs).ToListAsync();

            return mappedBlogs;
        }

        public async Task<BlogSingleViewModel> GetSingleBlogById(string id)
        {
            var blog = await this.context.Blogs.FirstOrDefaultAsync(b => b.Id == id);

            var mappedBlog = this.mapper.Map<BlogSingleViewModel>(blog);

            return mappedBlog;
        }
    }
}
