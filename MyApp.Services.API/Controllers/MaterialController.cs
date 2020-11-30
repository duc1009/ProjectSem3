
using Microsoft.AspNetCore.Mvc;
using MyApp.Application.ViewModels;
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

        [HttpPost("Material")]
        public IActionResult Add([FromBody] MaterialViewModel MaterialViewModel)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(MaterialViewModel);
            }
            MaterialAppService.Add(MaterialViewModel);

            return Response(MaterialViewModel);
        }
    }
}
