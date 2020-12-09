
using MyApp.Domain.Commands.Validations.PriceValidations;
using System;

namespace MyApp.Domain.Commands.PriceCommands
{
    public class AddPriceCommand : PriceCommand
    {
        public AddPriceCommand( Guid sizeId, Guid materialId, double value)
        {
            MaterialId = materialId;
            SizeId = sizeId;
            Value = value;
            IsDeleted = false;
        }
        public override bool IsValid()
        {
            return true;
            //ValidationResult = new AddPriceCommandValidation().Validate(this);
            //return ValidationResult.IsValid;
        }

    }

}
