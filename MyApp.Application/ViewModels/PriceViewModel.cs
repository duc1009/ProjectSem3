using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyApp.Application.ViewModels.Price
{
    public class PriceViewModel
    {
        [Key]
        public Guid Id { get; set; }
        public Guid MaterialId { get; set; }
        public Guid SizeId { get; set; }
        public double Value { get; set; }
    }
}
