using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.Domain.Commands.Validations
{
    public class RemoveTodoAppCommandValidation : TodoAppValidation<RemoveTodoAppCommand>
    {
        public RemoveTodoAppCommandValidation()
        {
            ValidateId();
        }
    }
}
