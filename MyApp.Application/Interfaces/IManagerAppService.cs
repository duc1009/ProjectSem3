using FluentValidation.Results;
using MyApp.Application.ViewModels.Manager;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyApp.Application.Interfaces
{
    public interface IManagerAppService : IDisposable
    {
        Task<IEnumerable<ManagerViewModel>> GetAllMember(string managerId);
        Task<IEnumerable<ManagerViewModel>> GetAll();

        Task<bool> Find(ManagerViewModel manager);

        Task<ValidationResult> AddMember(ManagerViewModel manager);

        Task<ValidationResult> Remove(ManagerViewModel manager);

        

    }
}
