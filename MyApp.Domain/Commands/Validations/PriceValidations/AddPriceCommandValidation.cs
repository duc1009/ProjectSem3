using FluentValidation.Results;
using MyApp.Domain.Commands.PriceCommands;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.Domain.Commands.Validations.PriceValidations
{
   public class AddPriceCommandValidation: PriceValidation<PriceCommand>
    {
        public AddPriceCommandValidation()
        {
            ValidateMaterialId();
            ValidateSizeId();
            ValidateValue();
        }

    }
}
