using MyApp.Domain.Commands.PriceCommands;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.Domain.Commands.Validations.PriceValidations
{
    public class DeletePriceCommandValidation : PriceValidation<PriceCommand>
    {
        public DeletePriceCommandValidation()
        {
            ValidateId();
        }
    }
}
