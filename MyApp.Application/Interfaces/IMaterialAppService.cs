using FluentValidation.Results;
using MyApp.Application.ViewModels;
using MyApp.Application.ViewModels.Manager;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyApp.Application.Interfaces
{
    public interface IMaterialAppService: IDisposable
    {
        Task<ValidationResult> Add(MaterialViewModel MaterialViewModel);

        Task<ValidationResult> Update(MaterialViewModel model);
        Task<IEnumerable<MaterialViewModel>> GetAll();
        Task<ValidationResult> Delete(Guid[] ids);

    }
}
