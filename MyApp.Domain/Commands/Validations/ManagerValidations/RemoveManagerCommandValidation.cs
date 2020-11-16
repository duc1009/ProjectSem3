using MyApp.Domain.Commands.ManagerCommands;

namespace MyApp.Domain.Commands.Validations.ManagerValidations
{
    public class RemoveManagerCommandValidation : ManagerValidation<RemoveManagerCommand>
    {
        public RemoveManagerCommandValidation()
        {
            ValidateUserId();
        }
    }
}
