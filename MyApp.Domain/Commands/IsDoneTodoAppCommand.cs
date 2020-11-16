using MyApp.Domain.Commands.Validations;
using System;

namespace MyApp.Domain.Commands.Validations
{
    public class IsDoneTodoAppCommand : TodoAppCommand
    {
        public IsDoneTodoAppCommand(Guid id)
        {
            Id = id;
        }
        public override bool IsValid()
        {
            ValidationResult = new IsDoneTodoAppCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
