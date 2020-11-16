using FluentValidation;
using MyApp.Domain.Commands.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.Domain.Commands
{
   public class UpdateTodoAppCommand : TodoAppCommand
    {
        public UpdateTodoAppCommand(Guid id, string name,DateTime createdAt ,string content, DateTime finishedAt)
        {
            Id = id;
            Name = name;
            Content = content;
            CreateAt = createdAt;
            FinishedAt = finishedAt;
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdateTodoAppCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
