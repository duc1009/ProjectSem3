using NetDevPack.Messaging;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.Domain.Commands.ManagerCommands
{
    public abstract class ManagerCommand : Command
    {
        public string Id { get; set; }
        public string ManagerId { get; set; }

        public string UserId { get; set; }
     }
}
