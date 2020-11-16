

namespace MyApp.Domain.Commands.Validations
{
    public class IsDoneTodoAppCommandValidation : TodoAppValidation<IsDoneTodoAppCommand>
    {
        public IsDoneTodoAppCommandValidation()
        {
            ValidateId();
        }
    }
}
