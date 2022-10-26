using FitDash.Api.Data;
using FitDash.Api.Models;
using Microsoft.AspNetCore.Identity;

namespace FitDash.Api.Setup
{
    public static class IdentityConfig
    {
        public static void AddIdentityConfiguration(this IServiceCollection services)
        {
            services.AddIdentity<User, IdentityRole<Guid>>(options =>
            {
                options.User.RequireUniqueEmail = true;
            })
            .AddEntityFrameworkStores<IdentityContext>()
            .AddDefaultTokenProviders();
        }

    }
}
