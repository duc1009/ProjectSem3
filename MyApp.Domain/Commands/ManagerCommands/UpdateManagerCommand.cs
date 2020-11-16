
using MyApp.Domain.Commands.Validations.ManagerValidations;


namespace MyApp.Domain.Commands.ManagerCommands
{
    public class UpdateManagerCommand : ManagerCommand
    {
        public UpdateManagerCommand(string managerId, string userId)
        {
            ManagerId = managerId;
        }
        public override bool IsValid()
        {
            ValidationResult = new UpdateManagerValidation().Validate(this);
            return ValidationResult.IsValid;
        }

    }
}
