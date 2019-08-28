using AutoMapper;
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
    public class PurchaseServiceTests
    {
        private readonly EhealthDbContext context;

        public PurchaseServiceTests()
        {
            this.context = EhealthDbContextInMemoryFactory.InitializeInMemoryContext();
        }

        [Fact]
        public async Task CreatePurchaseByUserIdTests()
        {
            //Arrange
            var mapperConfig = new MapperConfiguration(x => x.AddProfile(new MappingProfile()));
            var mapper = mapperConfig.CreateMapper();

            var cartService = new CartService(this.context, mapper);
            
            var purchaseService = new PurchaseService(this.context, cartService, mapper);

            var user = new User
            {
                UserName = "user",
                Email = "user@user.com",
                PhoneNumber = "0 888 888 888",
                RegisteredOn = DateTime.UtcNow,
            };

            await this.context.Users.AddAsync(user);
            await this.context.SaveChangesAsync();

            var address = "newAddress";

            //Act
            Assert.Equal(0, this.context.Purchases.Count());

            await purchaseService.CreatePurchaseByUserId(user, address);
            await purchaseService.CreatePurchaseByUserId(user, address + "new");

            //Assert
            Assert.Equal(2, this.context.Purchases.Count());
        }

        [Fact]
        public async Task GetAllPurchasesInfoTests()
        {
            //Arrange
            var mapperConfig = new MapperConfiguration(x => x.AddProfile(new MappingProfile()));
            var mapper = mapperConfig.CreateMapper();

            var cartService = new CartService(this.context, mapper);

            var purchaseService = new PurchaseService(this.context, cartService, mapper);

            var firstPurchase = new Purchase
            {
                DeliveryAddress = "Address",
                PurchaseDate = DateTime.UtcNow,
                TotalPrice = 20,
                UserId = "UserId",                
            };

            var secondPurchase = new Purchase
            {
                DeliveryAddress = "Address",
                PurchaseDate = DateTime.UtcNow,
                TotalPrice = 20,
                UserId = "UserId",
            };

            await this.context.Purchases.AddRangeAsync(firstPurchase, secondPurchase);
            await this.context.SaveChangesAsync();


            //Act
            Assert.Equal(2, this.context.Purchases.Count());

            var actualResult = await purchaseService.GetAllPurchasesInfo();

            //Assert
            Assert.Equal(2, this.context.Purchases.Count());
            Assert.Equal(2, actualResult.Count());
        }
    }
}
