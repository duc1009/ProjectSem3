using FluentValidation.Results;
using MediatR;
using MyApp.Domain.Interfaces;
using MyApp.Domain.Models;
using NetDevPack.Messaging;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MyApp.Domain.Commands.ManagerCommands
{
    public class ManagerCommandHandler : CommandHandler,
        IRequestHandler<CreateManagerCommand, ValidationResult>,
        IRequestHandler<RemoveManagerCommand, ValidationResult>,
        IRequestHandler<UpdateManagerCommand, ValidationResult>
    {
        private readonly IManagerRepository _managerRepository;
        public ManagerCommandHandler(IManagerRepository managerRepository)
        {
            _managerRepository = managerRepository;
        }

        public async Task<ValidationResult> Handle(CreateManagerCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) return message.ValidationResult;
            var manager = new MyManager(message.Id, message.ManagerId, message.UserId);
            if (await _managerRepository.GetByUserId(manager.UserId) != null)
            {
                AddError("The manager name has already been taken.");
                return ValidationResult;
            }
            _managerRepository.Add(manager);
            return await Commit(_managerRepository.UnitOfWork);
        }
        public async Task<ValidationResult> Handle(UpdateManagerCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) return message.ValidationResult;

            var manager = new MyManager(Guid.NewGuid().ToString(), message.ManagerId, message.UserId);

            var existingManager = await _managerRepository.GetByManagerId(manager.ManagerId);

            if (existingManager != null && existingManager.ManagerId != manager.ManagerId)
            {
                if (!existingManager.Equals(manager))
                {
                    AddError("The todoApp name has already been taken.");
                    return ValidationResult;
                }
            }

            _managerRepository.Update(manager);

            return await Commit(_managerRepository.UnitOfWork);
        }
        public async Task<ValidationResult> Handle(RemoveManagerCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) return message.ValidationResult;
            var manager = await _managerRepository.GetByUserId(message.UserId);
            if(manager == null)
            {
                AddError("User is not exist");
                return ValidationResult;
            }
            _managerRepository.Delete(manager);
            return await Commit(_managerRepository.UnitOfWork);
        }
    }
}
