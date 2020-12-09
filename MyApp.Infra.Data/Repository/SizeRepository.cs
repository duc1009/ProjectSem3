using Microsoft.EntityFrameworkCore;
using MyApp.Domain.Interfaces;
using MyApp.Domain.Models;
using MyApp.Infra.Data.Context;
using NetDevPack.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Infra.Data.Repository
{
    public class SizeRepository : ISizeRepository
    {
        protected readonly ApplicationDbContext _context;
        public SizeRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public IUnitOfWork UnitOfWork => _context;
        public void Add(Size size)
        {
            _context.Sizes.Add(size);
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<IEnumerable<Size>> GetAll()
        {
            return await _context.Sizes.ToListAsync();
        }

        public async Task<Size> GetById(Guid id)
        {
            return await _context.Sizes.FirstOrDefaultAsync(x => x.Id == id);
        }

        public void Remove(Size size)
        {
            _context.Sizes.Remove(size);
        }

        public void Update(Size size)
        {
            _context.Sizes.Update(size);
        }
    }
}

