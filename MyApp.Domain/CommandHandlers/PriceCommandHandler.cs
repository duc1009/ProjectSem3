using FluentValidation.Results;
using MediatR;
using MyApp.Domain.Commands.PriceCommands;
using MyApp.Domain.Interfaces;
using MyApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyApp.Domain.CommandHandlers
{
    public class PriceCommandHandler : NetDevPack.Messaging.CommandHandler,
       IRequestHandler<AddPriceCommand, ValidationResult>,
        IRequestHandler<UpdatePriceCommand, ValidationResult>,
       IRequestHandler<DeletePriceCommand, ValidationResult>
    {
        private readonly IPriceRepository _repository;
        //private readonly IUser user;

        public PriceCommandHandler(IPriceRepository repository)
        {
            _repository = repository;
        }
        public async Task<ValidationResult> Handle(AddPriceCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) return message.ValidationResult;
            var price = new Price(Guid.NewGuid(), message.MaterialId,message.SizeId,message.Value);
            _repository.Add(price);

            return await Commit(_repository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(UpdatePriceCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) return message.ValidationResult;
      
            var existingPrice = await _repository.GetById(message.Id);
            if (existingPrice==null)
            {
                AddError("The price not found.");
                return ValidationResult;
            }
            existingPrice.MaterialId = message.MaterialId;
            existingPrice.SizeId = message.SizeId;
            existingPrice.Value = message.Value;
            _repository.Update(existingPrice);

            return await Commit(_repository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(DeletePriceCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {

                await Commit(_repository.UnitOfWork);
            }
            var todoApp = await _repository.GetById(message.Id);

            if (todoApp is null)
            {
                AddError("The Material doesn't exists.");
                return ValidationResult;
            }
            _repository.Remove(todoApp);


            return await Commit(_repository.UnitOfWork);
        }
    }
}
