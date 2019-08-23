using Ehealth.Models;
using Ehealth.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;
using System.Threading;
using System.Threading.Tasks;

namespace Ehealth.Web.Hubs
{
    [Authorize]
    public class MessageHub : Hub
    {
        private const string ServerAnswerMessage = "All our operators are currently busy, Sorry";
        private const string ServerAnswerName = "Big Boss";

        private readonly IMessageService messageService;

        public MessageHub(IMessageService messageService)
        {
            this.messageService = messageService;
        }

        public async Task SendMessage(string message)
        {
            var userId = this.Context.UserIdentifier;

            await this.messageService.CreateMessageForUserAndAddItToDb(userId, message);

            await this.messageService.CreateMessageForUserAndAddItToDb(userId, ServerAnswerMessage);

            await this.Clients.Caller.SendAsync(
                 "NewMessage",
                 new Message
                 {
                     UserId = this.Context.User.Identity.Name,
                     Text = message,
                 });

            //Thread.Sleep(1111);

            await this.Clients.Caller.SendAsync(
                 "NewMessageFromAdmin",
                 new Message
                 {
                     UserId = ServerAnswerName,
                     Text = ServerAnswerMessage,
                 });
        }
    }
}
