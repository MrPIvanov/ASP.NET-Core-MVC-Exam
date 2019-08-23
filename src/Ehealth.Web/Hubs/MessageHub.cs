using Ehealth.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;

namespace Ehealth.Web.Hubs
{
    [Authorize]
    public class MessageHub : Hub
    {
        public async Task SendMessage(string message)
        {
            await this.Clients.Caller.SendAsync(
                 "NewMessage",
                 new Message { UserId = this.Context.User.Identity.Name, Text = message, });
        }
    }
}
