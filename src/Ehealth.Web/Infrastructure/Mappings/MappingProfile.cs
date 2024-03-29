﻿using AutoMapper;
using Ehealth.BindingModels.Blog;
using Ehealth.BindingModels.Category;
using Ehealth.BindingModels.Product;
using Ehealth.Models;
using Ehealth.ViewModels.Blog;
using Ehealth.ViewModels.Cart;
using Ehealth.ViewModels.Category;
using Ehealth.ViewModels.Product;
using Ehealth.ViewModels.Purchase;
using Ehealth.ViewModels.User;
using System.Linq;

namespace Ehealth.Web.Infrastructure.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AddNewProductBindingModel, Product>()
                     .ForMember(x => x.CategoryId, opt => opt.MapFrom(x => x.CategoryIdString));

            CreateMap<Product, SingleProductViewModel>();

            CreateMap<Product, AllProductsViewModel>();

            CreateMap<Product, EditProductBindingModel>();

            CreateMap<Product, CartSingleProductViewModel>();

            CreateMap<AddNewCategoryBindingModel, Category>();

            CreateMap<Category, AllCategoriesByPurchaseCountViewModel>()
                .ForMember(x => x.ProductsCount, opt => opt.MapFrom(x => x.Products.Count))
                .ForMember(x => x.TotalPurchaseCount, opt => opt.MapFrom(x => x.Products.Sum(p => p.PurchaseCount)));

            CreateMap<User, AllUsersIfnoViewModel>()
                .ForMember(x => x.PurchaseCount, opt => opt.MapFrom(x => x.PurchaseHistory.Count));

            CreateMap<Purchase, PurchasesInfoViewModel>();

            CreateMap<Blog, BlogSingleViewModel>();

            CreateMap<BlogAddNewBingingModel, Blog>();
        }
    }
}
