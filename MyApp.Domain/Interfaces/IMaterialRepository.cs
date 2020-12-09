
using MyApp.Domain.Models;
using NetDevPack.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyApp.Domain.Interfaces
{
    public interface IMaterialRepository : IRepository<Material>
    {
        void Add(Material material);
        Task<Models.Material> GetByName(string name);
        Task<Models.Material> GetById(Guid id);
        void Remove(Models.Material material);
        void UpDate(Material material);
        Task<IEnumerable<Models.Material>> GetAll();

    }
}
