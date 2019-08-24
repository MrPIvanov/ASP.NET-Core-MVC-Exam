using Ehealth.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Threading.Tasks;

namespace Ehealth.Data.Seeding
{
    public class EhealthUserSeeder : ISeeder
    {
        private readonly UserManager<User> userManager;
        private readonly EhealthDbContext context;

        public EhealthUserSeeder(UserManager<User> userManager, EhealthDbContext context)
        {
            this.userManager = userManager;
            this.context = context;
        }

        public async Task Seed()
        {
            var rootUser = new User
            {
                UserName = "root",
                Email = "root@root.com",
                PhoneNumber = "0 888 888 888",
                RegisteredOn = DateTime.UtcNow,
            };

            await this.userManager.CreateAsync(rootUser, "123");
            await userManager.AddToRoleAsync(rootUser, "root");

            var rootCart = new Cart
            {
                UserId = rootUser.Id,
            };

            await this.context.Carts.AddAsync(rootCart);

            rootUser.CartId = rootCart.Id;

            var admin = new User
            {
                UserName = "admin",
                Email = "admin@admin.com",
                PhoneNumber = "0 888 888 888",
                RegisteredOn = DateTime.UtcNow,
            };

            await this.userManager.CreateAsync(admin, "123");
            await userManager.AddToRoleAsync(admin, "admin");

            var adminCart = new Cart
            {
                UserId = admin.Id,
            };

            await this.context.Carts.AddAsync(adminCart);

            admin.CartId = adminCart.Id;

            var user = new User
            {
                UserName = "user",
                Email = "user@user.com",
                PhoneNumber = "0 888 888 888",
                RegisteredOn = DateTime.UtcNow,
            };

            await this.userManager.CreateAsync(user, "123");
            await userManager.AddToRoleAsync(user, "user");

            var userCart = new Cart
            {
                UserId = user.Id,
            };

            await this.context.Carts.AddAsync(userCart);

            user.CartId = userCart.Id;

            await this.context.SaveChangesAsync();
        }
    }
}
