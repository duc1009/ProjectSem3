using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyApp.Application.ViewModels.Roles;

namespace MyApp.Web.Ui.Controllers
{
    [Authorize(Roles ="Administrator")]
    public class AdminController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        public AdminController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _roleManager.Roles.ToArrayAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(RoleViewModel RoleModel)
        {
            if (ModelState.IsValid)
            {
                var role = new IdentityRole { Name = RoleModel.Role, NormalizedName = RoleModel.Role };
                var result = await _roleManager.CreateAsync(role);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", await _roleManager.Roles.ToArrayAsync());
                }
            }
            return View(RoleModel);

        }

        public async Task<IActionResult> Edit(string id)
        {
            var role = await _roleManager.Roles.FirstOrDefaultAsync(r => r.Id == id);
            if (role == null)
            {
                return NotFound();
            }
            var roleModel = new RoleViewModel { Role = role.Name, Id = role.Id };
            return View(roleModel);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(RoleViewModel roleModel)
        {
            if (ModelState.IsValid)
            {
                var role = await _roleManager.Roles.FirstOrDefaultAsync(r => r.Id == roleModel.Id);
                role.Name = roleModel.Role;
                var result = await _roleManager.UpdateAsync(role);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", _roleManager.Roles.ToArrayAsync());
                }
            }
            return View(roleModel);
        }

        public async Task<IActionResult> Delete(string id)
        {
            if (id==null)
            {
                return NotFound();
            }
            var result = await _roleManager.FindByIdAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            var roleModel = new RoleViewModel() { Id = result.Id, Role = result.Name };
            return View(roleModel);
        }

        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ConfirmDelete (RoleViewModel roleModel)
        {
            if (!ModelState.IsValid)
            {
                var result = await _roleManager.FindByIdAsync(roleModel.Id);
                if (result==null)
                {
                    return View(roleModel);
                }
                await _roleManager.DeleteAsync(result);
                return RedirectToAction("Index");
            }
            return View();
        }
    }
}
