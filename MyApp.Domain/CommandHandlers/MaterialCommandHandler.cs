
using ETC.EQM.Domain.Core.Notifications;
using MediatR;
using MyApp.Domain.Commands;
using MyApp.Domain.Interfaces;
using MyApp.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyApp.Domain.CommandHandlers
{
    public class MaterialCommandHandler : NetDevPack.Messaging.CommandHandler,
        IRequestHandler<AddMaterialCommand, bool>,
         IRequestHandler<UpdateMaterialCommand, bool>,
        IRequestHandler<DeleteMaterialCommand, bool>
    {
        private readonly IMaterialRepository repository;
        //private readonly IUser user;

        public MaterialCommandHandler(IMaterialRepository repository)
        {
           
            this.repository = repository;

        }
        public Task<bool> Handle(AddMaterialCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
               
                return Task.FromResult(false);
            }
            var Material = new Material(Guid.NewGuid(), message.Name);
            repository.Add(Material);
            
            return Task.FromResult(false);
        }

        public Task<bool> Handle(UpdateMaterialCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
               
                return Task.FromResult(false);
            }
            var existing = repository.Get(message.Id);
            if (existing != null)
            {
                existing.Update(message.Name);
                repository.Update(existing);
            }

            return Task.FromResult(false);
        }

        public Task<bool> Handle(DeleteMaterialCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
               
                return Task.FromResult(false);
            }
            foreach (var item in message.Ids)
            {
                var existing = repository.Get(item);
                if (existing != null)
                {
                    existing.Delete();
                    repository.Update(existing);                   
                }
            }
            
            return Task.FromResult(false);
        }
    }
}
