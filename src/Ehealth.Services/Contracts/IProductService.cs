using Ehealth.BindingModels.Product;
using System.Threading.Tasks;

namespace Ehealth.Services.Contracts
{
    public interface IProductService
    {
        Task AddNewProductFromInputModel(AddNewProductBindingModel input);
    }
}
