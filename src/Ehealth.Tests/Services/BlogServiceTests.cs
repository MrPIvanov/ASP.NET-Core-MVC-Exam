using Ehealth.Data;
using Moq;
using System.Threading.Tasks;
using Xunit;

namespace Ehealth.Tests.Services
{
    public class BlogServiceTests
    {
        private readonly EhealthDbContext context;

        public BlogServiceTests()
        {
            this.context = EhealthDbContextInMemoryFactory.InitializeInMemoryContext();
        }

        [Fact]
        public async Task AddNewBlogTests()
        {
            //Arrange

            //Act

            //Assert
        }
    }
}
