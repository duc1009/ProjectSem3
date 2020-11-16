using MyApp.Domain.Models;
using NetDevPack.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyApp.Domain.Interfaces
{
    public interface IManagerRepository : IRepository<MyManager>
    {
        Task<MyManager> GetByManagerId(string managerId);
        Task<MyManager> GetByUserId(string userId);
        Task<MyManager> Get(string managerId, string userId);

        Task<IEnumerable<MyManager>> ListByManagerId(string managerId);
        Task<IEnumerable<MyManager>> GetAll();

        void Add(MyManager manager);
        void Update(MyManager manager);
        void Delete(MyManager manager);
    }
}
