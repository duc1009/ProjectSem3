using Microsoft.Extensions.DependencyInjection;
using MyApp.Infra.CrossCutting.Ioc;
using System;

namespace MyApp.Web.Ui.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void AddDependencyInjectionConfiguration(this IServiceCollection services, Microsoft.Extensions.Configuration.IConfiguration configuration)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));
            NativeInjectorBootStrapper.RegisterServices(services);
        }
    }
}
