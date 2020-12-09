using MyApp.Domain.Commands.SizeCommands;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.Domain.Commands.Validations.SizeValidations
{
    public class DeleteSizeCommandValidation : SizeValidation<DeleteSizeCommand>
    {
        public DeleteSizeCommandValidation()
        {
            ValidatlId();
        }
    }
}
