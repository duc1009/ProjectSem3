using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.Domain.Commands.PriceCommands
{
    public class PriceCommand
    {
        public Guid Id { get; set; }
        public Guid MaterialId { get; set; }
        public Guid SizeId { get; set; }
        public double Value { get; set; }
        public bool IsDeleted { get; set; }
    }
}
