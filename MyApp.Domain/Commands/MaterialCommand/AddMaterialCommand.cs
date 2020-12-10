using MyApp.Domain.Commands.Validations;

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
