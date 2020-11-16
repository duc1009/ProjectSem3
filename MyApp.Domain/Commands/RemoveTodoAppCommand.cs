using MyApp.Domain.Commands.Validations;
using System;

namespace MyApp.Domain.Commands
{
    public class RemoveTodoAppCommand : TodoAppCommand
    {
        public RemoveTodoAppCommand(Guid id)
        {
            Id = id;
            AggregateId = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new RemoveTodoAppCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
