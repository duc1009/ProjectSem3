using FluentValidation;
using MyApp.Domain.Commands.PriceCommands;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.Domain.Commands.Validations.PriceValidations
{
    public abstract class PriceValidation<T> : AbstractValidator<T> where T : PriceCommand
    {
        protected void ValidateMaterialId()
        {
            RuleFor(t => t.MaterialId)
                .NotEmpty().WithMessage("Please input material!");
        }
        protected void ValidateSizeId()
        {
            RuleFor(t => t.SizeId).NotEmpty().WithMessage("Please input size!");
        }
        protected void ValidateValue()
        {
            RuleFor(t => t.Value).NotEmpty().WithMessage("Please input value!");
        }
        protected void ValidateId()
        {
            RuleFor(t => t.Value).NotEmpty().WithMessage("Please input Id!");
        }
    }
}
