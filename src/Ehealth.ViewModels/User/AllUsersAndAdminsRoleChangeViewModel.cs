using System.Collections.Generic;

namespace Ehealth.ViewModels.User
{
    public class AllUsersAndAdminsRoleChangeViewModel
    {
        public List<AllUsersIfnoViewModel> Users { get; set; }

        public List<AllUsersIfnoViewModel> Admins { get; set; }

    }
}
