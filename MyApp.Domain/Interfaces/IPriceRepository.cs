using MyApp.Domain.Models;
using NetDevPack.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Domain.Interfaces
{
    public interface IPriceRepository : IRepository<Price>
    {
        void Add(Price price);
        Task<Price> GetById(Guid id);
        void Remove(Price price);
        void Update(Price price);
        Task<IEnumerable<Price>> GetAll();

    }
}
