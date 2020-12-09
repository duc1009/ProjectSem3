using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.Domain.Commands.PriceCommands
{
    public class DeletePriceCommand : PriceCommand
    {
        public DeletePriceCommand(Guid id)
        {
            Id = id;
        }
    }
}
