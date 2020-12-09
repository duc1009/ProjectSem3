using NetDevPack.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MyApp.Domain.Models
{
    public class Bill: IAggregateRoot
    {
        public Bill(Guid id, Guid userId, double totalMoney, DateTime date, string note, Guid statusId, Guid statusPayId, Guid paymentId)
        {
            Id = id;
            Update(userId, totalMoney, date, note, statusId, statusPayId, paymentId);
            this.BillDetails = new List<BillDetail>();
        }

        public Bill()
        {
        }

        public void Update(Guid userId, double totalMoney, DateTime date, string note, Guid statusId, Guid statusPayId, Guid paymentId)
        {
            UserId = userId;
            TotalMoney = totalMoney;
            Date = date;
            Note = note;
            StatusId = statusId;
            StatusPayId = statusPayId;
            PaymentId = paymentId;
        }
        public Guid Id { get; set; }
        public Guid UserId { get; set; }       
        public double TotalMoney { get; set; }
        public DateTime  Date { get; set; }
        public string Note { get; set; }
        public Guid StatusId { get; set; }
        public Guid StatusPayId { get; set; }
        public Guid PaymentId { get; set; }
        public bool IsDeleted { get; set; }

        public void Delete()
        {
            IsDeleted = true;
        }
        public virtual ICollection<BillDetail> BillDetails { get; set; }
        public void AddBillDetail(BillDetail model)
        {
            BillDetails.Add(model);
        }

        public void RemoveBillDetail()
        {
            var BillDetail = BillDetails.AsQueryable().ToList().Where(x => x.BillId == Id);
            foreach (var item in BillDetail)
            {
                BillDetails.Remove(item);
            }
        }
    }
}
