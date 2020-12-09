using AutoMapper;
using FluentValidation.Results;
using MyApp.Application.Interfaces;
using MyApp.Application.ViewModels;
using MyApp.Domain.Commands.SizeCommands;
using MyApp.Domain.Interfaces;
using NetDevPack.Mediator;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Services
{
    public class SizeAppService : ISizeAppService
    {
        private readonly IMapper _mapper;
        private readonly ISizeRepository _sizeRepository;
        private readonly IMediatorHandler _mediator;

        public SizeAppService(IMapper mapper, ISizeRepository sizeRepository, IMediatorHandler mediator)
        {
            _mapper = mapper;
            _sizeRepository = sizeRepository;
            _mediator = mediator;
        }
        public async Task<ValidationResult> Add(SizeViewModel sizeViewModel)
        {
            var addCommand = _mapper.Map<AddSizeCommand>(sizeViewModel);
            return await _mediator.SendCommand(addCommand);
        }

        public async Task<ValidationResult> DeleteAsync(Guid[] ids)
        {
            var deleteCommand = new DeleteSizeCommand(ids);
            return await _mediator.SendCommand(deleteCommand);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public async Task<IEnumerable<SizeViewModel>> GetAll()
        {
            return _mapper.Map<IEnumerable<SizeViewModel>>(await _sizeRepository.GetAll());
        }

        public async Task<ValidationResult> Update(SizeViewModel sizeViewModel)
        {
            var updateCommand = _mapper.Map<UpdateSizeCommand>(sizeViewModel);
            return await _mediator.SendCommand(updateCommand);
        }
        public async Task<SizeViewModel> GetById(Guid id)
        {
            return _mapper.Map<SizeViewModel>(await _sizeRepository.GetById(id));
        }
    }
}
