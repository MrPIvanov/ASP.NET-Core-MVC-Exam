using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Ehealth.BindingModels.Product;
using Ehealth.Data;
using Ehealth.Models;
using Ehealth.Services.Contracts;
using Ehealth.ViewModels.Product;
using Microsoft.EntityFrameworkCore;

namespace Ehealth.Services
{
    public class ProductService : IProductService
    {
        private readonly EhealthDbContext context;
        private readonly IMapper mapper;

        public ProductService(EhealthDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task AddNewProductFromInputModel(AddNewProductBindingModel input)
        {
            var productToAdd = this.mapper.Map<Product>(input);

            await this.context.Products.AddAsync(productToAdd);

            await this.context.SaveChangesAsync();
        }

        public async Task AddQuantityToItem(AddQuantityToProductBindingModel input)
        {
            var product = await this.context.Products.FirstOrDefaultAsync(p => p.Id == input.Id);

            product.Quantity += input.Quantity;

            await context.SaveChangesAsync();
        }

        public async Task<List<AllProductsViewModel>> GetAllNotDeletedOrderByQuantity()
        {
            var allProducts = this.context.Products.OrderBy(p => p.Quantity);

            var mappedProducts = this.mapper.ProjectTo<AllProductsViewModel>(allProducts).ToList();

            return mappedProducts;
        }
    }
}
