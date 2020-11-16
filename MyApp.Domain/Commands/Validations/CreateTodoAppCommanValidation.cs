using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.Domain.Commands.Validations
{
    public class CreateTodoAppCommandValidation : TodoAppValidation<CreateTodoAppCommand>
    {
        public CreateTodoAppCommandValidation()
        {
            ValidateName();
            ValidateContent();
            ValidateFinishedAt();
        }
    }
}
