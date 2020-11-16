using NetDevPack.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyApp.Domain.Interfaces
{
    public interface ITodoAppRepository : IRepository<Models.TodoApp>
    {
        Task<Models.TodoApp> GetById(Guid id);
        Task<Models.TodoApp> GetByName(string name);
        Task<IEnumerable<Models.TodoApp>> GetAll();
        Task<IEnumerable<Models.TodoApp>> FilterByStatus(string status);

        void Add(Models.TodoApp todoApp);
        void Update(Models.TodoApp todoApp);
        void Remove(Models.TodoApp todoApp);
    }
}
