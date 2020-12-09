using MyApp.Domain.Commands.Validations;
using System;

namespace MyApp.Domain.Commands
{

    public class AddBillCommand : BillCommand
    {
        public AddBillCommand(Guid userId, double totalMoney, DateTime date, string note, Guid statusId, Guid statusPayId, Guid paymentId)
        {
            UserId = userId;
            TotalMoney = totalMoney;
            Date = date;
            Note = note;
            StatusId = statusId;
            StatusPayId = statusPayId;
            PaymentId = paymentId;
        }


        public override bool IsValid()
        {
            //ValidationResult = new AddMateriaCommanValidation().Validate(this);
            //return ValidationResult.IsValid;
            return true;
        }


    }
}
