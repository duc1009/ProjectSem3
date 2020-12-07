
using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyApp.Application.Interfaces;
using MyApp.Application.ViewModels;
using MyApp.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApp.Services.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaterialController: ApiController
    {
        private readonly IMaterialAppService materialAppService;

        public MaterialController( IMaterialAppService MaterialAppService) 
        {
            this.materialAppService = MaterialAppService;
        }

        [HttpGet("Materials")]
        public async Task<IEnumerable<MaterialViewModel>> Get()
        {
            return await materialAppService.GetAll(); 
        }
        [Microsoft.AspNetCore.Authorization.AllowAnonymous]
        [HttpPost("Material")]
        public async Task<IActionResult> Add([FromBody] MaterialViewModel materialViewModel)
        {
            return ModelState.IsValid ? CustomResponse(await materialAppService.Add(materialViewModel))
                 : CustomResponse(materialViewModel);
        }
    }
}
