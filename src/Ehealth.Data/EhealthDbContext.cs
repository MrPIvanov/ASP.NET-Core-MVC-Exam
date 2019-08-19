using Ehealth.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Ehealth.Data
{
    public class EhealthDbContext : IdentityDbContext<User, Role, string>
    {
        public EhealthDbContext(DbContextOptions<EhealthDbContext> options)
            : base(options)
        {
        }
    }
}
