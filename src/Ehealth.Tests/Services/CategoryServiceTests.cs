using AutoMapper;
using Ehealth.BindingModels.Category;
using Ehealth.Data;
using Ehealth.Models;
using Ehealth.Services;
using Ehealth.Web.Infrastructure.Mappings;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Ehealth.Tests.Services
{
    public class CategoryServiceTests
    {
        private readonly EhealthDbContext context;

        public CategoryServiceTests()
        {
            this.context = EhealthDbContextInMemoryFactory.InitializeInMemoryContext();
        }

        [Fact]
        public async Task AddNewCategoryByNameTests()
        {
            //Arrange
            var mapperConfig = new MapperConfiguration(x => x.AddProfile(new MappingProfile()));
            var mapper = mapperConfig.CreateMapper();

            var categoryService = new CategoryService(this.context, mapper);

            var categoryModel = new AddNewCategoryBindingModel
            {
                Name = "CategoryName"
            };

            //Act
            Assert.Equal(0, this.context.Categories.Count());

            await categoryService.AddNewCategoryByName(categoryModel);
            //Assert
            Assert.Equal(1, this.context.Categories.Count());

        }

        [Fact]
        public async Task GetAllTests()
        {
            //Arrange
            var mapperConfig = new MapperConfiguration(x => x.AddProfile(new MappingProfile()));
            var mapper = mapperConfig.CreateMapper();

            var categoryService = new CategoryService(this.context, mapper);

            await this.context.Categories.AddAsync(new Category
            {
                Name = "first"
            });

            await this.context.Categories.AddAsync(new Category
            {
                Name = "second"
            });

            await this.context.SaveChangesAsync();



            //Act
            var actualResult = await categoryService.GetAll();

            //Assert
            Assert.Equal(2, actualResult.Count());
            
            Assert.Single(actualResult.Where(c => c.Name == "first").ToList());
            Assert.Single(actualResult.Where(c => c.Name == "second").ToList());
        }

        [Fact]
        public async Task GetAllByPurchaseCountTests()
        {
            //Arrange
            var mapperConfig = new MapperConfiguration(x => x.AddProfile(new MappingProfile()));
            var mapper = mapperConfig.CreateMapper();

            var categoryService = new CategoryService(this.context, mapper);

            var firstCategory = new Category
            {
                Name = "first"
            };

            var secondCategory = new Category
            {
                Name = "second"
            };

            await this.context.Categories.AddRangeAsync(firstCategory, secondCategory);
            await this.context.SaveChangesAsync();

            var firstProduct = new Product
            {
                CategoryId = firstCategory.Id,
                Name = "Acerol Powder DRAGON SUPERFOODS 100 gr",
                Price = 37.20m,
                ProductUrl = "https://images-na.ssl-images-amazon.com/images/I/61-OWP%2BVkoL._SX385_.jpg",
                Quantity = 2,
                PurchaseCount = 2,
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                isDeleted = true
            };

            var secondProduct = new Product
            {
                CategoryId = secondCategory.Id,
                Name = "Goji berries Dragoil SUPERFUDS 100 gr",
                Price = 7.20m,
                ProductUrl = "https://m.media-amazon.com/images/I/61ejIcf1HoL._AC_UL320_.jpg",
                Quantity = 9,
                PurchaseCount = 20,
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
            };

            var thirdProduct = new Product
            {
                CategoryId = secondCategory.Id,
                Name = "Goji berries Dragoil SUPERFUDS 100 gr",
                Price = 7.20m,
                ProductUrl = "https://m.media-amazon.com/images/I/61ejIcf1HoL._AC_UL320_.jpg",
                Quantity = 9,
                PurchaseCount = 10,
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
            };

            await this.context.Products.AddRangeAsync(firstProduct, secondProduct, thirdProduct);
            await this.context.SaveChangesAsync();

            //Act
            var actualResult = await categoryService.GetAllByPurchaseCount();

            //Assert
            Assert.Equal(2, actualResult.Count());

            Assert.Equal(30, actualResult[0].TotalPurchaseCount);
            Assert.Equal(2, actualResult[0].ProductsCount);
            Assert.Equal(2, actualResult[1].TotalPurchaseCount);
            Assert.Equal(1, actualResult[1].ProductsCount);
        }

        [Fact]
        public async Task GetCategoryByNamelTests()
        {
            //Arrange
            var mapperConfig = new MapperConfiguration(x => x.AddProfile(new MappingProfile()));
            var mapper = mapperConfig.CreateMapper();

            var categoryService = new CategoryService(this.context, mapper);

            var expectedFirstCategory = new Category
            {
                Name = "first"
            };

            var expectedSecondCategory = new Category
            {
                Name = "second"
            };

            await this.context.Categories.AddRangeAsync(expectedFirstCategory, expectedSecondCategory);
            await this.context.SaveChangesAsync();

            //Act
            var actualResultFirst = await categoryService.GetCategoryByName("first");
            var actualResultSecond = await categoryService.GetCategoryByName("second");

            //Assert
            Assert.Equal(expectedFirstCategory.Id, actualResultFirst.Id);
            Assert.Equal(expectedFirstCategory.Name, actualResultFirst.Name);

            Assert.Equal(expectedSecondCategory.Id, actualResultSecond.Id);
            Assert.Equal(expectedSecondCategory.Name, actualResultSecond.Name);

        }
    }
}
