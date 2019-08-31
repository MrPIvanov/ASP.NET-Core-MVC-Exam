using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
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
        private const int NumberOfRandomProductsOnHomePage = 9;
        private const string OrderCriteriaNameAsc = "nameasc";
        private const string OrderCriteriaNameDesc = "namedesc";
        private const string OrderCriteriaPriceAsc = "priceasc";
        private const string OrderCriteriaPriceDesc = "pricedesc";
        private const string OrderCriteriaMostPopular = "mostpopular";

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

            var mappedProducts = await this.mapper.ProjectTo<AllProductsViewModel>(allProducts).ToListAsync();

            return mappedProducts;
        }

        public async Task<List<AllProductsViewModel>> GetAllNotDeletedOrderByName()
        {
            var allProducts = this.context.Products.Where(p => p.isDeleted == false).OrderBy(p => p.Name);

            var mappedProducts = await this.mapper.ProjectTo<AllProductsViewModel>(allProducts).ToListAsync();

            return mappedProducts;
        }

        public async Task<List<AllProductsViewModel>> GetAllNotDeletedOrderByPurchaseCount()
        {
            var allProducts = this.context.Products.Where(p => p.isDeleted == false).OrderByDescending(p => p.PurchaseCount);

            var mappedProducts = await this.mapper.ProjectTo<AllProductsViewModel>(allProducts).ToListAsync();

            return mappedProducts;
        }

        public async Task<List<AllProductsViewModel>> GetRandomProductsForLandingPage()
        {
            var allProducts = this.context.Products
                .Where(p => p.isDeleted == false)
                .OrderByDescending(p => p.PurchaseCount);

            var maxNumberToSkip = allProducts.Count() - NumberOfRandomProductsOnHomePage;

            var mappedProducts = await this.mapper.ProjectTo<AllProductsViewModel>(allProducts)
                .Skip(new Random().Next(0, maxNumberToSkip))
                .Take(NumberOfRandomProductsOnHomePage)
                .ToListAsync();

            return mappedProducts;
        }

        public async Task<List<AllProductsViewModel>> GetAllProductsByCategoryNameAndSortCriteria(string id, string orderBy)
        {

            var allProducts = this.context.Products
                .Where(p => p.isDeleted == false);

            if (id.ToLower() != "all")
            {
                allProducts = allProducts.Where(p => p.CategoryId == id);
            }

            if (!string.IsNullOrEmpty(orderBy))
            {
                switch (orderBy.ToLower())
                {
                    case OrderCriteriaNameAsc:
                        allProducts = allProducts.OrderBy(x => x.Name);
                        break;
                    case OrderCriteriaNameDesc:
                        allProducts = allProducts.OrderByDescending(x => x.Name);
                        break;
                    case OrderCriteriaMostPopular:
                        allProducts = allProducts.OrderByDescending(x => x.PurchaseCount);
                        break;
                    case OrderCriteriaPriceAsc:
                        allProducts = allProducts.OrderBy(x => x.Price);
                        break;
                    case OrderCriteriaPriceDesc:
                        allProducts = allProducts.OrderByDescending(x => x.Price);
                        break;
                    default:
                        break;
                }
            }

            var mappedProducts = await this.mapper.ProjectTo<AllProductsViewModel>(allProducts).ToListAsync();

            return mappedProducts;
        }

        public async Task<List<AllProductsViewModel>> GetAllDeletedOrderByName()
        {
            var allProducts = this.context.Products.Where(p => p.isDeleted == true).OrderBy(p => p.Name);

            var mappedProducts = await this.mapper.ProjectTo<AllProductsViewModel>(allProducts).ToListAsync();

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

        public async Task<SingleProductViewModel> GetSingleProductViewModelById(string id)
        {
            var product = await this.context.Products.FirstOrDefaultAsync(p => p.Id == id);

            var mappedProduct = mapper.Map<SingleProductViewModel>(product);

            return mappedProduct;
        }

        public async Task<List<SingleProductViewModel>> GetAllPurchasedProductsByPurchaseId(string id)
        {
            var products = await this.context.PurchaseProducts.Where(p => p.PurchaseId == id)
                .Select(p => p.ProductId).ToListAsync();

            var mappedProducts = await mapper.ProjectTo<SingleProductViewModel>
                (this.context.Products.Where(p => products.Contains(p.Id))).ToListAsync();

            return mappedProducts;
        }
    }
}
