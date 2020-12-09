using MyApp.Domain.Commands.Validations.PriceValidations;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.Domain.Commands.PriceCommands
{
    public class UpdatePriceCommand : PriceCommand
    {
        public UpdatePriceCommand(Guid id, Guid sizeId, Guid materialId, double value)
        {
            Id = id;
            MaterialId = materialId;
            SizeId = sizeId;
            Value = value;
        }
        public override bool IsValid()
        {
            ValidationResult = new UpdatePriceCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
