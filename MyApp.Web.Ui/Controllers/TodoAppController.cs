using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using ClosedXML.Excel;
using DocumentFormat.OpenXml.Office2010.ExcelAc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyApp.Application.Interfaces;
using MyApp.Application.ViewModels;
using MyApp.Domain.Models;
using MyApp.Web.Ui.Panigation;

namespace MyApp.Web.Ui.Controllers
{
    [Authorize(Roles ="User,Manager")]
    public class TodoAppController : BaseController
    {
        private readonly ITodoAppService _todoAppService;

        public TodoAppController(ITodoAppService todoAppService)
        {
            _todoAppService = todoAppService;
        }

        [HttpGet]

        public async Task<IActionResult> Index(int? pageNumber)
        {
            return View(await PaginatedList<TodoAppViewModel>.CreateAsync(_todoAppService.GetAll().Result, pageNumber ?? 1, 4));
        }

        public IActionResult Create() => base.View();


        [HttpPost]
        public async Task<IActionResult> Create(TodoAppViewModel todoAppViewModel)
        {
            if (!ModelState.IsValid) return View(todoAppViewModel);

            if (ResponseHasErrors(await _todoAppService.Register(todoAppViewModel)))
                return View(todoAppViewModel);

            ViewBag.Sucess = "Task Registered!";

            return View(todoAppViewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null) return NotFound();
            var task = await _todoAppService.GetById(id.Value);
            if (task == null)
            {
                return NotFound();
            }
            return View(task);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null) return NotFound();
            var task = await _todoAppService.GetById(id.Value);
            if (task == null)
            {
                return NotFound();
            }
            return View(task);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Guid id)
        {
            if (ResponseHasErrors(await _todoAppService.Remove(id)))
            {
                return View(await _todoAppService.GetById(id));
            }
            ViewBag.Sucess = "Task removed";
            return RedirectToAction("Index");
        }

        [Authorize(Roles = "User")]
        [HttpGet]
        public async Task<IActionResult> Report(Guid? id)
        {
            if (!id.HasValue) return NotFound();
            var task = await _todoAppService.GetById(id.Value);
            if (task == null) return NotFound();
            string[] status = { "Đã hoàn thành", "Sắp hoàn thành", "Chưa hoàn thành" };
            ViewBag.Status = status;
            return View(task);
        }
        [Authorize(Roles ="User")]
        [HttpPost]
        public async Task<IActionResult> Report(TodoAppViewModel taskReported)
        {
            if (taskReported.Status != "Đã hoàn thành" && taskReported.Description == null)
            {
                ViewBag.ErrorMessage = "Please fill the Description !";
                string[] status = { "Đã hoàn thành", "Sắp hoàn thành", "Chưa hoàn thành" };
                ViewBag.Status = status;
                return View(await _todoAppService.GetById(taskReported.Id));
            }
            if (ResponseHasErrors(await _todoAppService.Report(taskReported)))
            {
                return View(_todoAppService.GetById(taskReported.Id));
            }
            return RedirectToAction("Index");
        }

        [Authorize(Roles ="Manager")]  
        public IActionResult Excel()
        {

            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Report TodoApp");
                var currentRow = 1;
                worksheet.Cell(currentRow, 1).Value = "Name";
                worksheet.Cell(currentRow, 2).Value = "Content";
                worksheet.Cell(currentRow, 3).Value = "CreatedAt";
                worksheet.Cell(currentRow, 4).Value = "FinishedAt";
                worksheet.Cell(currentRow, 5).Value = "Reported";
                worksheet.Cell(currentRow, 6).Value = "Status";
                worksheet.Cell(currentRow, 7).Value = "Description";
                foreach (var todoApp in _todoAppService.GetAll().Result.Where(t=>t.Reported==true))
                {
                    currentRow++;
                    worksheet.Cell(currentRow, 1).Value = todoApp.Name;
                    worksheet.Cell(currentRow, 2).Value = todoApp.Content;
                    worksheet.Cell(currentRow, 3).Value = todoApp.CreatedAt;
                    worksheet.Cell(currentRow, 4).Value = todoApp.FinishedAt;
                    worksheet.Cell(currentRow, 5).Value = todoApp.Reported;
                    worksheet.Cell(currentRow, 6).Value = todoApp.Status;
                    worksheet.Cell(currentRow, 7).Value = todoApp.Description;
                }

                using (var stream = new MemoryStream())
                {
                    workbook.SaveAs(stream);
                    var content = stream.ToArray();

                    return File(
                        content,
                        "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                        "Report.xlsx");
                }
            }
        }
    }
}
