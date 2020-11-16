using AutoMapper;
using MyApp.Application.ViewModels;
using MyApp.Application.ViewModels.Manager;
using MyApp.Domain.Commands;
using MyApp.Domain.Commands.ManagerCommands;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            // todoApp
            CreateMap<TodoAppViewModel, CreateTodoAppCommand>()
                .ConstructUsing(c => new CreateTodoAppCommand(c.Name, c.Content, c.FinishedAt));
            CreateMap<TodoAppViewModel, ReportTodoAppCommand>()
                .ConstructUsing(c => new ReportTodoAppCommand(c.Id, c.CreatedAt, c.Status, c.Description));
            CreateMap<TodoAppViewModel, UpdateTodoAppCommand>()
                .ConstructUsing(c => new UpdateTodoAppCommand(c.Id, c.Name, c. CreatedAt, c.Content, c.FinishedAt));

            //manager

            CreateMap<ManagerViewModel, CreateManagerCommand>()
                 .ConstructUsing(m => new CreateManagerCommand(m.Id, m.ManagerId, m.UserId));
            CreateMap<ManagerViewModel, UpdateManagerCommand>()
                 .ConstructUsing(m => new UpdateManagerCommand(m.ManagerId, m.UserId));
            CreateMap<ManagerViewModel, RemoveManagerCommand>()
                 .ConstructUsing(m => new RemoveManagerCommand(m.ManagerId));
        }

    }
}
