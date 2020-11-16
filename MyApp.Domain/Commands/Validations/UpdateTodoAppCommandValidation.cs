using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.Domain.Commands.Validations
{
    public class UpdateTodoAppCommandValidation : TodoAppValidation<UpdateTodoAppCommand>
    {
        public UpdateTodoAppCommandValidation()
        {
            ValidateName();
            ValidateContent();
            ValidateFinishedAt();
        }
    }
}
