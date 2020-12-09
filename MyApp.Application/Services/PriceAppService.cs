using AutoMapper;
using FluentValidation.Results;
using MyApp.Application.Interfaces;
using MyApp.Application.ViewModels.Price;
using MyApp.Domain.Commands.PriceCommands;
using MyApp.Domain.Interfaces;
using NetDevPack.Mediator;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Application.Services
{
    public class PriceAppService : IPriceAppService
    {
        private readonly IMapper _mapper;
        private readonly IPriceRepository _priceRepository;
        private readonly IMediatorHandler _mediator;

        public PriceAppService(IMapper mapper, IPriceRepository priceRepository, IMediatorHandler mediator)
        {
            _mapper = mapper;
            _priceRepository = priceRepository;
            _mediator = mediator;
        }
        public async Task<ValidationResult> Add(PriceViewModel priceViewModel)
        {
            var addCommand = _mapper.Map<AddPriceCommand>(priceViewModel);
            return await _mediator.SendCommand(addCommand);
        }

        public async Task<ValidationResult> DeleteAsync(Guid[] ids)
        {
            var deleteCommand = new DeletePriceCommand(ids);
            return await _mediator.SendCommand(deleteCommand);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public async Task<IEnumerable<PriceViewModel>> GetAll()
        {
            return _mapper.Map<IEnumerable<PriceViewModel>>(await _priceRepository.GetAll());
        }

        public async Task<PriceViewModel> GetById(Guid id)
        {
            return _mapper.Map<PriceViewModel>(await _priceRepository.GetById(id));
        }

        public async Task<ValidationResult> Update(PriceViewModel priceViewModel)
        {
            var updateCommand = _mapper.Map<UpdatePriceCommand>(priceViewModel);
            return await _mediator.SendCommand(updateCommand);
        }
    }
}
