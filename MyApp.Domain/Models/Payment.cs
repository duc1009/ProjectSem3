using NetDevPack.Domain;
using System;
using System.Collections.Generic;

namespace MyApp.Domain.Models
{
    public class Payment: IAggregateRoot
    {
        public Payment(string name,string code)
        {
            Name = name;
            Code = code;
        }
        public Payment(Guid id, string name,string code) 
        {
            Id = id;
            Update(name,code);
            this.Bills = new HashSet<Bill>();
        }
        public void Update(string name,string code)
        {
            Name = name;
            Code = code;
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public bool IsDeleted { get; set; }

        public void Delete()
        {
            IsDeleted = true;
        }
        public virtual ICollection<Bill> Bills { get; set; }
    }
}
