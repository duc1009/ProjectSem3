using Microsoft.EntityFrameworkCore;
using MyApp.Domain.Interfaces;
using MyApp.Domain.Models;
using MyApp.Infra.Data.Context;
using NetDevPack.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApp.Infra.Data.Repository
{
    public class TodoAppRepository : ITodoAppRepository
    {
        protected readonly ApplicationDbContext _context;


        NetDevPack.Data.IUnitOfWork IRepository<TodoApp>.UnitOfWork => _context;

        // protected readonly DbSet<TodoApp> DbSet;

        public TodoAppRepository(ApplicationDbContext context)
        {
            _context = context;
            //    DbSet = _context.Set<Domain.Models.TodoApp>();
        }
        public async Task<TodoApp> GetById(Guid id)
        {
            return await _context.TodoApps.FindAsync(id);
        }

        public async Task<IEnumerable<TodoApp>> GetAll()
        {
            return await _context.TodoApps.ToListAsync();
        }

        public async Task<IEnumerable<TodoApp>> FilterByStatus(string status)
        {
            return await _context.TodoApps.Where(t=>t.Status==status).ToListAsync();
        }

        public async Task<TodoApp> GetByName(string name)
        {
            return await _context.TodoApps.AsNoTracking().FirstOrDefaultAsync(t => t.Name == name);
        }

        public void Add(TodoApp todoApp)
        {
            _context.TodoApps.Add(todoApp);
        }

        public void Update(TodoApp todoApp)
        {
            _context.TodoApps.Update(todoApp);
        }

        public void Remove(TodoApp todoApp)
        {
            _context.TodoApps.Remove(todoApp);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
