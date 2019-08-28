using AutoMapper;
using Ehealth.BindingModels.Product;
using Ehealth.Data;
using Ehealth.Models;
using Ehealth.Services;
using Ehealth.Web.Infrastructure.Mappings;
using Moq;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Ehealth.Tests.Services
{
    public class CartServiceTests
    {
        private readonly EhealthDbContext context;

        public CartServiceTests()
        {
            this.context = EhealthDbContextInMemoryFactory.InitializeInMemoryContext();
        }

        [Fact]
        public async Task AddProductToUserCartTests()
        {
            //Arrange
            var mapperConfig = new MapperConfiguration(x => x.AddProfile(new MappingProfile()));
            var mapper = mapperConfig.CreateMapper();

            var cartService = new CartService(this.context, mapper);

            var product = new Mock<Product>().Object;

            product.Id = "Test-id";

            var productBindingModel = new BuyProductBindingModel
            {
                Id = product.Id,
                Quant = 3,
            };

            var user = new Mock<User>().Object;

            //Act
            Assert.Equal(0, context.CartProducts.Count());

            await cartService.AddProductToUserCart(productBindingModel, user);

            //Assert
            Assert.Equal(1, context.CartProducts.Count());
        }

        [Fact]
        public async Task RemoveProductFromUserCartTests()
        {
            //Arrange
            var mapperConfig = new MapperConfiguration(x => x.AddProfile(new MappingProfile()));
            var mapper = mapperConfig.CreateMapper();

            var cartService = new CartService(this.context, mapper);

            await this.context.CartProducts.AddAsync(new CartProduct
            {
                CartId = "cartId",
                ProductId = "productId",
                Quantity = 3,
            });

            await this.context.SaveChangesAsync();


            var user = new Mock<User>().Object;
            user.CartId = "cartId";

            //Act
            Assert.Equal(1, context.CartProducts.Count());

            await cartService.RemoveProductFromUserCart("productId", user);

            //Assert
            Assert.Equal(0, context.CartProducts.Count());
        }

        [Fact]
        public async Task GetAllProductsForCurrentUserTests()
        {
            //Arrange
            var mapperConfig = new MapperConfiguration(x => x.AddProfile(new MappingProfile()));
            var mapper = mapperConfig.CreateMapper();

            var cartService = new CartService(this.context, mapper);

            var user = new Mock<User>().Object;
            user.CartId = "cartId";

            var firstProduct = new Product
            {
                CategoryId = "categoryId",
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
                CategoryId = "categoryId",
                Name = "Goji berries Dragoil SUPERFUDS 100 gr",
                Price = 7.20m,
                ProductUrl = "https://m.media-amazon.com/images/I/61ejIcf1HoL._AC_UL320_.jpg",
                Quantity = 9,
                PurchaseCount = 2,
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
            };

            await this.context.Products.AddRangeAsync(firstProduct, secondProduct);
            await this.context.SaveChangesAsync();

            this.context.CartProducts.Add(new CartProduct
            {
                ProductId = firstProduct.Id,
                CartId = user.CartId,
                Quantity = 3,
            });

            this.context.CartProducts.Add(new CartProduct
            {
                ProductId = secondProduct.Id,
                CartId = user.CartId,
                Quantity = 3,
            });

            await this.context.SaveChangesAsync();

            //Act
            var actualResult = await cartService.GetAllProductsForCurrentUser(user);

            //Assert
            Assert.Equal(2, actualResult.Count());

            Assert.Equal("Acerol Powder DRAGON SUPERFOODS 100 gr", actualResult[0].Name);
        }
    }
}
