using ETC.EQM.Domain.Core.Bus;
using MediatR;
using MyApp.Domain.Commands;
using MyApp.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.Domain.CommandHandlers
{
    public class MaterialCommandHandler : CommandHandler,
        IRequestHandler<AddMaterialCommand, bool>,
         IRequestHandler<UpdateMaterialCommand, bool>,
        IRequestHandler<DeleteMaterialCommand, bool>
    {
        private readonly IMaterialRepository repository;
        private readonly IMediatorHandler Bus;

        public MaterialCommandHandler(IUser user, IMaterialRepository repository, IUnitOfWork uow, IMediatorHandler bus, INotificationHandler<DomainNotification> notifications) : base(uow, bus, notifications)
        {
            this.user = user;
            this.repository = repository;
            Bus = bus;

        }
        public Task<bool> Handle(AddMaterialCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.FromResult(false);
            }

            var Material = new Material(Guid.NewGuid(), message.Name, message.EducationLevelId, message.Stt, message.ManagementId, user.PortalId, message.CreateBy);
            repository.Add(Material);
            if (Commit())
            {
                Bus.RaiseEvent(new AddGradeEvent(Core.Events.StoredEventType.Add, user.UserId, user.FullName, Material.Id.ToString(), "", user.UnitUserId, user.PortalId));
                return Task.FromResult(true);
            }

            return Task.FromResult(false);
        }

        public Task<bool> Handle(UpdateMaterialCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.FromResult(false);
            }
            var existing = repository.Get(message.Id);
            if (existing != null)
            {
                existing.Update(message.Name, message.EducationLevelId, message.Stt, message.ManagementId, message.CreateBy);
                repository.Update(existing);
            }

            if (Commit())
            {
                Bus.RaiseEvent(new AddGradeEvent(Core.Events.StoredEventType.Update, user.UserId, user.FullName, existing.Id.ToString(), "", user.UnitUserId, user.PortalId));
                return Task.FromResult(true);
            }
            return Task.FromResult(false);
        }

        public Task<bool> Handle(DeleteMaterialCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {
                NotifyValidationErrors(message);
                return Task.FromResult(false);
            }

            foreach (var item in message.Ids)
            {
                var existing = repository.Get(item);
                if (existing != null)
                {
                    existing.Delete();
                    repository.Update(existing);
                    Bus.RaiseEvent(new AddGradeEvent(Core.Events.StoredEventType.Remove, user.UserId, user.FullName, existing.Id.ToString(), "", user.UnitUserId, user.PortalId));
                }
            }

            if (Commit())
            {

                return Task.FromResult(true);
            }

            return Task.FromResult(false);
        }
    }
}
