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
        IEnumerable<MaterialViewModel> GetAll();
        MaterialViewModel GetById(Guid id);
        void Update(MaterialViewModel model);
        void Delete(Guid[] ids);

    }
}
