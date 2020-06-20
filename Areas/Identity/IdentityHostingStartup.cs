using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PRORegister.Data;

[assembly: HostingStartup(typeof(PRORegister.Areas.Identity.IdentityHostingStartup))]
namespace PRORegister.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<PRORegisterContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("PRORegisterContextConnection")));

                services.AddDefaultIdentity<ApplicationUser>(options =>
                {
                    options.SignIn.RequireConfirmedAccount = false;
                    options.Password.RequireNonAlphanumeric = false;
                    options.Password.RequireUppercase = false;
                    options.Password.RequireDigit = true;
                    options.Password.RequiredLength = 8;

                })              

                    .AddEntityFrameworkStores<PRORegisterContext>();
            });
        }
    }
}