using System.Threading.Tasks;
using AutoMapper;
using Ehealth.BindingModels.Product;
using Ehealth.Data;
using Ehealth.Models;
using Ehealth.Services.Contracts;

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
    }
}
