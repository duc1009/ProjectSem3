using FluentValidation.Results;
using MediatR;
using MyApp.Domain.Commands;
using MyApp.Domain.Interfaces;
using MyApp.Domain.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MyApp.Domain.CommandHandlers
{
    public class MaterialCommandHandler : NetDevPack.Messaging.CommandHandler,
        IRequestHandler<AddMaterialCommand, ValidationResult>,
         IRequestHandler<UpdateMaterialCommand, ValidationResult>,
        IRequestHandler<DeleteMaterialCommand, ValidationResult>
    {
        private readonly IMaterialRepository repository;
        //private readonly IUser user;

        public MaterialCommandHandler(IMaterialRepository repository)
        {           
            this.repository = repository;
        }
        public async Task<ValidationResult> Handle(AddMaterialCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) return message.ValidationResult;
            var Material = new Material(Guid.NewGuid(), message.Name);
            repository.Add(Material);
            
            return await Commit(repository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(UpdateMaterialCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) return message.ValidationResult;
          
            var existingMaterial = await repository.GetById(message.Id);

            if (existingMaterial ==null)
            {
                AddError("Material not found!");
                return ValidationResult;
            }
            existingMaterial.Name = message.Name;
            repository.UpDate(existingMaterial);
            return await Commit(repository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(DeleteMaterialCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {

                await Commit(repository.UnitOfWork);
            }
            var todoApp = await repository.GetById(message.Id);

            if (todoApp is null)
            {
                AddError("The Material doesn't exists.");
                return ValidationResult;
            }
            repository.Remove(todoApp);


            return await Commit(repository.UnitOfWork);
        }
    }
}
