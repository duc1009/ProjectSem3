using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using MyApp.Application.AutoMapper;
using System;

namespace MyApp.Web.Ui.Configuration
{
    public static class AutoMapperConfig
    {
        public static void AddAutoMapperConfiguration(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddAutoMapper(typeof(DomainToViewModelMappingProfile), typeof(ViewModelToDomainMappingProfile));
        }
    }
}
