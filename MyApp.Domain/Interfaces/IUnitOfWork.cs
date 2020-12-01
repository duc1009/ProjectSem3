using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.Domain.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        bool Commit();
    }
}
