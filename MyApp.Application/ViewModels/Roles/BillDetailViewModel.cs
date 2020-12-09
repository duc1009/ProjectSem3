using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyApp.Application.ViewModels
{
    public class BillDetailViewModel
    {
        [Key]
        public Guid Id { get; set; }
        public Guid BillId { get; set; }
        public string Image { get; set; }
        public Guid SizeId { get; set; }
        public Guid MaterialId { get; set; }
    }
}
