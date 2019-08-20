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
            var allProducts = this.context.Products.Where(p => p.isDeleted == false).OrderBy(p => p.Quantity);

            var mappedProducts = this.mapper.ProjectTo<AllProductsViewModel>(allProducts).ToList();

            return mappedProducts;
        }

        public async Task<List<AllProductsViewModel>> GetAllNotDeletedOrderByName()
        {
            var allProducts = this.context.Products.Where(p => p.isDeleted == false).OrderBy(p => p.Name);

            var mappedProducts = this.mapper.ProjectTo<AllProductsViewModel>(allProducts).ToList();

            return mappedProducts;
        }

        public async Task<List<AllProductsViewModel>> GetAllNotDeletedOrderByPurchaseCount()
        {
            var allProducts = this.context.Products.Where(p => p.isDeleted == false).OrderByDescending(p => p.PurchaseCount);

            var mappedProducts = this.mapper.ProjectTo<AllProductsViewModel>(allProducts).ToList();

            return mappedProducts;
        }

        public async Task<List<AllProductsViewModel>> GetAllDeletedOrderByName()
        {
            var allProducts = this.context.Products.Where(p => p.isDeleted == true).OrderBy(p => p.Name);

            var mappedProducts = this.mapper.ProjectTo<AllProductsViewModel>(allProducts).ToList();

            return mappedProducts;
        }

        public async Task<EditProductBindingModel> GetEditBindingModelProductEntity(string id)
        {
            var product = await this.context.Products.FirstOrDefaultAsync(p => p.Id == id);

            var mappedProduct = mapper.Map<EditProductBindingModel>(product);

            return mappedProduct;
        }

        public async Task UpdateProduct(EditProductBindingModel input)
        {
            var product = await this.context.Products.FirstOrDefaultAsync(x => x.Id == input.Id);

            product.Name = input.Name;
            product.Price = input.Price;
            product.ProductUrl = input.ProductUrl;
            product.Quantity = input.Quantity;

            await this.context.SaveChangesAsync();
        }

        public async Task ToggleIsDeletedOnProduct(string id)
        {
            var product = await this.context.Products.FirstOrDefaultAsync(p => p.Id == id);

            var currentValue = product.isDeleted;

            product.isDeleted = !currentValue;

            await context.SaveChangesAsync();
        }
    }
}
