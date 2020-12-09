using Microsoft.EntityFrameworkCore;
using MyApp.Domain.Interfaces;
using MyApp.Domain.Models;
using MyApp.Infra.Data.Context;
using NetDevPack.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Infra.Data.Repository
{
    public class PriceRepository : IPriceRepository
    {
        protected readonly ApplicationDbContext _context;
        public PriceRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public IUnitOfWork UnitOfWork => _context;
        public void Add(Price price)
        {
            _context.Prices.Add(price);
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<IEnumerable<Price>> GetAll()
        {
           return await _context.Prices.ToListAsync();
        }

        public async Task<Price> GetById(Guid id)
        {
            return await _context.Prices.FirstOrDefaultAsync(x => x.Id == id);
        }

        public void Remove(Price price)
        {
            _context.Prices.Remove(price);
        }

        public void Update(Price price)
        {
            _context.Prices.Update(price);
        }
    }
}
