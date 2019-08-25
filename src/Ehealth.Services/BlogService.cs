using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Ehealth.BindingModels.Blog;
using Ehealth.Data;
using Ehealth.Models;
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

        public async Task AddNewBlog(BlogAddNewBingingModel input)
        {
            var blogToAdd = this.mapper.Map<Blog>(input);

            blogToAdd.PublishOn = DateTime.UtcNow;

            await this.context.Blogs.AddAsync(blogToAdd);

            await this.context.SaveChangesAsync();
        }

        public async Task<RemoveRestoreSingleBlogViewModel> GetAllAvtiveAndRemovedBlogs()
        {
            var activeBlogs = this.context.Blogs.Where(b => b.isDeleted == false);

            var mappedActiveBlogs = await this.mapper.ProjectTo<BlogSingleViewModel>(activeBlogs).ToListAsync();

            var removedBlogs = this.context.Blogs.Where(b => b.isDeleted == true);

            var mappedRemovedBlogs = await this.mapper.ProjectTo<BlogSingleViewModel>(removedBlogs).ToListAsync();

            var model = new RemoveRestoreSingleBlogViewModel
            {
                Avtive = mappedActiveBlogs,
                Removed = mappedRemovedBlogs,
            };

            return model;
        }

        public async Task<List<BlogSingleViewModel>> GetAllNonDeletedBlogsOrderByDateDesc()
        {
            var allBlogs = this.context.Blogs.Where(b => b.isDeleted == false).OrderByDescending(b => b.PublishOn);

            var mappedBlogs = await this.mapper.ProjectTo<BlogSingleViewModel>(allBlogs).ToListAsync();

            return mappedBlogs;
        }

        public async Task<BlogSingleViewModel> GetSingleBlogById(string id)
        {
            var blog = await this.context.Blogs.FirstOrDefaultAsync(b => b.Id == id);

            var mappedBlog = this.mapper.Map<BlogSingleViewModel>(blog);

            return mappedBlog;
        }

        public async Task RemoveBlogFromActive(string id)
        {
            var blog = await this.context.Blogs.FirstOrDefaultAsync(b => b.Id == id);

            blog.isDeleted = true;

            await this.context.SaveChangesAsync();
        }

        public async Task RestoreBlogToActive(string id)
        {
            var blog = await this.context.Blogs.FirstOrDefaultAsync(b => b.Id == id);

            blog.isDeleted = false;

            await this.context.SaveChangesAsync();
        }
    }
}
