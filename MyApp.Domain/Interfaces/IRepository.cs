using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Domain.Interfaces
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        #region Public Methods

        void Add(TEntity obj);

        Task AddAsync(TEntity obj);

        TEntity Get(Guid id);

        IQueryable<TEntity> GetAll();

        Task<List<TEntity>> GetAllAsync();

        Task<TEntity> GetAsync(Guid id);

        void Remove(Guid id);

        int SaveChanges();

        void Update(TEntity obj);

        #endregion Public Methods
    }
}
