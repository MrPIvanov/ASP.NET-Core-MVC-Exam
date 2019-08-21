using Ehealth.ViewModels.Product;
using System.Collections.Generic;

namespace Ehealth.ViewModels.Category
{
    public class CategoryForSortAndFilterViewModel
    {
        public CategoryForSortAndFilterViewModel()
        {
            this.Products = new List<AllProductsViewModel>();
        }

        public string Id { get; set; }

        public string Name { get; set; }

        public List<AllProductsViewModel> Products { get; set; }
    }
}
