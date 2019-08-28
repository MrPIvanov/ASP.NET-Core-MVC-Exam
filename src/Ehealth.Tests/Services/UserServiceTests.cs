using AutoMapper;
using Ehealth.Data;
using Ehealth.Models;
using Ehealth.Services;
using Ehealth.Web.Infrastructure.Mappings;
using Microsoft.AspNetCore.Identity;
using Moq;
using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Ehealth.Tests.Services
{
    public class UserServiceTests
    {
        private readonly EhealthDbContext context;

        public UserServiceTests()
        {
            this.context = EhealthDbContextInMemoryFactory.InitializeInMemoryContext();
        }

        private async Task PrepareContent()
        {
            var adminRole = new Role
            {
                Name = "admin",
                NormalizedName = "ADMIN"
            };

            var userRole = new Role
            {
                Name = "user",
                NormalizedName = "USER"
            };

            await this.context.Roles.AddRangeAsync(adminRole, userRole);
            await this.context.SaveChangesAsync();

            var rootUser = new User
            {
                UserName = "root",
                Email = "root@root.com",
                PhoneNumber = "0 888 888 888",
                RegisteredOn = DateTime.UtcNow,
            };

            var admin = new User
            {
                UserName = "admin",
                Email = "admin@admin.com",
                PhoneNumber = "0 888 888 888",
                RegisteredOn = DateTime.UtcNow,
            };

            var user = new User
            {
                UserName = "user",
                Email = "user@user.com",
                PhoneNumber = "0 888 888 888",
                RegisteredOn = DateTime.UtcNow,
            };

            await this.context.Users.AddRangeAsync(rootUser, admin, user);
            await this.context.SaveChangesAsync();

            await this.context.UserRoles.AddAsync(new IdentityUserRole<string>
            {
                RoleId = adminRole.Id,
                UserId = rootUser.Id,
            });

            await this.context.UserRoles.AddAsync(new IdentityUserRole<string>
            {
                RoleId = adminRole.Id,
                UserId = admin.Id,
            });

            await this.context.UserRoles.AddAsync(new IdentityUserRole<string>
            {
                RoleId = userRole.Id,
                UserId = user.Id,
            });

            await this.context.SaveChangesAsync();
        }

        [Fact]
        public async Task GetAllAdminsByNameTests()
        {
            //Arrange
            var mapperConfig = new MapperConfiguration(x => x.AddProfile(new MappingProfile()));
            var mapper = mapperConfig.CreateMapper();

            var store = new Mock<IUserStore<User>>();
            var userManager = new Mock<UserManager<User>>(store.Object, null, null, null, null, null, null, null, null).Object;

            var userService = new UserService(mapper, this.context, userManager);

            await this.PrepareContent();

            //Act

            var actualResult = await userService.GetAllAdminsByName();

            //Assert
            Assert.Equal(3, this.context.Users.Count());
            Assert.Equal(2, actualResult.Count());
        }

        [Fact]
        public async Task GetAllUsersByNameTests()
        {
            //Arrange
            var mapperConfig = new MapperConfiguration(x => x.AddProfile(new MappingProfile()));
            var mapper = mapperConfig.CreateMapper();

            var store = new Mock<IUserStore<User>>();
            var userManager = new Mock<UserManager<User>>(store.Object, null, null, null, null, null, null, null, null).Object;

            var userService = new UserService(mapper, this.context, userManager);

            await this.PrepareContent();

            //Act

            var actualResult = await userService.GetAllUsersByName();

            //Assert
            Assert.Equal(3, this.context.Users.Count());
            Assert.Single(actualResult);
        }

        [Fact]
        public async Task PromoteUserToAdminTests()
        {
            //Arrange
            var mapperConfig = new MapperConfiguration(x => x.AddProfile(new MappingProfile()));
            var mapper = mapperConfig.CreateMapper();

            var store = new Mock<IUserStore<User>>();
            var userManager = new Mock<UserManager<User>>(store.Object, null, null, null, null, null, null, null, null).Object;

            var userService = new UserService(mapper, this.context, userManager);

            var userRole = new Role
            {
                Name = "User",
                NormalizedName = "USER"
            };

            var adminRole = new Role
            {
                Name = "Admin",
                NormalizedName = "ADMIN"
            };

            await this.context.Roles.AddRangeAsync(userRole, adminRole);
            await this.context.SaveChangesAsync();

            var admin = new User
            {
                UserName = "admin",
                Email = "admin@admin.com",
                PhoneNumber = "0 888 888 888",
                RegisteredOn = DateTime.UtcNow,
            };

            var user = new User
            {
                UserName = "user",
                Email = "user@user.com",
                PhoneNumber = "0 888 888 888",
                RegisteredOn = DateTime.UtcNow,
            };

            await this.context.Users.AddRangeAsync(user, admin);
            await this.context.SaveChangesAsync();

            //Act

            var result = await userService.PromoteUserToAdmin(user.Id);

            //Assert
            Assert.Equal(2, this.context.Users.Count());
            Assert.True(result);
        }

        [Fact]
        public async Task DemoteAdminToUserTests()
        {
            //Arrange
            var mapperConfig = new MapperConfiguration(x => x.AddProfile(new MappingProfile()));
            var mapper = mapperConfig.CreateMapper();

            var store = new Mock<IUserStore<User>>();
            var userManager = new Mock<UserManager<User>>(store.Object, null, null, null, null, null, null, null, null).Object;

            var userService = new UserService(mapper, this.context, userManager);

            var userRole = new Role
            {
                Name = "User",
                NormalizedName = "USER"
            };

            var adminRole = new Role
            {
                Name = "Admin",
                NormalizedName = "ADMIN"
            };

            await this.context.Roles.AddRangeAsync(userRole, adminRole);
            await this.context.SaveChangesAsync();

            var admin = new User
            {
                UserName = "admin",
                Email = "admin@admin.com",
                PhoneNumber = "0 888 888 888",
                RegisteredOn = DateTime.UtcNow,
            };

            var user = new User
            {
                UserName = "user",
                Email = "user@user.com",
                PhoneNumber = "0 888 888 888",
                RegisteredOn = DateTime.UtcNow,
            };

            await this.context.Users.AddRangeAsync(user, admin);
            await this.context.SaveChangesAsync();

            //Act

            var result = await userService.DemoteAdminToUser(user.Id);

            //Assert
            Assert.Equal(2, this.context.Users.Count());
            Assert.True(result);
        }
    }
}
