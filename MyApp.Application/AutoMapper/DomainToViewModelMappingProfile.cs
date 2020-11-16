using AutoMapper;
using MyApp.Application.ViewModels;
using MyApp.Application.ViewModels.Manager;
using MyApp.Domain.Models;

namespace MyApp.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<TodoApp, TodoAppViewModel>();
            CreateMap<MyManager, ManagerViewModel>();
        }
    }
}
