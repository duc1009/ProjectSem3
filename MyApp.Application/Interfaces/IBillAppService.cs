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
        Task<ValidationResult> Delete(Guid[] ids);
        Task<IEnumerable<BillViewModel>> ListBill(BillQueryModel urlQuery);
        Task<IEnumerable<StatisticPeopleBuyViewModel>> ListPeopleBuy(StatisticPeopleBuyQueryModel urlQuery);
        BillViewModel GetById(Guid id);

    }
}
