using FluentValidation.Results;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using MyApp.Application.Interfaces;
using MyApp.Application.Services;
using MyApp.Domain.Commands;
using MyApp.Domain.Interfaces;
using MyApp.Infra.Data.Context;
using MyApp.Infra.Data.Repository;
using NetDevPack.Mediator;
using MyApp.Infra.CrossCutting.Bus;
using MyApp.Domain.Commands.Validations;
using MyApp.Domain.Commands.ManagerCommands;

namespace MyApp.Infra.CrossCutting.Ioc
{
    public static class NativeInjectorBootStrapper
    {
        
        public static void RegisterServices(IServiceCollection services)
        {
            // Domain Bus (Mediator)
            services.AddScoped<IMediatorHandler, InMemoryBus>();

            // Application
            services.AddScoped<ITodoAppService, TodoAppService>();
            services.AddScoped<IManagerAppService, ManagerAppService>();

            // Domain - Commands - todoApp
            services.AddScoped<IRequestHandler<CreateTodoAppCommand, ValidationResult>, TodoAppCommandHandler>();
            services.AddScoped<IRequestHandler<ReportTodoAppCommand, ValidationResult>, TodoAppCommandHandler>();
            services.AddScoped<IRequestHandler<RemoveTodoAppCommand, ValidationResult>, TodoAppCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateTodoAppCommand, ValidationResult>, TodoAppCommandHandler>();
            services.AddScoped<IRequestHandler<IsDoneTodoAppCommand, ValidationResult>, TodoAppCommandHandler>();

            //Domain - Command - manager
            services.AddScoped<IRequestHandler<CreateManagerCommand, ValidationResult>, ManagerCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateManagerCommand, ValidationResult>, ManagerCommandHandler>();
            services.AddScoped<IRequestHandler<RemoveManagerCommand, ValidationResult>, ManagerCommandHandler>();

            // Infra - Data
            services.AddScoped<ITodoAppRepository, TodoAppRepository>();
            services.AddScoped<IManagerRepository, ManagerRepository>();
            services.AddDbContext<ApplicationDbContext>();
        }

    }
}
