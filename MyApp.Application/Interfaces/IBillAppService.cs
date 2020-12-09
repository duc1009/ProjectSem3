using FluentValidation.Results;
using MyApp.Application.ViewModels;
using MyApp.Application.ViewModels.Manager;
using MyApp.Domain.ModelQueries;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyApp.Application.Interfaces
{
    public interface IBillAppService: IDisposable
    {
        Task<ValidationResult> Add(BillViewModel BillViewModel);

        Task<ValidationResult> Update(BillViewModel model);
        Task<IEnumerable<BillViewModel>> GetAll();
        void Delete(Guid[] ids);
        Task<IEnumerable<BillViewModel>> ListBill(BillQueryModel urlQuery);
        BillViewModel GetById(Guid id);

    }
}
