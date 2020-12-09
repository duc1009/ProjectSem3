using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MyApp.Infra.CrossCutting.Ioc;
using System;

namespace MyApp.Services.API.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void AddDependencyInjectionConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));
            NativeInjectorBootStrapper.RegisterServices(services, configuration);
        }
    }
}
