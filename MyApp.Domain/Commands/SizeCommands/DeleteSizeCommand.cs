using MyApp.Domain.Commands.Validations.SizeValidations;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.Domain.Commands.SizeCommands
{
    public class DeleteSizeCommand :SizeCommand
    {
        public Guid[] Ids { get; set; }
        public DeleteSizeCommand(Guid[] ids)
        {
            Ids = ids;
        }
   
    }
}
