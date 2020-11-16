using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyApp.Application.Interfaces;
using MyApp.Application.ViewModels.Manager;
using MyApp.Domain.Models;

namespace MyApp.Web.Ui.Controllers
{
    [Authorize(Roles = "Manager")]
    public class ManagerController : Controller
    {
        private readonly IManagerAppService _managerAppService;
        private readonly UserManager<IdentityUser> _userManager;
        public ManagerController(IManagerAppService managerAppService, UserManager<IdentityUser> userManager)
        {
            _managerAppService = managerAppService;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            var currManager = _userManager.FindByNameAsync(User.Identity.Name).Result;
            var UsersManager = await _managerAppService.GetAll();
            if (UsersManager.Equals(null)) return View();
            var members = new List<IdentityUser>();
            foreach (var item in UsersManager)
            { 
                if (item.ManagerId == currManager.Id)
                {
                    var user = await _userManager.FindByIdAsync(item.UserId);
                    members.Add(user);
                }
            }
            return View(members);
        }

        public async Task<IActionResult> AddMember()
        {
            var currManager = await _userManager.FindByNameAsync(User.Identity.Name);
            var membersModel = new AddMemberViewModel()
            {
                ManagerId = currManager.Id,
                Email = currManager.Email,
                Members = new List<string>(),
                NewMember = null
            };

            foreach (var item in _userManager.Users)
            {
                var managerVM = new ManagerViewModel()
                {
                    ManagerId = currManager.Id,
                    UserId = item.Id
                };
                if (_userManager.IsInRoleAsync(item, "User").Result && !_managerAppService.Find(managerVM).Result)
                {                   
                    membersModel.Members.Add(item.Email);
                }
            }
            return View(membersModel);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddMember(AddMemberViewModel membersModel)
        {

            if (ModelState.IsValid)
            {
                var currManager = await _userManager.FindByNameAsync(User.Identity.Name);
                var newUser = await _userManager.FindByEmailAsync(membersModel.NewMember);
                var managerUser = new ManagerViewModel() { Id= Guid.NewGuid().ToString(), ManagerId = currManager.Id, UserId = newUser.Id };
                if (!_managerAppService.Find(managerUser).Result)
                {
                    await _managerAppService.AddMember(managerUser);
                    var usersManager = await _managerAppService.GetAll();
                    var members = new List<IdentityUser>();
                    foreach (var item in usersManager)
                    {
                        if (item.ManagerId == currManager.Id)
                        {
                            var user = await _userManager.FindByIdAsync(item.UserId);
                            members.Add(user);
                        }
                    }
                    return RedirectToAction("Index", members.ToList());
                }
            }
            return View(membersModel);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            var userOfTeam = await _userManager.FindByIdAsync(id);
            if (userOfTeam == null) return NotFound();
            return View(userOfTeam);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public async Task<IActionResult> ConfirmDelete(string id)
        {
            if (ModelState.IsValid)
            {
                var currManager = await _userManager.FindByNameAsync(User.Identity.Name);
                var user = await _userManager.FindByIdAsync(id);
                if (user == null) return NotFound();
                var manager = new ManagerViewModel() { Id = Guid.NewGuid().ToString(), ManagerId = currManager.Id, UserId = user.Id };
                await _managerAppService.Remove(manager);
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
