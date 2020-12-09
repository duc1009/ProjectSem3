using System;

namespace MyApp.Domain.Commands
{

    public class UpdateBillCommand : BillCommand
    {
        public UpdateBillCommand(Guid id,Guid userId, double totalMoney, DateTime date, string note, Guid statusId, Guid statusPayId, Guid paymentId)
        {
            Id = id;
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
            return true;
        }
    }
}
