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
    public class ManagerAppService : IManagerAppService
    {
        private readonly IMapper _mapper;
        private readonly IManagerRepository _managerRepository;
        private readonly IMediatorHandler _mediator;

        public ManagerAppService(IMapper mapper, IManagerRepository managerRepository, IMediatorHandler mediator)
        {
            _mapper = mapper;
            _managerRepository = managerRepository;
            _mediator = mediator;
        }
        public async Task<IEnumerable<ManagerViewModel>> GetAllMember(string managerId)
        {
            return _mapper.Map<IEnumerable<ManagerViewModel>>(await _managerRepository.ListByManagerId(managerId));
        }

        public async Task<IEnumerable<ManagerViewModel>> GetAll()
        {
            return _mapper.Map<IEnumerable<ManagerViewModel>>(await _managerRepository.GetAll());
        }
        public async Task<bool> Find(ManagerViewModel manager)
        {
            var result = await _managerRepository.Get(manager.ManagerId, manager.UserId);
            return (result != null);
        }
        public async Task<ValidationResult> AddMember(ManagerViewModel manager)
        {
            var createCommand = _mapper.Map<CreateManagerCommand>(manager);
            return await _mediator.SendCommand(createCommand);
        }

        public async Task<ValidationResult> Remove(ManagerViewModel manager)
        {
            var removeCommand = _mapper.Map<RemoveManagerCommand>(manager);
            return await _mediator.SendCommand(removeCommand);
        }
        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
