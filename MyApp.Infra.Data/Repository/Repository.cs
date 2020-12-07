using Microsoft.EntityFrameworkCore;
using MyApp.Domain.Interfaces;
using MyApp.Domain.Interfaces.e;
using MyApp.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Infra.Data.Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        #region Protected Fields

        protected readonly ApplicationDbContext Db;
        protected readonly DbSet<TEntity> DbSet;

        #endregion Protected Fields

        #region Public Constructors

        public Repository(ApplicationDbContext context)
        {
            Db = context;
            DbSet = Db.Set<TEntity>();
        }

        public IUnitOfWork UnitOfWork => throw new NotImplementedException();

        #endregion Public Constructors

        #region Public Methods

        public virtual void Add(TEntity obj)
        {
            DbSet.Add(obj);
        }

        public async Task AddAsync(TEntity obj)
        {
            await DbSet.AddAsync(obj);
        }

        public void Dispose()
        {
            Db.Dispose();
            GC.SuppressFinalize(this);
        }

        public virtual TEntity Get(Guid id)
        {
            return DbSet.Find(id);
        }


        public virtual IQueryable<TEntity> GetAll()
        {
            return DbSet;
        }

        public async Task<List<TEntity>> GetAllAsync()
        {
            return await DbSet.ToListAsync();
        }

        public async Task<TEntity> GetAsync(Guid id)
        {
            return await DbSet.FindAsync(id);
        }

        public virtual void Remove(Guid id)
        {
            DbSet.Remove(DbSet.Find(id));
        }

        public int SaveChanges()
        {
            return Db.SaveChanges();
        }

        public virtual void Update(TEntity obj)
        {
            DbSet.Update(obj);
        }

        #endregion Public Methods
    }
}
