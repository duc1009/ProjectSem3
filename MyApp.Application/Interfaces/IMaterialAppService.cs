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
        Task<ValidationResult> Add(MaterialViewModel model);

        Task<ValidationResult> Update(MaterialViewModel model);
        Task<IEnumerable<MaterialViewModel>> GetAll();
        void Delete(Guid[] ids);
    }
}
