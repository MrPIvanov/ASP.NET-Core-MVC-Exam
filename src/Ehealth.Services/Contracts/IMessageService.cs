using System.Threading.Tasks;

namespace Ehealth.Services.Contracts
{
    public interface IMessageService
    {
        Task CreateMessageForUserAndAddItToDb(string userId, string message);
    }
}
