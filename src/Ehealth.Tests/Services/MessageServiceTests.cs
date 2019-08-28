using Ehealth.Data;
using Ehealth.Services;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Ehealth.Tests.Services
{
    public class MessageServiceTests
    {
        private readonly EhealthDbContext context;

        public MessageServiceTests()
        {
            this.context = EhealthDbContextInMemoryFactory.InitializeInMemoryContext();
        }

        [Fact]
        public async Task CreateMessageForUserAndAddItToDbTests()
        {
            //Arrange
            var messageService = new MessageService(this.context);

            var userId = "TestUserId";

            var message = "TestMessage";

            //Act
            Assert.Equal(0, this.context.Messages.Count());

            await messageService.CreateMessageForUserAndAddItToDb(userId, message);
            await messageService.CreateMessageForUserAndAddItToDb(userId, message);
            await messageService.CreateMessageForUserAndAddItToDb(userId, message);

            //Assert
            Assert.Equal(3, this.context.Messages.Count());
        }
    }
}
