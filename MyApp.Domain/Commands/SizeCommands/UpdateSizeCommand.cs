using MyApp.Domain.Commands.Validations.SizeValidations;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.Domain.Commands.SizeCommands
{
    public class UpdateSizeCommand :SizeCommand
    {
        public UpdateSizeCommand(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdateSizeCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
