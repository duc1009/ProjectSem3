using NetDevPack.Domain;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MyApp.Domain.Models
{
    
    public class MyManager : IAggregateRoot
    {
        public string Id { get; set; }
        public string ManagerId { get; set; }

        public string UserId { get; set; }
        public MyManager(string id, string managerId, string userId)
        {
            Id = id;
            ManagerId = managerId;
            UserId = userId;
        }

    }

}
