using MyApp.Domain.Commands.ManagerCommands;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.Domain.Commands.Validations.ManagerValidations
{
    public class UpdateManagerValidation : ManagerValidation<UpdateManagerCommand>
    {
        public UpdateManagerValidation()
        {
            ValidateManagerId();
            ValidateUserId();
        }
    }
}
