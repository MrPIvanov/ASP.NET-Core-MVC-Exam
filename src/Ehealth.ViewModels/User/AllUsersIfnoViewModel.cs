using System;

namespace Ehealth.ViewModels.User
{
    public class AllUsersIfnoViewModel
    {
        public string Id { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public int PurchaseCount { get; set; }

        public string PhoneNumber { get; set; }

        public DateTime RegisteredOn { get; set; }
    }
}
