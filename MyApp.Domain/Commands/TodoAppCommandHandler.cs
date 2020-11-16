using FluentValidation.Results;
using MediatR;
using MyApp.Domain.Commands.Validations;
using MyApp.Domain.Interfaces;
using NetDevPack.Messaging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MyApp.Domain.Commands
{
    public class TodoAppCommandHandler : CommandHandler,
       IRequestHandler<CreateTodoAppCommand, ValidationResult>,
       IRequestHandler<ReportTodoAppCommand, ValidationResult>,
       IRequestHandler<RemoveTodoAppCommand, ValidationResult>,
       IRequestHandler<UpdateTodoAppCommand, ValidationResult>,
       IRequestHandler<IsDoneTodoAppCommand, ValidationResult>

    {
        private readonly ITodoAppRepository _todoAppRepository;

        public TodoAppCommandHandler(ITodoAppRepository todoAppRepository)
        {
            _todoAppRepository = todoAppRepository;
        }

        public async Task<ValidationResult> Handle(CreateTodoAppCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) return message.ValidationResult;

            var todoApp = new Models.TodoApp(Guid.NewGuid(), message.Name, message.Content, DateTime.Now, message.FinishedAt, false, null, null);

            if (await _todoAppRepository.GetByName(todoApp.Name) != null)
            {
                AddError("The todoApp name has already been taken.");
                return ValidationResult;
            }

            _todoAppRepository.Add(todoApp);

            return await Commit(_todoAppRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(ReportTodoAppCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) return message.ValidationResult;
            var todoApp = new Models.TodoApp(
                message.Id,
                message.Name,
                message.Content,
                message.CreateAt,
                message.FinishedAt,
                true,
                message.Status,
                message.Description
                );
            var existingTodoApp = await _todoAppRepository.GetByName(todoApp.Name);

            if (existingTodoApp != null && existingTodoApp.Id != todoApp.Id)
            {
                if (!existingTodoApp.Equals(todoApp))
                {
                    AddError("The todoApp name has already been taken.");
                    return ValidationResult;
                }
            }   
            _todoAppRepository.Update(todoApp);

            return await Commit(_todoAppRepository.UnitOfWork);
        }
        public async Task<ValidationResult> Handle(UpdateTodoAppCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) return message.ValidationResult;

            var todoApp = new Models.TodoApp(
                message.Id,
                message.Name,
                message.Content,
                message.CreateAt,
                message.FinishedAt,
                message.Reported,
                message.Status,
                message.Description
                );
            var existingTodoApp = await _todoAppRepository.GetByName(todoApp.Name);

            if (existingTodoApp != null && existingTodoApp.Id != todoApp.Id)
            {
                if (!existingTodoApp.Equals(todoApp))
                {
                    AddError("The todoApp name has already been taken.");
                    return ValidationResult;
                }
            }

            _todoAppRepository.Update(todoApp);

            return await Commit(_todoAppRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(RemoveTodoAppCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) return message.ValidationResult;

            var todoApp = await _todoAppRepository.GetById(message.Id);

            if (todoApp is null)
            {
                AddError("The todoApp doesn't exists.");
                return ValidationResult;
            }
            _todoAppRepository.Remove(todoApp);

            return await Commit(_todoAppRepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(IsDoneTodoAppCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) return message.ValidationResult;

            var todoApp = await _todoAppRepository.GetById(message.Id);

            if (todoApp is null)
            {
                AddError("The todoApp doesn't exists.");
                return ValidationResult;
            }

            var newTodoApp = new Models.TodoApp(
               message.Id,
              todoApp.Name,
               todoApp.Content,
               todoApp.CreatedAt,
               todoApp.FinishedAt,
               true,
               "Hoàn thành",
               todoApp.Description
               );
            _todoAppRepository.Update(newTodoApp);

            return await Commit(_todoAppRepository.UnitOfWork);

        }
        public void Dispose()
        {
            _todoAppRepository.Dispose();
        }
    }
}
