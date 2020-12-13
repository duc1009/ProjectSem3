
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
    public class StatisticController : ApiController
    {
        private readonly IBillAppService billAppService;

        public StatisticController( IBillAppService BillAppService) 
        {
            this.billAppService = BillAppService;
        }

        [HttpGet("statis-people")]  
        public async Task<IEnumerable<StatisticPeopleBuyViewModel>> GetList(StatisticPeopleBuyParam param)
        {            
            return await billAppService.ListPeopleBuy(new StatisticPeopleBuyQueryModel() {User= param.UserName });
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


    public class StatisticPeopleBuyParam
    {
        public string UserName { get; set; }
    }
}
