using NetDevPack.Domain;
using System;
using System.Collections.Generic;

namespace MyApp.Domain.Models
{
    public class BillDetail: IAggregateRoot
    {
        public BillDetail()
        {           
        }
      
        public Guid Id { get; set; }
        public Guid BillId { get; set; }
        public string Image { get; set; }
        public Guid SizeId { get; set; }
        public Guid MaterialId { get; set; }

      
    }
}
