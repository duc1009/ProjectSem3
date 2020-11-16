using FluentValidation.Results;
using MyApp.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyApp.Application.Interfaces
{
    public interface ITodoAppService : IDisposable
    {
        Task<IEnumerable<TodoAppViewModel>> GetAll();
        Task<IEnumerable<TodoAppViewModel>> FilterByStatus(string status);
        Task<TodoAppViewModel> GetById(Guid id);

        Task<ValidationResult> Register(TodoAppViewModel todoAppViewModel);
        Task<ValidationResult> Report(TodoAppViewModel todoAppViewModel);
        Task<ValidationResult> Remove(Guid id);

        Task<ValidationResult> Update(TodoAppViewModel todoAppViewModel);

        Task<ValidationResult> IsDone(Guid id);
    
    }
}
