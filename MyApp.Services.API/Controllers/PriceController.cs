using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyApp.Application.Interfaces;
using MyApp.Application.ViewModels.Price;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApp.Services.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PriceController : ApiController
    {
        private readonly IPriceAppService _priceAppService;
        public PriceController(IPriceAppService priceAppService)
        {
            _priceAppService = priceAppService;
        }

        [HttpGet("prices")]
        public async Task<IEnumerable<PriceViewModel>> Get()
        {
            return await _priceAppService.GetAll();
        }

        [HttpGet("price/{id:guid}")]

        public async Task<PriceViewModel> Get([FromRoute] Guid id)
        {
            return await _priceAppService.GetById(id);
        }
        [HttpPost("price")]
        public async Task<IActionResult> Post([FromBody] PriceViewModel priceViewModel)
        {
            return ModelState.IsValid ? CustomResponse(await _priceAppService.Add(priceViewModel))
                : CustomResponse(priceViewModel);
        }

        [HttpPut("price/{id:guid}")]
        public async Task<IActionResult> Put([FromBody] PriceViewModel priceViewModel)
        {
            return ModelState.IsValid ? CustomResponse(await _priceAppService.Update(priceViewModel))
                : CustomResponse(priceViewModel);
        }


        [HttpDelete("remove")]
        public async Task<IActionResult> Delete(Guid[] id)
        {
            return CustomResponse( await _priceAppService.DeleteAsync(id));
        }

    }
}
