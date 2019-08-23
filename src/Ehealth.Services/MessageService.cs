using System;
using System.Threading.Tasks;
using Ehealth.Data;
using Ehealth.Models;
using Ehealth.Services.Contracts;

namespace Ehealth.Services
{
    public class MessageService : IMessageService
    {
        private readonly EhealthDbContext context;

        public MessageService(EhealthDbContext context)
        {
            this.context = context;
        }

        public async Task CreateMessageForUserAndAddItToDb(string userId, string message)
        {
            await this.context.Messages.AddAsync(new Message
            {
                Text = message,
                UserId = userId,
                SendOn = DateTime.UtcNow,
            });

            await context.SaveChangesAsync();
        }
    }
}
