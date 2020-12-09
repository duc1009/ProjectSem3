using NetDevPack.Messaging;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.Domain.Commands.SizeCommands
{
    public abstract class SizeCommand : Command
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }

        public SizeCommand()
        {
        }

        public SizeCommand(Guid id, string name, bool isDeleted)
        {
            Id = id;
            Name = name;
            IsDeleted = isDeleted;
        }
    }
}
