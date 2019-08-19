using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(Ehealth.Web.Areas.Identity.IdentityHostingStartup))]
namespace Ehealth.Web.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
            });
        }
    }
}