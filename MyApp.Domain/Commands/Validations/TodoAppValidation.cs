using FluentValidation;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace MyApp.Domain.Commands.Validations
{
    public abstract class TodoAppValidation<T> : AbstractValidator<T> where T : TodoAppCommand
    {
        protected void ValidateName()
        {
            RuleFor(t => t.Name)
                .NotEmpty().WithMessage("Vui lòng nhập tên");
        }

        protected void ValidateContent()
        {
            RuleFor(t => t.Content)
                .NotEmpty().WithMessage("Vui lòng nhập nội dung");
        }

        protected void ValidateFinishedAt()
        {
            RuleFor(t => t.FinishedAt)
                .NotEmpty().WithMessage("Vui lòng chọn ngày hoàn thành")
                .Must(IsLater).WithMessage("Ngày hoàn thành phải là hôm nay hoặc muộn hơn");
        }

        protected void ValidateId()
        {
            RuleFor(t => t.Id)
                .NotEqual(Guid.Empty);
        }

        protected void ValidateStatus()
        {
            RuleFor(t => t.Status)
                .NotEmpty()
                .WithMessage("Vui lòng nhập trạng thái công việc !")
                .Must(IsInValid).WithMessage("Trạng thái công việc phải là Đã hoàn thành, Sắp hoàn thành hoặc Chưa hoàn thành");
        }

        //protected void ValidateDescription()
        //{
        //    RuleFor(t => t.Description)
        //        .NotEmpty()
        //        .WithMessage("Vui lòng điền vào phần mô tả !");
        //}


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
