using AutoMapper;
using Ehealth.BindingModels.Blog;
using Ehealth.Data;
using Ehealth.Models;
using Ehealth.Services;
using Ehealth.Web.Infrastructure.Mappings;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Ehealth.Tests.Services
{
    public class BlogServiceTests
    {
        private readonly EhealthDbContext context;

        public BlogServiceTests()
        {
            this.context = EhealthDbContextInMemoryFactory.InitializeInMemoryContext();
        }

        [Fact]
        public async Task AddNewBlogTests()
        {
            //Arrange
            var mapperConfig = new MapperConfiguration(x => x.AddProfile(new MappingProfile()));
            var mapper = mapperConfig.CreateMapper();

            var blogService = new BlogService(this.context, mapper);

            var expectedResult = new BlogAddNewBingingModel
            {
                Author = "Some Author",
                Content = "Some Content",
                ImageUrl = "Some Url",
                SubTitle = "Some Subtitle",
                Title = "Some Title"
            };

            //Act
            await blogService.AddNewBlog(expectedResult);

            //Assert
            Assert.Equal(1, this.context.Blogs.Count());
        }

        [Fact]
        public async Task GetAllAvtiveAndRemovedBlogsTests()
        {
            //Arrange
            var mapperConfig = new MapperConfiguration(x => x.AddProfile(new MappingProfile()));
            var mapper = mapperConfig.CreateMapper();

            var blogService = new BlogService(this.context, mapper);

            var deletedBlog = new Blog
            {
                Author = "Some Author",
                Content = "Some Content",
                ImageUrl = "Some Url",
                SubTitle = "Some Subtitle",
                Title = "Some Title",
                PublishOn = DateTime.UtcNow,
                isDeleted = true,
            };

            var activeBlog = new Blog
            {
                Author = "Some Author",
                Content = "Some Content",
                ImageUrl = "Some Url",
                SubTitle = "Some Subtitle",
                Title = "Some Title",
                PublishOn = DateTime.UtcNow,
                isDeleted = false,
            };

            await this.context.Blogs.AddRangeAsync(activeBlog, deletedBlog);
            await this.context.SaveChangesAsync();

            //Act
            var actualResult = await blogService.GetAllAvtiveAndRemovedBlogs();

            //Assert
            Assert.Single(actualResult.Avtive);
            Assert.Single(actualResult.Removed);
        }

        [Fact]
        public async Task GetAllNonDeletedBlogsOrderByDateDescTests()
        {
            //Arrange
            var mapperConfig = new MapperConfiguration(x => x.AddProfile(new MappingProfile()));
            var mapper = mapperConfig.CreateMapper();

            var blogService = new BlogService(this.context, mapper);

            var firstBlog = new Blog
            {
                Author = "Some Author first",
                Content = "Some Content first",
                ImageUrl = "Some Url first",
                SubTitle = "Some Subtitle first",
                Title = "Some Title first",
                PublishOn = DateTime.UtcNow,
                isDeleted = true,
            };

            var secondBlog = new Blog
            {
                Author = "Some Author second",
                Content = "Some Content second",
                ImageUrl = "Some Url second",
                SubTitle = "Some Subtitle second",
                Title = "Some Title second",
                PublishOn = DateTime.UtcNow.AddDays(-5),
                isDeleted = false,
            };

            var thirdBlog = new Blog
            {
                Author = "Some Author third",
                Content = "Some Content third",
                ImageUrl = "Some Url third",
                SubTitle = "Some Subtitle third",
                Title = "Some Title third",
                PublishOn = DateTime.UtcNow.AddDays(-1),
                isDeleted = false,
            };

            await this.context.Blogs.AddRangeAsync(firstBlog, secondBlog, thirdBlog);
            await this.context.SaveChangesAsync();

            //Act
            var actualResult = await blogService.GetAllNonDeletedBlogsOrderByDateDesc();

            //Assert
            Assert.Equal(2, actualResult.Count());
            Assert.Equal("Some Author third", actualResult[0].Author);
        }

        [Fact]
        public async Task GetSingleBlogByIdTests()
        {
            //Arrange
            var mapperConfig = new MapperConfiguration(x => x.AddProfile(new MappingProfile()));
            var mapper = mapperConfig.CreateMapper();

            var blogService = new BlogService(this.context, mapper);            

            var activeBlog = new Blog
            {
                Author = "Some Author",
                Content = "Some Content",
                ImageUrl = "Some Url",
                SubTitle = "Some Subtitle",
                Title = "Some Title",
                PublishOn = DateTime.UtcNow,
                isDeleted = false,
            };

            await this.context.Blogs.AddAsync(activeBlog);
            await this.context.SaveChangesAsync();

            //Act
            var actualResult = await blogService.GetSingleBlogById(activeBlog.Id);

            //Assert
            Assert.Equal("Some Author", actualResult.Author);
            Assert.Equal("Some Title", actualResult.Title);
        }

        [Fact]
        public async Task RemoveBlogFromActiveTests()
        {
            //Arrange
            var mapperConfig = new MapperConfiguration(x => x.AddProfile(new MappingProfile()));
            var mapper = mapperConfig.CreateMapper();

            var blogService = new BlogService(this.context, mapper);

            var activeBlog = new Blog
            {
                Author = "Some Author",
                Content = "Some Content",
                ImageUrl = "Some Url",
                SubTitle = "Some Subtitle",
                Title = "Some Title",
                PublishOn = DateTime.UtcNow,
                isDeleted = false,
            };

            await this.context.Blogs.AddAsync(activeBlog);
            await this.context.SaveChangesAsync();

            //Act
            await blogService.RemoveBlogFromActive(activeBlog.Id);

            //Assert
            Assert.True(activeBlog.isDeleted);
        }

        [Fact]
        public async Task RestoreBlogToActiveTests()
        {
            //Arrange
            var mapperConfig = new MapperConfiguration(x => x.AddProfile(new MappingProfile()));
            var mapper = mapperConfig.CreateMapper();

            var blogService = new BlogService(this.context, mapper);

            var removedBlog = new Blog
            {
                Author = "Some Author",
                Content = "Some Content",
                ImageUrl = "Some Url",
                SubTitle = "Some Subtitle",
                Title = "Some Title",
                PublishOn = DateTime.UtcNow,
                isDeleted = true,
            };

            await this.context.Blogs.AddAsync(removedBlog);
            await this.context.SaveChangesAsync();

            //Act
            await blogService.RestoreBlogToActive(removedBlog.Id);

            //Assert
            Assert.False(removedBlog.isDeleted);
        }
    }
}
