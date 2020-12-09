
using Microsoft.EntityFrameworkCore;
using MyApp.Domain.Interfaces;
using MyApp.Domain.Models;
using MyApp.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApp.Infra.Data.Repository
{
    public class BillRepository : IBillRepository
    {
        protected readonly ApplicationDbContext _context;
        public BillRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        NetDevPack.Data.IUnitOfWork NetDevPack.Data.IRepository<Bill>.UnitOfWork => _context;

        public void Add(Bill Bill)
        {
            _context.Bills.Add(Bill);
        }

       

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<IEnumerable<Bill>> GetAll()
        {
            return await _context.Bills.ToListAsync();
        }

        public async Task<Bill> GetById(Guid id)
        {
            return await _context.Bills.FindAsync(id);
        }


        public void Remove(Bill obj)
        {
            _context.Bills.Remove(obj);
        }

     

        public void Update(Bill obj)
        {
            _context.Bills.Update(obj);
        }

        public Bill GetByIdNotAsync(Guid id)
        {
            var Bill = _context.Bills.FirstOrDefault(x => x.Id == id && !x.IsDeleted);
            if (Bill != null)
            {
                _context.Entry(Bill).Collection(x => x.BillDetails).Load();               
            }
            return Bill;
        }
    }
}
