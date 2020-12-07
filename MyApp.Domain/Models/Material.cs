
using MyApp.Domain.Core.Models;
using NetDevPack.Domain;
using System;
using System.Collections.Generic;
using System.Text;

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
    }
}
