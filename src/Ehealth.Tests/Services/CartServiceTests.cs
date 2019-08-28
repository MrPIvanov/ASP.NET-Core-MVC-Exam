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
            await cartService.AddProductToUserCart(productBindingModel, user);

            //Assert
            Assert.Equal(1, context.CartProducts.Count());
        }
    }
}
