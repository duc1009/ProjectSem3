
using ETC.EQM.Domain.Core.Notifications;
using MediatR;
using MyApp.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.Domain.CommandHandlers
{
    public class CommandHandler
    {
        private readonly IUnitOfWork _uow;
        private readonly DomainNotificationHandler _notifications;

        public CommandHandler(IUnitOfWork uow)
        {
            _uow = uow;
          
        }

        

        public bool Commit()
        {
            if (_notifications.HasNotifications()) return false;
            if (_uow.Commit()) return true;

           
            return false;
        }
    }
}
