using MyApp.Domain.Commands.Validations.ManagerValidations;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.Domain.Commands.ManagerCommands
{
    public class RemoveManagerCommand : ManagerCommand
    {
        public RemoveManagerCommand(string userId)
        {
            UserId = userId;
        }

        public override bool IsValid()
        {
            ValidationResult = new RemoveManagerCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
