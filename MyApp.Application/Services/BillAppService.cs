using AutoMapper;
using AutoMapper.QueryableExtensions;
using FluentValidation.Results;
using MyApp.Application.Interfaces;
using MyApp.Application.ViewModels;
using MyApp.Domain.Commands;
using MyApp.Domain.Interfaces;
using MyApp.Domain.ModelQueries;
using MyApp.Domain.Queries;
using NetDevPack.Mediator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApp.Application.Services
{
    public class BillAppService : IBillAppService
    {
        private readonly IMapper mapper;
        private readonly IBillRepository repository;
        private readonly IBillQueries _queries;
        private readonly IMediatorHandler _mediator;

        public BillAppService(IMapper mapper, IBillRepository repository, IBillQueries queries, IMediatorHandler mediator)
        {
            this.mapper = mapper;
            this.repository = repository;
            this._mediator = mediator;
            this._queries = queries;
        }

        public async Task<ValidationResult> Add(BillViewModel BillViewModel)
        {
            var addCommand = mapper.Map<AddBillCommand>(BillViewModel);
            return await _mediator.SendCommand(addCommand);
        }

        public void Delete(Guid[] ids)
        {
            var deleteCommand = new DeleteBillCommand(ids);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        public async Task<IEnumerable<BillViewModel>> GetAll()
        {
            return mapper.Map<IEnumerable<BillViewModel>>(await repository.GetAll());
        }

        public async Task<ValidationResult> Update(BillViewModel model)
        {
            var updateCommand = mapper.Map<UpdateBillCommand>(model);
            return await _mediator.SendCommand(updateCommand);
        }

        public BillViewModel GetById(Guid id)
        {
            return mapper.Map<BillViewModel>(repository.GetByIdNotAsync(id));

        }
        public async Task<IEnumerable<BillViewModel>> ListBill(BillQueryModel urlQuery)
        {
            var Bills = await _queries.GetBill(urlQuery);

            return Bills.AsQueryable().ProjectTo<BillViewModel>(mapper.ConfigurationProvider);
        }
    }
}
