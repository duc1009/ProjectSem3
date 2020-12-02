using System;
using MediatR;

namespace ETC.EQM.Domain.Core.Events
{
    public abstract class Message : IRequest<bool>
    {
        public string MessageType { get; set; }
        public Guid AggregateId { get; protected set; }

        protected Message()
        {
            MessageType = GetType().Name;
        }
    }
}