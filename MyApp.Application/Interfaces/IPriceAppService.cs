using FluentValidation.Results;
using MyApp.Application.ViewModels.Price;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Interfaces
{
    public interface IPriceAppService : IDisposable
    {
        Task<ValidationResult> Add(PriceViewModel priceViewModel);

        Task<ValidationResult> Update(PriceViewModel priceViewModel);
        Task<IEnumerable<PriceViewModel>> GetAll();
        Task<ValidationResult> DeleteAsync(Guid[] ids);
        Task<PriceViewModel> GetById(Guid id);
    }
}
