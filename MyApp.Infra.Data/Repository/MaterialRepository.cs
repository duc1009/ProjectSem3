
using MyApp.Domain.Interfaces;
using MyApp.Domain.Models;
using MyApp.Infra.Data.Context;
using NetDevPack.Data;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Infra.Data.Repository
{
    public class MaterialRepository : IMaterialRepository
    {
        protected readonly ApplicationDbContext _context;
        public MaterialRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Domain.Interfaces.IUnitOfWork UnitOfWork => throw new NotImplementedException();

        NetDevPack.Data.IUnitOfWork IRepository<Material>.UnitOfWork => throw new NotImplementedException();

        public void Add(Material material)
        {
            _context.Materials.Add(material);
        }

       

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<IEnumerable<Material>> GetAll()
        {
            return await _context.Materials.ToListAsync();
        }

        public async Task<Material> GetById(Guid id)
        {
            return await _context.Materials.FindAsync(id);
        }

        public async Task<Material> GetByName(string name)
        {
            return await _context.Materials.AsNoTracking().FirstOrDefaultAsync(t => t.Name == name);
        }

        public void Remove(Material obj)
        {
            _context.Materials.Remove(obj);
        }

     

        public void Update(Material obj)
        {
            _context.Materials.Update(obj);
        }
    }
}
