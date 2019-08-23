using Ehealth.Models;
using Ehealth.ViewModels.Purchase;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ehealth.Services.Contracts
{
    public interface IPurchaseService
    {
        Task CreatePurchaseByUserId(User user, string address);

        Task<List<PurchasesInfoViewModel>> GetAllPurchasesInfo();
    }
}
