using NetDevPack.Messaging;
using System;

namespace MyApp.Domain.Commands
{
    public abstract class TodoAppCommand : Command
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Content { get; set; }

        public DateTime CreateAt { get; set; }

        public DateTime FinishedAt { get; set; }

        public string Status { get; set; }

        public bool Reported { get; set; }

        public string Description { get; set; }
    }
}
