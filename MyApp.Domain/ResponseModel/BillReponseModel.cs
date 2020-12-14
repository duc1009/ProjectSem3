using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.Domain.ResponseModel
{
    public class BillReponseModel
    {
        public Guid Id { get; set; }
        public string UserName { get; set; }
        public DateTime Date { get; set; }
        public string Note { get; set; }
        public string Status { get; set; }
        public string StatusPay { get; set; }
        public double TotalMoney { get; set; }
    }
}
