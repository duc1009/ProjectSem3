
using MyApp.Domain.Models;
using NetDevPack.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyApp.Domain.Interfaces
{
    public interface IMaterialRepository : NetDevPack.Data.IRepository<Material>
    {
        void Add(Material material);
        Task<Models.Material> GetByName(string name);
        Task<Models.Material> GetById(Guid id);
        void Remove(Models.Material todoApp);
   
        Task<IEnumerable<Models.Material>> GetAll();

    }
}
