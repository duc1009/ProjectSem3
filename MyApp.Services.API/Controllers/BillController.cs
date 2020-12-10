
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyApp.Application.Interfaces;
using MyApp.Application.ViewModels;
using MyApp.Domain.Interfaces;
using MyApp.Domain.ModelQueries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApp.Services.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BillController: ApiController
    {
        private readonly IBillAppService billAppService;

        public BillController( IBillAppService BillAppService) 
        {
            this.billAppService = BillAppService;
        }

        [HttpGet("all-bill")]
        public async Task<IEnumerable<BillViewModel>> Get()
        {
            return await billAppService.GetAll(); 
        }
        
        [HttpGet("all-bill-param")]
        public async Task<IEnumerable<BillViewModel>> GetList()
        {
            
            return await billAppService.ListBill(new BillQueryModel() {  });
        }

        [Microsoft.AspNetCore.Authorization.AllowAnonymous]
        [HttpPost("add-bill")]
        public async Task<IActionResult> Add([FromBody] BillViewModel billViewModel)
        {
            return ModelState.IsValid ? CustomResponse(await billAppService.Add(billViewModel))
                 : CustomResponse(billViewModel);
        }
        [HttpPut("update-bill")]
        public async Task<IActionResult> Put([FromBody] BillViewModel billViewModel)
        {
            return ModelState.IsValid ? CustomResponse(await billAppService.Update(billViewModel))
                : CustomResponse(billViewModel);
        }

        [HttpDelete("bills")]
        public async Task<IActionResult> Delete([FromBody] Guid[] ids)
        {
            return CustomResponse(await billAppService.Delete(ids));
        }
    }


    public class BillParam 
    {
        public DateTime Date { get; set; }
    }
}
