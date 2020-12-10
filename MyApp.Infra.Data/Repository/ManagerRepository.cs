using Microsoft.EntityFrameworkCore;
using MyApp.Domain.Interfaces;
using MyApp.Domain.Models;
using MyApp.Infra.Data.Context;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApp.Infra.Data.Repository
{
    public class ManagerRepository : IManagerRepository
    {
        protected readonly ApplicationDbContext _context;
        public ManagerRepository(ApplicationDbContext context)
        {
            _context = context;
        }


        NetDevPack.Data.IUnitOfWork NetDevPack.Data.IRepository<MyManager>.UnitOfWork => _context;

        public async Task<MyManager> GetByManagerId(string managerId)
        {
            return await _context.MyManagers.FirstOrDefaultAsync(m => m.ManagerId == managerId);
        }


        public async Task<MyManager> GetByUserId(string userId)
        {
            return await _context.MyManagers.FirstOrDefaultAsync(m => m.UserId == userId);
        }

        public async Task<MyManager> Get(string managerId, string userId)
        {
            return await _context.MyManagers.FirstOrDefaultAsync(m => m.ManagerId == managerId && m.UserId==userId);
        }
        public async Task<IEnumerable<MyManager>> ListByManagerId(string managerId)
        {
            return await _context.MyManagers.Where(m => m.ManagerId == managerId).ToListAsync();

        }
        public async Task<IEnumerable<MyManager>> GetAll()
        {
            return await _context.MyManagers.ToListAsync();
        }

        public void Add(MyManager manager)
        {
            _context.MyManagers.Add(manager);
        }

        public void Update(MyManager manager)
        {
            _context.MyManagers.Update(manager);
        }

        public void Delete(MyManager manager)
        {
            _context.MyManagers.Remove(manager);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
