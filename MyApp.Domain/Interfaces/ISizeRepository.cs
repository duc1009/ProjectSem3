using MyApp.Domain.Models;
using NetDevPack.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Domain.Interfaces
{
    public  interface ISizeRepository :IRepository<Size>
    {
        void Add(Size size);
        Task<Size> GetById(Guid id);
        void Remove(Size size);
        void Update(Size size);
        Task<IEnumerable<Size>> GetAll();
    }
}
