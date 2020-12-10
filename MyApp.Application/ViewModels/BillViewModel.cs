using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyApp.Application.ViewModels
{
    public class BillViewModel
    {
        public BillViewModel()
        {
            BillDetails = new List<BillDetailViewModel>();
        }

        [Key]
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public double TotalMoney { get; set; }
        public DateTime Date { get; set; }
        public string Note { get; set; }
        public Guid StatusId { get; set; }
        public Guid StatusPayId { get; set; }
        public Guid PaymentId { get; set; }
        public bool IsDeleted { get; set; }
        public List<BillDetailViewModel> BillDetails { get; set; }
    }
}
