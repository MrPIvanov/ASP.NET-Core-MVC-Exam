using Ehealth.Models;
using System.Threading.Tasks;

namespace Ehealth.Data.Seeding
{
    public class EhealthCategorySeeder : ISeeder
    {
        private readonly EhealthDbContext context;

        public EhealthCategorySeeder(EhealthDbContext context)
        {
            this.context = context;
        }

        public async Task Seed()
        {
            this.context.Categories.Add(new Category
            {
                Name = "Bio Products",
            });

            this.context.Categories.Add(new Category
            {
                Name = "Baby Products",
            });

            this.context.Categories.Add(new Category
            {
                Name = "Sun Care",
            });

            this.context.Categories.Add(new Category
            {
                Name = "Food Supplements",
            });

            this.context.Categories.Add(new Category
            {
                Name = "Bio Cosmetics",
            });

            await this.context.SaveChangesAsync();
        }
    }
}
