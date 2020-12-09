using System;

namespace MyApp.Domain.Commands
{

    public  class DeleteBillCommand : BillCommand
    {
        public Guid[] Ids { get; set; }
        public DeleteBillCommand(Guid[] ids)
        {
            Ids = ids;
        }
        public override bool IsValid()
        {
            return true;
        }

    }
}
