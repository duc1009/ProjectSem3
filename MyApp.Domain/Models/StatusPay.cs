using NetDevPack.Domain;
using System;
using System.Collections.Generic;

namespace MyApp.Domain.Models
{
    public class StatusPay: IAggregateRoot
    {
        public StatusPay(string name)
        {
            Name = name;
        }
        public StatusPay(Guid id, string name) 
        {
            Id = id;
            Update(name);
            this.Bills = new HashSet<Bill>();
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
        public virtual ICollection<Bill> Bills { get; set; }
    }
}
