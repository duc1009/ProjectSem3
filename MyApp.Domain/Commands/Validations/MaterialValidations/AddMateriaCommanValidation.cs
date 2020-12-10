using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.Domain.Commands.Validations
{
    public class AddMateriaCommanValidation : MaterialValidation<AddMaterialCommand>
    {
        public AddMateriaCommanValidation()
        {
            ValidateName();
        }
    }
}
