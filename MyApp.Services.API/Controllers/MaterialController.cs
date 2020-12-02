
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

        private readonly IMaterialAppService MaterialAppService;

        public MaterialController( IMaterialAppService MaterialAppService) 
        {
            this.MaterialAppService = MaterialAppService;
        }

        [HttpGet("Materials")]
        public IEnumerable<MaterialViewModel> Get()
        {
            //if (!ModelState.IsValid)
            //{

            //    return Response(MaterialViewModel);
            //}


            return MaterialAppService.GetAll(); 
        }
        [Microsoft.AspNetCore.Authorization.AllowAnonymous]
        [HttpPost("Material")]
        public IActionResult Add([FromBody] MaterialViewModel MaterialViewModel)
        {
            //if (!ModelState.IsValid)
            //{
              
            //    return Response(MaterialViewModel);
            //}
            MaterialAppService.Add(MaterialViewModel);

            return CustomResponse(ModelState);
        }
    }
}
