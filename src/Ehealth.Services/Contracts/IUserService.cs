using Ehealth.ViewModels.User;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ehealth.Services.Contracts
{
    public interface IUserService
    {
        Task<List<AllUsersIfnoViewModel>> GetAllUsersByName();

        Task<List<AllUsersIfnoViewModel>> GetAllAdminsByName();

        Task<bool> PromoteUserToAdmin(string id);

        Task<bool> DemoteAdminToUser(string id);

    }
}
