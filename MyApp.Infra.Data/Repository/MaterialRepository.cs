
using MyApp.Domain.Interfaces;
using MyApp.Domain.Models;
using MyApp.Infra.Data.Context;
using System;
using System.Collections.Generic;
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

        public IUnitOfWork UnitOfWork => throw new NotImplementedException();

        public void Add(Material material)
        {
            _context.Materials.Add(material);
        }

        public Task AddAsync(Material obj)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public Material Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Material> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Remove(Guid id)
        {
            throw new NotImplementedException();
        }

        public int SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void Update(Material obj)
        {
            throw new NotImplementedException();
        }
    }
}
