using FluentValidation.Results;
using MyApp.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Interfaces
{
    public interface ISizeAppService : IDisposable
    {
        Task<ValidationResult> Add(SizeViewModel sizeViewModel);

        Task<ValidationResult> Update(SizeViewModel sizeViewModel);
        Task<IEnumerable<SizeViewModel>> GetAll();
        Task<ValidationResult> DeleteAsync(Guid[] ids);
        Task<SizeViewModel> GetById(Guid id);

    }
}
