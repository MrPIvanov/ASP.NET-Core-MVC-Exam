using Ehealth.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Ehealth.Data.Seeding
{
    public class EhealthUserSeeder : ISeeder
    {
        private readonly UserManager<User> userManager;

        public EhealthUserSeeder(UserManager<User> userManager)
        {
            this.userManager = userManager;
        }

        public async Task Seed()
        {
            var rootUser = new User
            {
                UserName = "root",
                Email = "root@root.com",
            };

            await this.userManager.CreateAsync(rootUser, "123");
            await userManager.AddToRoleAsync(rootUser, "root");

            var admin = new User
            {
                UserName = "admin",
                Email = "admin@admin.com",
            };

            await this.userManager.CreateAsync(admin, "123");
            await userManager.AddToRoleAsync(admin, "admin");

            var user = new User
            {
                UserName = "user",
                Email = "user@user.com",
            };

            await this.userManager.CreateAsync(user, "123");
            await userManager.AddToRoleAsync(user, "user");
        }
    }
}
