using AutoMapper;
using AutoMapper.QueryableExtensions;
using FluentValidation.Results;
using MyApp.Application.Interfaces;
using MyApp.Application.ViewModels;
using MyApp.Domain.Commands;
using MyApp.Domain.Interfaces;
using NetDevPack.Mediator;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyApp.Application.Services
{
    public class MaterialAppService : IMaterialAppService
    {
        private readonly IMapper mapper;
        private readonly IMaterialRepository repository;
        private readonly IMediatorHandler _mediator;

        public MaterialAppService(IMapper mapper, IMaterialRepository repository, IMediatorHandler mediator)
        {
            this.mapper = mapper;
            this.repository = repository;
            this._mediator = mediator;
        }

        public async Task<ValidationResult> Add(MaterialViewModel MaterialViewModel)
        {
            var addCommand = mapper.Map<AddMaterialCommand>(MaterialViewModel);
            return await _mediator.SendCommand(addCommand);
        }

        public void Delete(Guid[] ids)
        {
            var deleteCommand = new DeleteMaterialCommand(ids);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public async Task<IEnumerable<MaterialViewModel>> GetAll()
        {
            return mapper.Map<IEnumerable<MaterialViewModel>>(await repository.GetAll());
        }

        public async Task<ValidationResult> Update(MaterialViewModel model)
        {
            var updateCommand = mapper.Map<UpdateMaterialCommand>(model);
            return await _mediator.SendCommand(updateCommand);
        }

       
    }
}
