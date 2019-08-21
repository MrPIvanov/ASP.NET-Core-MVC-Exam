using Ehealth.ViewModels.User;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ehealth.Services.Contracts
{
    public interface IUserService
    {
        Task<List<AllUsersIfnoViewModel>> GetAllUsersByName();

        Task<List<AllUsersIfnoViewModel>> GetAllAdminsByName();

        Task PromoteUserToAdmin(string id);

        Task DemoteAdminToUser(string id);

    }
}
