using AutoMapper;
using FluentValidation.Results;
using MyApp.Application.Interfaces;
using MyApp.Application.ViewModels;
using MyApp.Domain.Commands;
using MyApp.Domain.Commands.Validations;
using MyApp.Domain.Interfaces;
using NetDevPack.Mediator;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyApp.Application.Services
{
    public class TodoAppService : ITodoAppService
    {
        private readonly IMapper _mapper;
        private readonly ITodoAppRepository _todoAppRepository;
        private readonly IMediatorHandler _mediator;

        public TodoAppService(IMapper mapper, ITodoAppRepository todoAppRepository, IMediatorHandler mediator)
        {
            _mapper = mapper;
            _todoAppRepository = todoAppRepository;
            _mediator = mediator;
        }

        public async Task<IEnumerable<TodoAppViewModel>> GetAll()
        {
            return _mapper.Map<IEnumerable<TodoAppViewModel>>(await _todoAppRepository.GetAll());
        }

        public async Task<IEnumerable<TodoAppViewModel>> FilterByStatus(string status)
        {
            return _mapper.Map<IEnumerable<TodoAppViewModel>>(await _todoAppRepository.FilterByStatus(status));
        }

        public async Task<TodoAppViewModel> GetById(Guid id)
        {
            return _mapper.Map<TodoAppViewModel>(await _todoAppRepository.GetById(id));
         }

        public async Task<ValidationResult> Register(TodoAppViewModel todoAppViewModel)
        {
            var registerCommand = _mapper.Map<CreateTodoAppCommand>(todoAppViewModel);
            return await _mediator.SendCommand(registerCommand);
        }

        public async Task<ValidationResult> Report(TodoAppViewModel todoAppViewModel)
        {
            var reportCommand = _mapper.Map<ReportTodoAppCommand>(todoAppViewModel);
            return await _mediator.SendCommand(reportCommand);
        }

        public async Task<ValidationResult> Remove(Guid id)
        {
            var removeCommand = new RemoveTodoAppCommand(id);
            return await _mediator.SendCommand(removeCommand);
        }

        public async Task<ValidationResult> Update(TodoAppViewModel todoAppViewModel)
        {
            var updateCommand = _mapper.Map<UpdateTodoAppCommand>(todoAppViewModel);
            return await _mediator.SendCommand(updateCommand);
        }

        public async Task<ValidationResult> IsDone(Guid id)
        {
            var isDoneCommand = _mapper.Map<IsDoneTodoAppCommand>(id);
            return await _mediator.SendCommand(isDoneCommand);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
