using FluentValidation;
using MyApp.Domain.Commands.SizeCommands;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.Domain.Commands.Validations.SizeValidations
{
    public abstract class SizeValidation<T> : AbstractValidator<T> where T : SizeCommand
    {
        protected void ValidatlId()
        {
            RuleFor(t => t.Id)
                .NotEmpty().WithMessage("Please input id!");   
        }
        protected void ValidateName()
        {
            RuleFor(t => t.Name)
                .NotEmpty().WithMessage("Please input name!");   
        }
    }
}
