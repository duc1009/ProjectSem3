using MyApp.Domain.Commands.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.Domain.Commands
{
    public class ReportTodoAppCommand : TodoAppCommand
    {
        public ReportTodoAppCommand(Guid id, DateTime createdAt, string status, string description)
        {
            Id = id;
            CreateAt = createdAt;
            Status = status;
            Description = description;
        }

        public override bool IsValid()
        {
            ValidationResult = new ReportTodoAppCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
