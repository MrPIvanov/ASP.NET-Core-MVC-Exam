using AutoMapper;
using Ehealth.BindingModels.Product;
using Ehealth.Models;
using Ehealth.ViewModels.Product;

namespace Ehealth.Web.Infrastructure.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<AddNewProductBindingModel, Product>()
                     .ForMember(x => x.CategoryId, opt => opt.MapFrom(x => x.CategoryIdString));

            CreateMap<Product, AllProductsViewModel>();

            CreateMap<Product, EditProductBindingModel>();
        }
    }
}
