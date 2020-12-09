
using MyApp.Domain.Models;
using NetDevPack.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyApp.Domain.Interfaces
{
    public interface IBillRepository : IRepository<Bill>
    {
        void Add(Bill Bill);
        Task<Models.Bill> GetById(Guid id);
        void Remove(Models.Bill todoApp);
        void Update(Models.Bill todoApp);
        Task<IEnumerable<Models.Bill>> GetAll();
        Bill GetByIdNotAsync(Guid id);

    }
}
