
using MyApp.Domain.Models;
using NetDevPack.Messaging;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.Domain.Commands
{
 
    public abstract class BillCommand : Command
    {
       
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public double TotalMoney { get; set; }
        public DateTime Date { get; set; }
        public string Note { get; set; }
        public Guid StatusId { get; set; }
        public Guid StatusPayId { get; set; }
        public Guid PaymentId { get; set; }

        public List<BillDetail> BillDetails { get; set; }


    }
}
