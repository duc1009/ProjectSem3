using FluentValidation;
using MyApp.Domain.Commands.Validations;
using MyApp.Domain.Commands.Validations.ManagerValidations;
using System;

namespace MyApp.Domain.Commands.ManagerCommands
{
    public class CreateManagerCommand : ManagerCommand
    {
        public CreateManagerCommand(string id, string managerId, string userId)
        {
            Id = id;
            ManagerId = managerId;
            UserId = userId;
        }

        public override bool IsValid()
        {
            ValidationResult = new CreateManagerCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
