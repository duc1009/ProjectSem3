using MyApp.Domain.Commands.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.Domain.Commands
{
    public class CreateTodoAppCommand : TodoAppCommand
    {
        public CreateTodoAppCommand(string name, string content, DateTime finishedAt)
        {
            Name = name;
            Content = content;
            FinishedAt = finishedAt;
        }

        public override bool IsValid()
        {
            ValidationResult = new CreateTodoAppCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
