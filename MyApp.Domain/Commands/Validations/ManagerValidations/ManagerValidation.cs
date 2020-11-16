using FluentValidation;
using MyApp.Domain.Commands.ManagerCommands;

namespace MyApp.Domain.Commands.Validations.ManagerValidations
{
    public abstract class ManagerValidation<T> : AbstractValidator<T> where T : ManagerCommand
    {
        protected void ValidateManagerId()
        {
            RuleFor(m => m.ManagerId)
                .NotEmpty();
        }
        protected void ValidateUserId()
        {
            RuleFor(m => m.UserId)
                .NotEmpty();
        }

    }
}
