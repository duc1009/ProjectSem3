using MyApp.Domain.Commands.Validations.PriceValidations;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.Domain.Commands.PriceCommands
{
    public class DeletePriceCommand : PriceCommand
    {
        public Guid[] Ids { get; set; }
        public DeletePriceCommand(Guid[] ids)
        {
            Ids = ids;
        }
    
    }
}
