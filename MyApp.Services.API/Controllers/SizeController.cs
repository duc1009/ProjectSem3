using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyApp.Application.Interfaces;
using MyApp.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApp.Services.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SizeController : ApiController
    {
        private readonly ISizeAppService _sizeAppService;
        public SizeController(ISizeAppService sizeAppService)
        {
            _sizeAppService = sizeAppService;
        }

        [HttpGet("sizes")]
        public async Task<IEnumerable<SizeViewModel>> Get()
        {
            return await _sizeAppService.GetAll();
        }

        [HttpGet("size/{id:guid}")]

        public async Task<SizeViewModel> Get([FromRoute] Guid id)
        {
            return await _sizeAppService.GetById(id);
        }
        [HttpPost("size")]
        public async Task<IActionResult> Post([FromBody] SizeViewModel sizeViewModel)
        {
            return ModelState.IsValid ? CustomResponse(await _sizeAppService.Add(sizeViewModel))
                : CustomResponse(sizeViewModel);
        }

        [HttpPut("size/{id:guid}")]
        public async Task<IActionResult> Put([FromBody] SizeViewModel sizeViewModel)
        {
            return ModelState.IsValid ? CustomResponse(await _sizeAppService.Update(sizeViewModel))
                : CustomResponse(sizeViewModel);
        }


        [HttpDelete("remove")]
        public async Task<IActionResult> Delete(Guid[] id)
        {
            return CustomResponse(await _sizeAppService.DeleteAsync(id));
        }

    }
}
