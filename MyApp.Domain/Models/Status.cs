using NetDevPack.Domain;
using System;
using System.Collections.Generic;

namespace MyApp.Domain.Models
{
    public class Status: IAggregateRoot
    {
        public Status(string name)
        {
            Name = name;
        }
        public Status(Guid id, string name) 
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
