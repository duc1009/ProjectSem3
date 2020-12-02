using FluentValidation.Results;
using MyApp.Application.ViewModels;
using MyApp.Application.ViewModels.Manager;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyApp.Application.Interfaces
{
    public interface IMaterialAppService
    {
        void Add(MaterialViewModel MaterialViewModel);
    
        void Update(MaterialViewModel model);
        IEnumerable<MaterialViewModel> GetAll();
        void Delete(Guid[] ids);

    }
}
