using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyApp.Application.Interfaces;
using MyApp.Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyApp.Services.API.Controllers
{
    [Route("api/[controller]")]
    public class TodoAppController : ApiController
    {
        private readonly ITodoAppService _todoAppService;
        public TodoAppController(ITodoAppService todoAppService)
        {
            _todoAppService = todoAppService;
        }

        [HttpGet("list-all")]
        public async Task<IEnumerable<TodoAppViewModel>> Get()
        {
            return await _todoAppService.GetAll();
        }

        [HttpGet("get/{id:guid}")]
       
        public async Task<TodoAppViewModel>  Get([FromRoute] Guid id)
        {
            return await _todoAppService.GetById(id);
        }

        [HttpGet("get-script")]
        public IActionResult GetScript()
        {
            var script = "$('#button2').click(function() {alert('Goi thanh cong');});";
            var result = new ContentResult
            {
                Content = script,
                ContentType = "application/javascript"
            };
            return result;
        }

        [HttpGet("getFromQuery")]
        public async Task<TodoAppViewModel> GetFromQuery([FromQuery] Guid id)
        {
            return await _todoAppService.GetById(id);
        }

        [HttpGet("getFromHeader")]
        public async Task<TodoAppViewModel> GetFromHeader([FromHeader] Guid id)
        {
            var todoApp = await _todoAppService.GetById(id);
            if (todoApp!=null)
            {
                return todoApp;
            }
            return todoApp;
        }

        [HttpGet("getByStatus/{status}")]
        public async Task<IEnumerable<TodoAppViewModel>> Get(string status)
        {
            return await _todoAppService.FilterByStatus(status);
        }

        [HttpPost("create")]
        public async Task<IActionResult> Post([FromForm] TodoAppViewModel todoAppViewModel)
        {
            return ModelState.IsValid ? CustomResponse(await _todoAppService.Register(todoAppViewModel))
                : CustomResponse(todoAppViewModel);
        }

        [HttpPut("update")]
        public async Task<IActionResult> Put([FromBody] TodoAppViewModel todoAppViewModel)
        {
            return ModelState.IsValid ? CustomResponse(await _todoAppService.Update(todoAppViewModel))
                : CustomResponse(todoAppViewModel);
        }


        [HttpDelete("remove")]
        public async Task<IActionResult> Delete(Guid id)
        {
            return CustomResponse(await _todoAppService.Remove(id));
        }

        [HttpPut("isDone")]
        public async Task<IActionResult> IsDone(Guid id)
        {
            return CustomResponse(await _todoAppService.IsDone(id));
        }
    }
}
