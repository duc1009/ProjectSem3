using FluentValidation;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace MyApp.Domain.Commands.Validations
{
    public abstract class MaterialValidation<T> : AbstractValidator<T> where T : MaterialCommand
    {
        protected void ValidateName()
        {
            RuleFor(t => t.Name)
                .NotEmpty().WithMessage("Vui lòng nhập tên");
        }       

        protected void ValidateId()
        {
            RuleFor(t => t.Id)
                .NotEqual(Guid.Empty);
        }


        protected static bool IsLater(DateTime finishedAt)
        {
            return finishedAt >= DateTime.Now;
        }

        protected static bool IsInValid(string status)
        {
            return status == "Đã hoàn thành" || status == "Sắp hoàn thành" || status == "Chưa hoàn thành";
        }
    }
}
