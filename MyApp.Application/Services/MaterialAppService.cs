using AutoMapper;
using FluentValidation.Results;
using MyApp.Application.Interfaces;
using MyApp.Application.ViewModels.Manager;
using MyApp.Domain.Commands.ManagerCommands;
using MyApp.Domain.Interfaces;
using NetDevPack.Mediator;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;

namespace MyApp.Application.Services
{
    public class MaterialAppService : IMaterialAppService
    {
        private readonly IMapper mapper;
        private readonly IMaterialQueries queries;
        private readonly IMaterialRepository repository;
        private readonly IMediatorHandler Bus;

        public MaterialAppService(IMapper mapper, IMaterialQueries queries, IMaterialRepository repository, IMediatorHandler bus)
        {
            this.mapper = mapper;
            this.queries = queries;
            this.repository = repository;
            Bus = bus;
        }

        public void Add(MaterialViewModel MaterialViewModel)
        {
            var addCommand = mapper.Map<AddMaterialCommand>(MaterialViewModel);
            Bus.SendCommand(addCommand);
        }

        public void Delete(Guid[] ids)
        {
            var deleteCommand = new DeleteMaterialCommand(ids);
            Bus.SendCommand(deleteCommand);
        }

        public IEnumerable<MaterialViewModel> GetAll()
        {
            return repository.GetAll().ProjectTo<MaterialViewModel>(mapper.ConfigurationProvider);
        }

        public MaterialViewModel GetById(Guid id)
        {
            return mapper.Map<MaterialViewModel>(repository.Get(id));
        }

        public async Task<int> GetCountRecords(MaterialQueryModel urlQuery)
        {
            return await queries.GetCountRecords(urlQuery);
        }

        public async Task<IEnumerable<MaterialViewModel>> ListMaterials(MaterialQueryModel urlQuery)
        {
            var Materials = await queries.GetMaterial(urlQuery);
            return Materials.AsQueryable().ProjectTo<MaterialViewModel>(mapper.ConfigurationProvider);
        }

        public void Update(MaterialViewModel model)
        {
            var updateCommand = mapper.Map<UpdateMaterialCommand>(model);
            Bus.SendCommand(updateCommand);
        }
    }
}
