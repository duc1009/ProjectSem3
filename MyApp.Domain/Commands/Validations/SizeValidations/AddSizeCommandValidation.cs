using MyApp.Domain.Commands.SizeCommands;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.Domain.Commands.Validations.SizeValidations
{
    public  class AddSizeCommandValidation :SizeValidation<AddSizeCommand>
    {
        public AddSizeCommandValidation()
        {
            ValidateName();
        }
    }
}
