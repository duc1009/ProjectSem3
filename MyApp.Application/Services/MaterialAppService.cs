using AutoMapper;
using AutoMapper.QueryableExtensions;
using MyApp.Application.Interfaces;
using MyApp.Application.ViewModels;
using MyApp.Application.ViewModels.Manager;
using MyApp.Domain.Commands;
using MyApp.Domain.Commands.ManagerCommands;
using MyApp.Domain.Interfaces;
using MyApp.Domain.ModelQueries;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;

namespace MyApp.Application.Services
{
    public class MaterialAppService : IMaterialAppService
    {
        private readonly IMapper mapper;
        private readonly IMaterialRepository repository;

        public MaterialAppService(IMapper mapper, IMaterialRepository repository)
        {
            this.mapper = mapper;
            this.repository = repository;
        }

        public void Add(MaterialViewModel MaterialViewModel)
        {
            var addCommand = mapper.Map<AddMaterialCommand>(MaterialViewModel);
        }

        public void Delete(Guid[] ids)
        {
            var deleteCommand = new DeleteMaterialCommand(ids);
        }

        public IEnumerable<MaterialViewModel> GetAll()
        {
            return repository.GetAll().ProjectTo<MaterialViewModel>(mapper.ConfigurationProvider);
        }

        public void Update(MaterialViewModel model)
        {
            var addCommand = mapper.Map<UpdateMaterialCommand>(model);
        }
       
    }
}
