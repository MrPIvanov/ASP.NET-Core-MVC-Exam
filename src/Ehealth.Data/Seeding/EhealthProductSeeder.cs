using Ehealth.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace Ehealth.Data.Seeding
{
    public class EhealthProductSeeder : ISeeder
    {
        private readonly EhealthDbContext context;

        public EhealthProductSeeder(EhealthDbContext context)
        {
            this.context = context;
        }

        public async Task Seed()
        {
            var bioProductsCategory = await context.Categories.FirstOrDefaultAsync(x => x.Name == "Bio Products");
            var babyProductsCategory = await context.Categories.FirstOrDefaultAsync(x => x.Name == "Baby Products");
            var sunCaresCategory = await context.Categories.FirstOrDefaultAsync(x => x.Name == "Sun Care");
            var foodSupplementsCategory = await context.Categories.FirstOrDefaultAsync(x => x.Name == "Food Supplements");
            var bioCosmeticsCategory = await context.Categories.FirstOrDefaultAsync(x => x.Name == "Bio Cosmetics");

            // Bio Products

            this.context.Products.Add(new Product
            {
                CategoryId = bioProductsCategory.Id,
                Name = "Organic Coconut Oil DRAGON SUPERFOODS 1L",
                Price = 27.90m,
                ProductUrl = "https://images-na.ssl-images-amazon.com/images/I/41y1KOcmGrL._AC_SY400_.jpg",
                Quantity = 4,
                PurchaseCount = 2,
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
            });

            this.context.Products.Add(new Product
            {
                CategoryId = bioProductsCategory.Id,
                Name = "Acerol Powder DRAGON SUPERFOODS 100 gr",
                Price = 37.20m,
                ProductUrl = "https://images-na.ssl-images-amazon.com/images/I/61-OWP%2BVkoL._SX385_.jpg",
                Quantity = 2,
                PurchaseCount = 2,
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
                isDeleted = true                
            });

            this.context.Products.Add(new Product
            {
                CategoryId = bioProductsCategory.Id,
                Name = "Goji berries Dragoil SUPERFUDS 100 gr",
                Price = 7.20m,
                ProductUrl = "https://m.media-amazon.com/images/I/61ejIcf1HoL._AC_UL320_.jpg",
                Quantity = 9,
                PurchaseCount = 2,
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
            });

            this.context.Products.Add(new Product
            {
                CategoryId = bioProductsCategory.Id,
                Name = "Cocoa Powder DRAGON SUPERFOODS 200 gr.",
                Price = 11.50m,
                ProductUrl = "https://images-na.ssl-images-amazon.com/images/I/91fAqnkz9xL._SX385_.jpg",
                Quantity = 7,
                PurchaseCount = 1,
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
            });

            this.context.Products.Add(new Product
            {
                CategoryId = bioProductsCategory.Id,
                Name = "Cocoa butter DRAGON SUPERFOODS 100 ML.",
                Price = 4.50m,
                ProductUrl = "https://images-eu.ssl-images-amazon.com/images/I/41iOU1AHbOL.jpg",
                Quantity = 17,
                PurchaseCount = 22,
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
            });

            // Baby Products

            this.context.Products.Add(new Product
            {
                CategoryId = babyProductsCategory.Id,
                Name = "HIP PUREED EARLY CARROTS 125 gr",
                Price = 3.20m,
                ProductUrl = "https://images-na.ssl-images-amazon.com/images/I/519yDsnXzaL._SY450_.jpg",
                Quantity = 23,
                PurchaseCount = 6,
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
            });

            this.context.Products.Add(new Product
            {
                CategoryId = babyProductsCategory.Id,
                Name = "HIP PUREED PUMPKIN 125 gr",
                Price = 3.10m,
                ProductUrl = "https://images-na.ssl-images-amazon.com/images/I/51XlhRgvh%2BL._SX466_.jpg",
                Quantity = 4,
                PurchaseCount = 9,
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
            });

            this.context.Products.Add(new Product
            {
                CategoryId = babyProductsCategory.Id,
                Name = "Kendamil Toddler Milk",
                Price = 21.50m,
                ProductUrl = "https://images-na.ssl-images-amazon.com/images/I/71urkNE6TnL._AC._SR360,460.jpg",
                Quantity = 0,
                PurchaseCount = 0,
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
            });

            this.context.Products.Add(new Product
            {
                CategoryId = babyProductsCategory.Id,
                Name = "PAMPERS PREMIUM 3 6-10 KG. X 60 pcs",
                Price = 34.50m,
                ProductUrl = "https://images-na.ssl-images-amazon.com/images/I/61JLvkDAqaL._SY355_.jpg",
                Quantity = 1,
                PurchaseCount = 22,
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
            });

            // Sun Care

            this.context.Products.Add(new Product
            {
                CategoryId = sunCaresCategory.Id,
                Name = "AVENE / Oven SUN SPRAY SPRAY FOR CHILDREN SPF 50+ 200ML.",
                Price = 73.10m,
                ProductUrl = "https://images-na.ssl-images-amazon.com/images/I/61o5mByBg9L._SY355_.jpg",
                Quantity = 3,
                PurchaseCount = 14,
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
            });

            this.context.Products.Add(new Product
            {
                CategoryId = sunCaresCategory.Id,
                Name = "VICHI IDEAL SOLEIL tinted cream SPF 60 AGAINST pigmentation 3 B 1 50 ML.",
                Price = 51.10m,
                ProductUrl = "https://images-na.ssl-images-amazon.com/images/I/61yvYJc-3dL._SY355_.jpg",
                Quantity = 2,
                PurchaseCount = 4,
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
            });

            // Food Supplements

            this.context.Products.Add(new Product
            {
                CategoryId = foodSupplementsCategory.Id,
                Name = "SOLGAR Glucosamine, Hyaluronic Acid, Chondroitin, MSM Tablets X 60 pcs",
                Price = 93.10m,
                ProductUrl = "https://images-na.ssl-images-amazon.com/images/I/91XfI1KnzzL._SY355_.jpg",
                Quantity = 1,
                PurchaseCount = 0,
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
            });

            this.context.Products.Add(new Product
            {
                CategoryId = foodSupplementsCategory.Id,
                Name = "SOLGAR SUPPORT FOR BONE TABLETS X 120 pcs",
                Price = 41.50m,
                ProductUrl = "https://images-na.ssl-images-amazon.com/images/I/71OU5n9wJ5L._SY355_.jpg",
                Quantity = 6,
                PurchaseCount = 19,
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
            });

            this.context.Products.Add(new Product
            {
                CategoryId = foodSupplementsCategory.Id,
                Name = "SOLGAR OMEGA-3-6-9 Capsules X 60 pcs",
                Price = 64.50m,
                ProductUrl = "https://images-na.ssl-images-amazon.com/images/I/41Mho1yf66L._SY355_.jpg",
                Quantity = 1,
                PurchaseCount = 28,
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
            });

            this.context.Products.Add(new Product
            {
                CategoryId = foodSupplementsCategory.Id,
                Name = "SOLGAR Folic Acid 400 MG. Tablets X 100 pcs",
                Price = 24.50m,
                ProductUrl = "https://images-na.ssl-images-amazon.com/images/I/71pvpR3DPnL._SY355_.jpg",
                Quantity = 5,
                PurchaseCount = 0,
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
            });

            this.context.Products.Add(new Product
            {
                CategoryId = foodSupplementsCategory.Id,
                Name = "SOLGAR ALL IN ONE TABLET X 100 Pcs",
                Price = 34.10m,
                ProductUrl = "https://images-na.ssl-images-amazon.com/images/I/41GjwWwEuZL._SY355_.jpg",
                Quantity = 2,
                PurchaseCount = 10,
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
            });

            this.context.Products.Add(new Product
            {
                CategoryId = foodSupplementsCategory.Id,
                Name = "SOLGAR CONCENTRATED FISH OIL 1000 MG. Capsules X 60 pcs",
                Price = 24.10m,
                ProductUrl = "https://images-na.ssl-images-amazon.com/images/I/81nHl0NZCEL._SY355_.jpg",
                Quantity = 9,
                PurchaseCount = 22,
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
            });

            this.context.Products.Add(new Product
            {
                CategoryId = foodSupplementsCategory.Id,
                Name = "SOLGAR L-GLUTATION 50 MG. Capsules X 30 pcs",
                Price = 74.10m,
                ProductUrl = "https://images-na.ssl-images-amazon.com/images/I/81cXESAji1L._SY355_.jpg",
                Quantity = 15,
                PurchaseCount = 33,
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
            });

            // Bio Cosmetics

            this.context.Products.Add(new Product
            {
                CategoryId = bioCosmeticsCategory.Id,
                Name = "AVENE COMPENSING NUTRITION CREAM 50 ML",
                Price = 164.50m,
                ProductUrl = "https://images-na.ssl-images-amazon.com/images/I/61ifC6wQPfL._SY450_.jpg",
                Quantity = 1,
                PurchaseCount = 21,
                Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum.",
            });

            await this.context.SaveChangesAsync();
        }
    }
}
