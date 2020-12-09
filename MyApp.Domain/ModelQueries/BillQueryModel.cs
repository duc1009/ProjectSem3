using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.Domain.ModelQueries
{
    public class BillQueryModel
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public double TotalMoney { get; set; }
        public DateTime Date { get; set; }
        public string Note { get; set; }
        public string StatusId { get; set; }
        public string StatusPayId { get; set; }
        public string PaymentId { get; set; }
        public bool IsDeleted { get; set; }
    }
    public class BillDTO
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public double TotalMoney { get; set; }
        public DateTime Date { get; set; }
        public string Note { get; set; }
        public string StatusId { get; set; }
        public string StatusPayId { get; set; }
        public string PaymentId { get; set; }
        public bool IsDeleted { get; set; }
    }
}
