using Ehealth.Models;
using System.Threading.Tasks;

namespace Ehealth.Data.Seeding
{
    public class EhealthUserRoleSeeder : ISeeder
    {
        private readonly EhealthDbContext context;

        public EhealthUserRoleSeeder(EhealthDbContext context)
        {
            this.context = context;
        }

        public async Task Seed()
        {
            context.Roles.Add(new Role
            {
                Name = "Root",
                NormalizedName = "ROOT"
            });

            context.Roles.Add(new Role
            {
                Name = "Admin",
                NormalizedName = "ADMIN"
            });

            context.Roles.Add(new Role
            {
                Name = "User",
                NormalizedName = "USER"
            });

            await context.SaveChangesAsync();
        }
    }
}
