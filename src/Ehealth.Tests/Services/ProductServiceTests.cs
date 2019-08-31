using AutoMapper;
using Ehealth.BindingModels.Product;
using Ehealth.Data;
using Ehealth.Models;
using Ehealth.Services;
using Ehealth.ViewModels.Product;
using Ehealth.Web.Infrastructure.Mappings;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Ehealth.Tests.Services
{
    public class ProductServiceTests
    {
        private readonly EhealthDbContext context;

        public ProductServiceTests()
        {
            this.context = EhealthDbContextInMemoryFactory.InitializeInMemoryContext();
        }

        [Fact]
        public async Task AddNewProductFromInputModelTests()
        {
            //Arrange
            var mapperConfig = new MapperConfiguration(x => x.AddProfile(new MappingProfile()));
            var mapper = mapperConfig.CreateMapper();

            var productService = new ProductService(this.context, mapper);

            var firstProduct = new AddNewProductBindingModel
            {
                CategoryIdString = "CategoryId",
                Description = "Some Description",
                Name = "FirstProductName",
                Price = 12.2m,
                ProductUrl = "URL"
            };

            var secondProduct = new AddNewProductBindingModel
            {
                CategoryIdString = "CategoryId",
                Description = "Some Description",
                Name = "SecondProductName",
                Price = 22.2m,
                ProductUrl = "URL"
            };

            //Act
            Assert.Equal(0, this.context.Products.Count());

            await productService.AddNewProductFromInputModel(firstProduct);

            Assert.Equal(1, this.context.Products.Count());

            Assert.Equal("FirstProductName", this.context.Products.First().Name);

            await productService.AddNewProductFromInputModel(secondProduct);

            //Assert
            Assert.Equal(2, this.context.Products.Count());
        }

        [Fact]
        public async Task AddQuantityToItemTests()
        {
            //Arrange
            var mapperConfig = new MapperConfiguration(x => x.AddProfile(new MappingProfile()));
            var mapper = mapperConfig.CreateMapper();

            var productService = new ProductService(this.context, mapper);

            var product = new Product
            {
                Description = "Some Description",
                Name = "FirstProductName",
                Price = 12.2m,
                ProductUrl = "URL",
                CategoryId = "CategoryId",
                PurchaseCount = 5,
                Quantity = 5,

            };

            await this.context.Products.AddAsync(product);
            await this.context.SaveChangesAsync();

            //Act
            Assert.Equal(1, this.context.Products.Count());

            await productService.AddQuantityToItem(new AddQuantityToProductBindingModel
            {
                Quantity = 5,
                Id = product.Id
            });

            //Assert
            Assert.Equal(10, this.context.Products.First().Quantity);
        }

        [Fact]
        public async Task GetAllNotDeletedOrderByQuantityTests()
        {
            //Arrange
            var mapperConfig = new MapperConfiguration(x => x.AddProfile(new MappingProfile()));
            var mapper = mapperConfig.CreateMapper();

            var productService = new ProductService(this.context, mapper);

            var firstProduct = new Product
            {
                Description = "Some Description",
                Name = "FirstProductName",
                Price = 12.2m,
                ProductUrl = "URL",
                CategoryId = "CategoryId",
                PurchaseCount = 5,
                Quantity = 5,

            };

            var secondProduct = new Product
            {
                Description = "Some Description",
                Name = "SecondProductName",
                Price = 12.2m,
                ProductUrl = "URL",
                CategoryId = "CategoryId",
                PurchaseCount = 5,
                Quantity = 2,

            };

            var thirdProduct = new Product
            {
                Description = "Some Description",
                Name = "ThirdProductName",
                Price = 12.2m,
                ProductUrl = "URL",
                CategoryId = "CategoryId",
                PurchaseCount = 5,
                Quantity = 5,
                isDeleted = true

            };

            await this.context.Products.AddRangeAsync(firstProduct, secondProduct, thirdProduct);
            await this.context.SaveChangesAsync();

            //Act
            Assert.Equal(3, this.context.Products.Count());

            var actualResult = await productService.GetAllNotDeletedOrderByQuantity();
            //Assert
            Assert.Equal(2, actualResult.Count());
            Assert.Equal("SecondProductName", actualResult.First().Name);
        }

        [Fact]
        public async Task GetAllNotDeletedOrderByNameTests()
        {
            //Arrange
            var mapperConfig = new MapperConfiguration(x => x.AddProfile(new MappingProfile()));
            var mapper = mapperConfig.CreateMapper();

            var productService = new ProductService(this.context, mapper);

            var firstProduct = new Product
            {
                Description = "Some Description",
                Name = "FirstProductName",
                Price = 12.2m,
                ProductUrl = "URL",
                CategoryId = "CategoryId",
                PurchaseCount = 5,
                Quantity = 5,

            };

            var secondProduct = new Product
            {
                Description = "Some Description",
                Name = "SecondProductName",
                Price = 12.2m,
                ProductUrl = "URL",
                CategoryId = "CategoryId",
                PurchaseCount = 5,
                Quantity = 2,

            };

            var thirdProduct = new Product
            {
                Description = "Some Description",
                Name = "ThirdProductName",
                Price = 12.2m,
                ProductUrl = "URL",
                CategoryId = "CategoryId",
                PurchaseCount = 5,
                Quantity = 5,
                isDeleted = true

            };

            await this.context.Products.AddRangeAsync(firstProduct, secondProduct, thirdProduct);
            await this.context.SaveChangesAsync();

            //Act
            Assert.Equal(3, this.context.Products.Count());

            var actualResult = await productService.GetAllNotDeletedOrderByName();
            //Assert
            Assert.Equal(2, actualResult.Count());
            Assert.Equal("FirstProductName", actualResult.First().Name);
        }

        [Fact]
        public async Task GetAllNotDeletedOrderByPurchaseCountTests()
        {
            //Arrange
            var mapperConfig = new MapperConfiguration(x => x.AddProfile(new MappingProfile()));
            var mapper = mapperConfig.CreateMapper();

            var productService = new ProductService(this.context, mapper);

            var firstProduct = new Product
            {
                Description = "Some Description",
                Name = "FirstProductName",
                Price = 12.2m,
                ProductUrl = "URL",
                CategoryId = "CategoryId",
                PurchaseCount = 5,
                Quantity = 5,

            };

            var secondProduct = new Product
            {
                Description = "Some Description",
                Name = "SecondProductName",
                Price = 12.2m,
                ProductUrl = "URL",
                CategoryId = "CategoryId",
                PurchaseCount = 7,
                Quantity = 2,

            };

            var thirdProduct = new Product
            {
                Description = "Some Description",
                Name = "ThirdProductName",
                Price = 12.2m,
                ProductUrl = "URL",
                CategoryId = "CategoryId",
                PurchaseCount = 5,
                Quantity = 5,
                isDeleted = true

            };

            await this.context.Products.AddRangeAsync(firstProduct, secondProduct, thirdProduct);
            await this.context.SaveChangesAsync();

            //Act
            Assert.Equal(3, this.context.Products.Count());

            var actualResult = await productService.GetAllNotDeletedOrderByPurchaseCount();
            //Assert
            Assert.Equal(2, actualResult.Count());
            Assert.Equal("SecondProductName", actualResult.First().Name);
        }

        [Fact]
        public async Task GetAllProductsByCategoryNameAndSortCriteriaTests_WithCorectCategoryAndPriceCriteria()
        {
            //Arrange
            var mapperConfig = new MapperConfiguration(x => x.AddProfile(new MappingProfile()));
            var mapper = mapperConfig.CreateMapper();

            var productService = new ProductService(this.context, mapper);

            var firstProduct = new Product
            {
                Description = "Some Description",
                Name = "FirstProductName",
                Price = 12.2m,
                ProductUrl = "URL",
                CategoryId = "CategoryId",
                PurchaseCount = 5,
                Quantity = 5,

            };

            var secondProduct = new Product
            {
                Description = "Some Description",
                Name = "SecondProductName",
                Price = 22.2m,
                ProductUrl = "URL",
                CategoryId = "CategoryId",
                PurchaseCount = 7,
                Quantity = 2,

            };

            var thirdProduct = new Product
            {
                Description = "Some Description",
                Name = "ThirdProductName",
                Price = 12.2m,
                ProductUrl = "URL",
                CategoryId = "CategoryId",
                PurchaseCount = 5,
                Quantity = 5,
                isDeleted = true

            };

            await this.context.Products.AddRangeAsync(firstProduct, secondProduct, thirdProduct);
            await this.context.SaveChangesAsync();

            //Act
            Assert.Equal(3, this.context.Products.Count());

            var actualResult = await productService.GetAllProductsByCategoryNameAndSortCriteria("CategoryId", "pricedesc");
            //Assert
            Assert.Equal(2, actualResult.Count());
            Assert.Equal("SecondProductName", actualResult.First().Name);
        }

        [Fact]
        public async Task GetAllProductsByCategoryNameAndSortCriteriaTests_WithUncorectCategory()
        {
            //Arrange
            var mapperConfig = new MapperConfiguration(x => x.AddProfile(new MappingProfile()));
            var mapper = mapperConfig.CreateMapper();

            var productService = new ProductService(this.context, mapper);

            var firstProduct = new Product
            {
                Description = "Some Description",
                Name = "FirstProductName",
                Price = 12.2m,
                ProductUrl = "URL",
                CategoryId = "CategoryId",
                PurchaseCount = 5,
                Quantity = 5,

            };

            var secondProduct = new Product
            {
                Description = "Some Description",
                Name = "SecondProductName",
                Price = 22.2m,
                ProductUrl = "URL",
                CategoryId = "CategoryId",
                PurchaseCount = 7,
                Quantity = 2,

            };

            var thirdProduct = new Product
            {
                Description = "Some Description",
                Name = "ThirdProductName",
                Price = 12.2m,
                ProductUrl = "URL",
                CategoryId = "CategoryId",
                PurchaseCount = 5,
                Quantity = 5,
                isDeleted = true

            };

            await this.context.Products.AddRangeAsync(firstProduct, secondProduct, thirdProduct);
            await this.context.SaveChangesAsync();

            //Act
            Assert.Equal(3, this.context.Products.Count());

            var actualResult = await productService.GetAllProductsByCategoryNameAndSortCriteria("CategoryIddddd", "pricedesc");
            //Assert
            Assert.Empty(actualResult);
        }

        [Fact]
        public async Task GetAllProductsByCategoryNameAndSortCriteriaTests_WithCorectCategoryAndNameCriteria()
        {
            //Arrange
            var mapperConfig = new MapperConfiguration(x => x.AddProfile(new MappingProfile()));
            var mapper = mapperConfig.CreateMapper();

            var productService = new ProductService(this.context, mapper);

            var firstProduct = new Product
            {
                Description = "Some Description",
                Name = "FirstProductName",
                Price = 12.2m,
                ProductUrl = "URL",
                CategoryId = "CategoryId",
                PurchaseCount = 5,
                Quantity = 5,

            };

            var secondProduct = new Product
            {
                Description = "Some Description",
                Name = "SecondProductName",
                Price = 22.2m,
                ProductUrl = "URL",
                CategoryId = "CategoryId",
                PurchaseCount = 7,
                Quantity = 2,

            };

            var thirdProduct = new Product
            {
                Description = "Some Description",
                Name = "ThirdProductName",
                Price = 12.2m,
                ProductUrl = "URL",
                CategoryId = "CategoryId",
                PurchaseCount = 5,
                Quantity = 5,
                isDeleted = true

            };

            await this.context.Products.AddRangeAsync(firstProduct, secondProduct, thirdProduct);
            await this.context.SaveChangesAsync();

            //Act
            Assert.Equal(3, this.context.Products.Count());

            var actualResult = await productService.GetAllProductsByCategoryNameAndSortCriteria("CategoryId", "namedesc");
            //Assert
            Assert.Equal(2, actualResult.Count());
            Assert.Equal("SecondProductName", actualResult.First().Name);
        }


        [Fact]
        public async Task GetAllProductsByCategoryNameAndSortCriteriaTests_WithCorectCategoryAndPopularCriteria()
        {
            //Arrange
            var mapperConfig = new MapperConfiguration(x => x.AddProfile(new MappingProfile()));
            var mapper = mapperConfig.CreateMapper();

            var productService = new ProductService(this.context, mapper);

            var firstProduct = new Product
            {
                Description = "Some Description",
                Name = "FirstProductName",
                Price = 12.2m,
                ProductUrl = "URL",
                CategoryId = "CategoryId",
                PurchaseCount = 5,
                Quantity = 5,

            };

            var secondProduct = new Product
            {
                Description = "Some Description",
                Name = "SecondProductName",
                Price = 22.2m,
                ProductUrl = "URL",
                CategoryId = "CategoryId",
                PurchaseCount = 7,
                Quantity = 2,

            };

            var thirdProduct = new Product
            {
                Description = "Some Description",
                Name = "ThirdProductName",
                Price = 12.2m,
                ProductUrl = "URL",
                CategoryId = "CategoryId",
                PurchaseCount = 5,
                Quantity = 5,
                isDeleted = true

            };

            await this.context.Products.AddRangeAsync(firstProduct, secondProduct, thirdProduct);
            await this.context.SaveChangesAsync();

            //Act
            Assert.Equal(3, this.context.Products.Count());

            var actualResult = await productService.GetAllProductsByCategoryNameAndSortCriteria("CategoryId", "mostpopular");
            //Assert
            Assert.Equal(2, actualResult.Count());
            Assert.Equal("SecondProductName", actualResult.First().Name);
        }

        [Fact]
        public async Task GetAllDeletedOrderByNameTests()
        {
            //Arrange
            var mapperConfig = new MapperConfiguration(x => x.AddProfile(new MappingProfile()));
            var mapper = mapperConfig.CreateMapper();

            var productService = new ProductService(this.context, mapper);

            var firstProduct = new Product
            {
                Description = "Some Description",
                Name = "FirstProductName",
                Price = 12.2m,
                ProductUrl = "URL",
                CategoryId = "CategoryId",
                PurchaseCount = 5,
                Quantity = 5,

            };

            var secondProduct = new Product
            {
                Description = "Some Description",
                Name = "SecondProductName",
                Price = 22.2m,
                ProductUrl = "URL",
                CategoryId = "CategoryId",
                PurchaseCount = 7,
                Quantity = 2,

            };

            var thirdProduct = new Product
            {
                Description = "Some Description",
                Name = "ThirdProductName",
                Price = 12.2m,
                ProductUrl = "URL",
                CategoryId = "CategoryId",
                PurchaseCount = 5,
                Quantity = 5,
                isDeleted = true

            };

            await this.context.Products.AddRangeAsync(firstProduct, secondProduct, thirdProduct);
            await this.context.SaveChangesAsync();

            //Act
            Assert.Equal(3, this.context.Products.Count());

            var actualResult = await productService.GetAllDeletedOrderByName();
            //Assert
            Assert.Single(actualResult);
            Assert.Equal("ThirdProductName", actualResult.First().Name);
        }

        [Fact]
        public async Task GetEditBindingModelProductEntityTests()
        {
            //Arrange
            var mapperConfig = new MapperConfiguration(x => x.AddProfile(new MappingProfile()));
            var mapper = mapperConfig.CreateMapper();

            var productService = new ProductService(this.context, mapper);

            var firstProduct = new Product
            {
                Description = "Some Description",
                Name = "FirstProductName",
                Price = 12.2m,
                ProductUrl = "URL",
                CategoryId = "CategoryId",
                PurchaseCount = 5,
                Quantity = 5,

            };

            var secondProduct = new Product
            {
                Description = "Some Description",
                Name = "SecondProductName",
                Price = 22.2m,
                ProductUrl = "URL",
                CategoryId = "CategoryId",
                PurchaseCount = 7,
                Quantity = 2,

            };

            var thirdProduct = new Product
            {
                Description = "Some Description",
                Name = "ThirdProductName",
                Price = 12.2m,
                ProductUrl = "URL",
                CategoryId = "CategoryId",
                PurchaseCount = 5,
                Quantity = 5,
                isDeleted = true

            };

            await this.context.Products.AddRangeAsync(firstProduct, secondProduct, thirdProduct);
            await this.context.SaveChangesAsync();

            //Act
            Assert.Equal(3, this.context.Products.Count());

            var actualResult = await productService.GetEditBindingModelProductEntity(firstProduct.Id);
            //Assert
            Assert.Equal(actualResult.Name, firstProduct.Name);
            Assert.Equal(actualResult.Price, firstProduct.Price);
            Assert.Equal(actualResult.Id, firstProduct.Id);
            Assert.Equal(actualResult.Quantity, firstProduct.Quantity);
            Assert.Equal(actualResult.ProductUrl, firstProduct.ProductUrl);
            Assert.IsType<EditProductBindingModel>(actualResult);
        }

        [Fact]
        public async Task UpdateProductTests()
        {
            //Arrange
            var mapperConfig = new MapperConfiguration(x => x.AddProfile(new MappingProfile()));
            var mapper = mapperConfig.CreateMapper();

            var productService = new ProductService(this.context, mapper);

            var firstProduct = new Product
            {
                Description = "Some Description",
                Name = "FirstProductName",
                Price = 12.2m,
                ProductUrl = "URL",
                CategoryId = "CategoryId",
                PurchaseCount = 5,
                Quantity = 5,

            };

            await this.context.Products.AddAsync(firstProduct);
            await this.context.SaveChangesAsync();

            var newInputModel = new EditProductBindingModel
            {
                Quantity = 10,
                ProductUrl = "NewProductUrl",
                Id = firstProduct.Id,
                Name = "NewProductName",
                Price = 111.11m,
            };

            //Act
            Assert.Equal(1, this.context.Products.Count());

            await productService.UpdateProduct(newInputModel);

            //Assert
            Assert.Equal("NewProductUrl", firstProduct.ProductUrl);
            Assert.Equal(111.11m, firstProduct.Price);
            Assert.Equal(10, firstProduct.Quantity);
            Assert.Equal("NewProductName", firstProduct.Name);
        }

        [Fact]
        public async Task ToggleIsDeletedOnProductTests()
        {
            //Arrange
            var mapperConfig = new MapperConfiguration(x => x.AddProfile(new MappingProfile()));
            var mapper = mapperConfig.CreateMapper();

            var productService = new ProductService(this.context, mapper);

            var firstProduct = new Product
            {
                Description = "Some Description",
                Name = "FirstProductName",
                Price = 12.2m,
                ProductUrl = "URL",
                CategoryId = "CategoryId",
                PurchaseCount = 5,
                Quantity = 5,

            };

            await this.context.Products.AddAsync(firstProduct);
            await this.context.SaveChangesAsync();

            //Act
            Assert.Equal(1, this.context.Products.Count());

            await productService.ToggleIsDeletedOnProduct(firstProduct.Id);

            //Assert
            Assert.True(firstProduct.isDeleted);

            await productService.ToggleIsDeletedOnProduct(firstProduct.Id);

            Assert.False(firstProduct.isDeleted);
        }

        [Fact]
        public async Task GetSingleProductViewModelByIdTests()
        {
            //Arrange
            var mapperConfig = new MapperConfiguration(x => x.AddProfile(new MappingProfile()));
            var mapper = mapperConfig.CreateMapper();

            var productService = new ProductService(this.context, mapper);

            var firstProduct = new Product
            {
                Description = "Some Description",
                Name = "FirstProductName",
                Price = 12.2m,
                ProductUrl = "URL",
                CategoryId = "CategoryId",
                PurchaseCount = 5,
                Quantity = 5,

            };

            var secondProduct = new Product
            {
                Description = "Some Description",
                Name = "SecondProductName",
                Price = 22.2m,
                ProductUrl = "URL",
                CategoryId = "CategoryId",
                PurchaseCount = 7,
                Quantity = 2,

            };

            var thirdProduct = new Product
            {
                Description = "Some Description",
                Name = "ThirdProductName",
                Price = 12.2m,
                ProductUrl = "URL",
                CategoryId = "CategoryId",
                PurchaseCount = 5,
                Quantity = 5,
                isDeleted = true

            };

            await this.context.Products.AddRangeAsync(firstProduct, secondProduct, thirdProduct);
            await this.context.SaveChangesAsync();

            //Act
            Assert.Equal(3, this.context.Products.Count());

            var actualProduct = await productService.GetSingleProductViewModelById(firstProduct.Id);

            //Assert
            Assert.IsType<SingleProductViewModel>(actualProduct);
            Assert.Equal("FirstProductName", actualProduct.Name);
            Assert.Equal(12.2m, actualProduct.Price);
            Assert.Equal(5, actualProduct.Quantity);
        }

        [Fact]
        public async Task GetAllPurchasedProductsByPurchaseIdTests()
        {
            //Arrange
            var mapperConfig = new MapperConfiguration(x => x.AddProfile(new MappingProfile()));
            var mapper = mapperConfig.CreateMapper();

            var productService = new ProductService(this.context, mapper);

            var firstProduct = new Product
            {
                Description = "Some Description",
                Name = "FirstProductName",
                Price = 12.2m,
                ProductUrl = "URL",
                CategoryId = "CategoryId",
                PurchaseCount = 5,
                Quantity = 5,

            };

            var secondProduct = new Product
            {
                Description = "Some Description",
                Name = "SecondProductName",
                Price = 22.2m,
                ProductUrl = "URL",
                CategoryId = "CategoryId",
                PurchaseCount = 7,
                Quantity = 2,

            };

            var thirdProduct = new Product
            {
                Description = "Some Description",
                Name = "ThirdProductName",
                Price = 12.2m,
                ProductUrl = "URL",
                CategoryId = "CategoryId",
                PurchaseCount = 5,
                Quantity = 5,
                isDeleted = true

            };

            await this.context.Products.AddRangeAsync(firstProduct, secondProduct, thirdProduct);
            await this.context.SaveChangesAsync();

            var firstPurchaseProduct = new PurchaseProduct
            {
               Quantity = 5,
               ProductId = firstProduct.Id,
               PurchaseId = "PurchaseId",
            };

            var secondPurchaseProduct = new PurchaseProduct
            {
                Quantity = 5,
                ProductId = secondProduct.Id,
                PurchaseId = "PurchaseId",
            };

            var thirdPurchaseProduct = new PurchaseProduct
            {
                Quantity = 5,
                ProductId = thirdProduct.Id,
                PurchaseId = "PurchaseId22222222",
            };

            await this.context.PurchaseProducts.AddRangeAsync(firstPurchaseProduct, secondPurchaseProduct, thirdPurchaseProduct);
            await this.context.SaveChangesAsync();

            //Act
            Assert.Equal(3, this.context.PurchaseProducts.Count());

            var actualProducts = await productService.GetAllPurchasedProductsByPurchaseId(firstPurchaseProduct.PurchaseId);

            //Assert
            Assert.Equal(2, actualProducts.Count);
        }
    }
}
