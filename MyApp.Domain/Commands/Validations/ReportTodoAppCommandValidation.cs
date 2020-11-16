using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.Domain.Commands.Validations
{
    public class ReportTodoAppCommandValidation : TodoAppValidation<ReportTodoAppCommand>
    {
        public ReportTodoAppCommandValidation()
        {
            ValidateId();
            ValidateStatus();
          //  ValidateDescription();
        }
    }
}
