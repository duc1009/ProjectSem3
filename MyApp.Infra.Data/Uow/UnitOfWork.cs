using MyApp.Domain.Interfaces;
using MyApp.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.Infra.Data.Uow
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;

        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Commit()
        {
            return _context.SaveChanges() > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
