using Ehealth.Models;
using System.Threading.Tasks;

namespace Ehealth.Services.Contracts
{
    public interface IPurchaseService
    {
        Task CreatePurchaseByUserId(User user, string address);
    }
}
