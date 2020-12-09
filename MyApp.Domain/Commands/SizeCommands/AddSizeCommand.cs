
using MyApp.Domain.Commands.Validations.SizeValidations;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.Domain.Commands.SizeCommands
{
    public class AddSizeCommand : SizeCommand
    {
        public AddSizeCommand(string name)
        {
            Name = name;
        }

        public override bool IsValid()
        {
            ValidationResult = new AddSizeCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }

    }
}
