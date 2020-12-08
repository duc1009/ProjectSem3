using NetDevPack.Domain;
using System;
using System.Collections.Generic;

namespace MyApp.Domain.Models
{
    public class Price: IAggregateRoot
    {
       
        public Price(Guid id, Guid materialId, Guid sizeId, string value)
        {
            Id = id;
            Update( materialId,  sizeId,  value);
        }

        public void Update(Guid materialId, Guid sizeId, string value)
        {
            MaterialId = materialId;
            SizeId = sizeId;
            Value = value;
        }
        public Guid Id { get; set; }
        public Guid MaterialId { get; set; }
        public Guid SizeId { get; set; }
        public string Value { get; set; }
        public bool IsDeleted { get; set; }

        public void Delete()
        {
            IsDeleted = true;
        }
        
    }
}
