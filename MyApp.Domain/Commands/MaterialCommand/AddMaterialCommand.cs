using ETC.EQM.Domain.Core.Commands;
using MyApp.Domain.Commands.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.Domain.Commands
{
 
    public class AddMaterialCommand : MaterialCommand
    {
        public AddMaterialCommand(string name)
        {
            Name = name;          
        }

        public override bool IsValid()
        {
            ValidationResult = new AddMateriaCommanValidation().Validate(this);
            return ValidationResult.IsValid;
        }


    }
}
