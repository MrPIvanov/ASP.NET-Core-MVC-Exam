using Ehealth.Data;
using Microsoft.EntityFrameworkCore;
using System;

namespace Ehealth.Tests
{
    public static class EhealthDbContextInMemoryFactory
    {
        public static EhealthDbContext InitializeInMemoryContext()
        {
            var options = new DbContextOptionsBuilder<EhealthDbContext>()
               .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
               .Options;

            return new EhealthDbContext(options);
        }
    }
}
