using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyApp.Infra.Data.Context;
using System;

namespace MyApp.Web.Ui.Configuration
{
    public static class IdentityConfig
    {

        public static void AddSocialAuthenticationConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddAuthentication()
                .AddFacebook(options =>
                {
                    options.AppId = configuration["Authentication:Facebook:AppId"];
                    options.AppSecret = configuration["Authentication:Facebook:AppSecret"];
                })
                .AddGoogle(options =>
                {
                    options.ClientId = "758758188715-hvtc8dlhi5j0o3q4relpeo949qgnb55i.apps.googleusercontent.com";
                    options.ClientSecret = "FZdUDcun5P9TYQY0x_dWSPdQ";
                });

        }
    }
}
