using Microsoft.EntityFrameworkCore.Metadata.Internal;
using NetDevPack.Domain;
using System;
using System.ComponentModel.DataAnnotations;

namespace MyApp.Domain.Models
{
    public class TodoApp : IAggregateRoot 
    {
        public Guid Id { get; set; }
        public string Name { get; private set; }

        public string Content { get; private set; }

        public DateTime CreatedAt { get; private set; }

        public DateTime FinishedAt { get; private set; }

        public string Status { get; private set; }

        public bool Reported { get; private set; }

        public string Description { get; private set; }

        public TodoApp(Guid id, string name, string content, DateTime createdAt, DateTime finishedAt, bool reported, string status, string description)
        {
            Id = id;
            Name = name;
            Content = content;
            CreatedAt = createdAt;
            FinishedAt = finishedAt;
            Reported = reported;
            Status = status;
            Description = description;
        }
        protected TodoApp() { }
    }
}
