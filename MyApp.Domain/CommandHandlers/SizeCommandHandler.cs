using FluentValidation.Results;
using MediatR;
using MyApp.Domain.Commands.SizeCommands;
using MyApp.Domain.Interfaces;
using MyApp.Domain.Models;
using NetDevPack.Messaging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyApp.Domain.CommandHandlers
{
    public class SizeCommandHandler : CommandHandler,
    IRequestHandler<AddSizeCommand, ValidationResult>,
     IRequestHandler<UpdateSizeCommand, ValidationResult>,
    IRequestHandler<DeleteSizeCommand, ValidationResult>
    {
        private readonly ISizeRepository _repository;
        //private readonly IUser user;

        public SizeCommandHandler(ISizeRepository repository)
        {
            _repository = repository;
        }
        public async Task<ValidationResult> Handle(AddSizeCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) return message.ValidationResult;
            var size = new Size(Guid.NewGuid(), message.Name);
            _repository.Add(size);

            return await Commit(_repository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(UpdateSizeCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) return message.ValidationResult;

            var existingSize = await _repository.GetById(message.Id);

            if (existingSize == null)
            {
                AddError("The size not found.");
                return ValidationResult;
            }
            existingSize.Name = message.Name;

            _repository.Update(existingSize);
            return await Commit(_repository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(DeleteSizeCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {

                await Commit(_repository.UnitOfWork);
            }
            foreach (var item in message.Ids)
            {
                var existing = await _repository.GetById(item);
                if (existing != null)
                {
                    existing.IsDeleted = true;
                    _repository.Update(existing);
                }
            }
            return await Commit(_repository.UnitOfWork);
        }
    }
}
