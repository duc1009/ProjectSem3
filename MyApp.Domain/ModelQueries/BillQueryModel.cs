using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.Domain.ModelQueries
{
    public class BillQueryModel
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string User { get; set; }
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
        public BillDTO()
        {
            BillDetails = new List<BillDetailDTO>();
        }

        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public double TotalMoney { get; set; }
        public DateTime Date { get; set; }
        public string Note { get; set; }
        public Guid StatusId { get; set; }
        public Guid StatusPayId { get; set; }
        public Guid PaymentId { get; set; }
        public bool IsDeleted { get; set; }
        public List<BillDetailDTO> BillDetails { get; set; }
    }
}
