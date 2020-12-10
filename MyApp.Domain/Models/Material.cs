using NetDevPack.Domain;
using System;
using System.Collections.Generic;

namespace MyApp.Domain.Models
{
    public class Material: IAggregateRoot
    {
        public Material(string name)
        {
            Name = name;
        }
        public Material(Guid id, string name) 
        {
            Id = id;
            Update(name);
            this.Prices = new HashSet<Price>();
            this.BillDetails = new HashSet<BillDetail>();
        }
        public void Update(string name)
        {
            Name = name;
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }

        public void Delete()
        {
            IsDeleted = true;
        }
        public virtual ICollection<Price> Prices { get; set; }
        public virtual ICollection<BillDetail> BillDetails { get; set; }
    }
}
