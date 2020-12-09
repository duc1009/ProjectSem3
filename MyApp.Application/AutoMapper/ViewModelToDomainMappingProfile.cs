using AutoMapper;
using MyApp.Application.ViewModels;
using MyApp.Application.ViewModels.Manager;
using MyApp.Application.ViewModels.Price;
using MyApp.Domain.Commands;
using MyApp.Domain.Commands.ManagerCommands;
using MyApp.Domain.Commands.PriceCommands;
using MyApp.Domain.Commands.SizeCommands;

namespace MyApp.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            // todoApp
            CreateMap<TodoAppViewModel, CreateTodoAppCommand>()
                .ConstructUsing(c => new CreateTodoAppCommand(c.Name, c.Content, c.FinishedAt));
            CreateMap<TodoAppViewModel, ReportTodoAppCommand>()
                .ConstructUsing(c => new ReportTodoAppCommand(c.Id, c.CreatedAt, c.Status, c.Description));
            CreateMap<TodoAppViewModel, UpdateTodoAppCommand>()
                .ConstructUsing(c => new UpdateTodoAppCommand(c.Id, c.Name, c.CreatedAt, c.Content, c.FinishedAt));

            //manager

            CreateMap<ManagerViewModel, CreateManagerCommand>()
                 .ConstructUsing(m => new CreateManagerCommand(m.Id, m.ManagerId, m.UserId));
            CreateMap<ManagerViewModel, UpdateManagerCommand>()
                 .ConstructUsing(m => new UpdateManagerCommand(m.ManagerId, m.UserId));
            CreateMap<ManagerViewModel, RemoveManagerCommand>()
                 .ConstructUsing(m => new RemoveManagerCommand(m.ManagerId));

            //Material
            CreateMap<MaterialViewModel, AddMaterialCommand>()
                .ConstructUsing(m => new AddMaterialCommand(m.Name));
            CreateMap<MaterialViewModel, UpdateMaterialCommand>()
                 .ConstructUsing(m => new UpdateMaterialCommand(m.Id, m.Name));
            // Price
            CreateMap<PriceViewModel, AddPriceCommand>()
                .ConstructUsing(p => new AddPriceCommand(p.MaterialId, p.SizeId, p.Value));
            CreateMap<PriceViewModel, UpdatePriceCommand>()
                .ConstructUsing(p => new UpdatePriceCommand(p.Id, p.MaterialId, p.SizeId, p.Value));
            //    CreateMap<PriceViewModel, DeleteMaterialCommand>()
            //.ConstructUsing(p => new DeleteMaterialCommand(p.Id));

            // Size
            CreateMap<SizeViewModel, AddSizeCommand>()
                .ConstructUsing(s => new AddSizeCommand(s.Name));
            CreateMap<SizeViewModel, UpdateSizeCommand>()
                .ConstructUsing(s => new UpdateSizeCommand(s.Id, s.Name));
            //Bill
            CreateMap<BillViewModel, AddBillCommand>()
                 .ConstructUsing(m => new AddBillCommand(m.UserId, m.TotalMoney, m.Date, m.Note, m.StatusId, m.StatusPayId, m.PaymentId))
                 .ForMember(x => x.BillDetails, o => o.MapFrom(e => e.BillDetails));
            CreateMap<BillViewModel, UpdateBillCommand>()
                 .ConstructUsing(m => new UpdateBillCommand(m.Id, m.UserId, m.TotalMoney, m.Date, m.Note, m.StatusId, m.StatusPayId, m.PaymentId))
                 .ForMember(x => x.BillDetails, o => o.MapFrom(e => e.BillDetails));
        }

    }
}
