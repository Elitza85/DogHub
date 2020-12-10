using Microsoft.AspNetCore.Hosting;

[assembly: HostingStartup(typeof(DogHub.Web.Areas.Identity.IdentityHostingStartup))]

namespace DogHub.Web.Areas.Identity
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