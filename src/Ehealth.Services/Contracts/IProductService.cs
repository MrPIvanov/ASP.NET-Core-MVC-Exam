﻿using Ehealth.BindingModels.Product;
using Ehealth.ViewModels.Product;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ehealth.Services.Contracts
{
    public interface IProductService
    {
        Task AddNewProductFromInputModel(AddNewProductBindingModel input);

        Task<List<AllProductsViewModel>> GetAllNotDeletedOrderByQuantity();

        Task<List<AllProductsViewModel>> GetAllNotDeletedOrderByName();

        Task AddQuantityToItem(AddQuantityToProductBindingModel input);

        Task<EditProductBindingModel> GetEditBindingModelProductEntity(string id);

        Task UpdateProduct(EditProductBindingModel input);
    }
}
