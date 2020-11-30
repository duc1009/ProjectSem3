
using MyApp.Domain.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.Domain.Models
{
    public class Material:Entity
    {
        public Material(string name)
        {
            Name = name;
        }
        public Material(Guid id, string name) : base(id)
        {
            Update(name);
        }
        public void Update(string name)
        {
            Name = name;
        }
        public string Name { get; set; }
    }
}
