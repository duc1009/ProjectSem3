using MyApp.Domain.Commands.ManagerCommands;

namespace MyApp.Domain.Commands.Validations.ManagerValidations
{
    public class CreateManagerCommandValidation : ManagerValidation<CreateManagerCommand>
    {
        public CreateManagerCommandValidation()
        {
            ValidateManagerId();
            ValidateUserId();
        }
    }
}
