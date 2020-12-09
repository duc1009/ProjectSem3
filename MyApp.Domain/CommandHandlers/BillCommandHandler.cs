using FluentValidation.Results;
using MediatR;
using MyApp.Domain.Commands;
using MyApp.Domain.Interfaces;
using MyApp.Domain.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MyApp.Domain.CommandHandlers
{
    public class BillCommandHandler : NetDevPack.Messaging.CommandHandler,
        IRequestHandler<AddBillCommand, ValidationResult>,
         IRequestHandler<UpdateBillCommand, ValidationResult>,
        IRequestHandler<DeleteBillCommand, ValidationResult>
    {
        private readonly IBillRepository repository;
        //private readonly IUser user;

        public BillCommandHandler(IBillRepository repository)
        {           
            this.repository = repository;
        }
        public async Task<ValidationResult> Handle(AddBillCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) return message.ValidationResult;
            var Bill = new Bill(Guid.NewGuid(), message.UserId, message.TotalMoney, message.Date, message.Note, message.StatusId, message.StatusPayId, message.PaymentId);
            foreach (var item in message.BillDetails)
            {
                Bill.BillDetails.Add(item);
            }
            repository.Add(Bill);
            
            return await Commit(repository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(UpdateBillCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid()) return message.ValidationResult;
            var existing = repository.GetByIdNotAsync(message.Id);
            var bill = new Bill(message.Id,message.UserId, message.TotalMoney, message.Date, message.Note, message.StatusId, message.StatusPayId, message.PaymentId);
            existing.RemoveBillDetail();
            foreach (var item in message.BillDetails)
            {
                existing.AddBillDetail(item);
            }
            repository.Update(bill);
            return await Commit(repository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(DeleteBillCommand message, CancellationToken cancellationToken)
        {
            if (!message.IsValid())
            {

                await Commit(repository.UnitOfWork);
            }
            var todoApp = await repository.GetById(message.Id);

            if (todoApp is null)
            {
                AddError("The Bill doesn't exists.");
                return ValidationResult;
            }
            repository.Remove(todoApp);


            return await Commit(repository.UnitOfWork);
        }
    }
}
