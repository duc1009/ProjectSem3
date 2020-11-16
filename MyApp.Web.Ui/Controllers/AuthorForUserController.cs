using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyApp.Application.ViewModels.AuthorForUser;

namespace MyApp.Web.Ui.Controllers
{
    
    [Authorize(Roles = "Administrator")]
    public class AuthorForUserController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;


        public AuthorForUserController(UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public ActionResult Index()

        {
            return View(_userManager.Users.ToList());

        }

        public ActionResult Delete(string id)
        {
            var userModel = _userManager.Users.FirstOrDefault(u => u.Id == id);
            if (userModel == null)
            {
                return NotFound();
            }
            return View(userModel);
        }

        [HttpPost]

        [ValidateAntiForgeryToken]

        [ActionName("Delete")]

        public async Task<ActionResult> DeleteConfirmed(string id)

        {
            if (ModelState.IsValid)
            {
                var user = _userManager.Users.FirstOrDefaultAsync(u => u.Id == id);
                var result = await _userManager.DeleteAsync(user.Result);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index", await _userManager.Users.ToListAsync());
                }
            }
            return View();
        }

        public async Task<IActionResult> EditRoles(string id)
        {
            List<string> roles = new List<string>();
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            var userModel = new UserRolesModel
            {
                Id = id,
                Email = user.Email,
                RolesName = new List<string>(),
                NewRole = null
            };
            foreach (var item in _roleManager.Roles.ToList())
            {

                if (_userManager.IsInRoleAsync(user, item.Name).Result)
                {
                    userModel.RolesName.Add(item.Name);
                }
                else roles.Add(item.Name);
            }
            ViewBag.roles = roles;
            return View(userModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("EditRoles")]
        public async Task<IActionResult> AddRoleToUser(UserRolesModel userModel)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByIdAsync(userModel.Id);
                if (user == null) return View(userModel);
                var newRole = await _roleManager.FindByNameAsync(userModel.NewRole);
                if (newRole == null) return View(userModel);
                if (userModel.RolesName == null)
                {
                    await _userManager.AddToRoleAsync(user, newRole.Name);
                    userModel.RolesName = new List<string>();
                    userModel.RolesName.Add(newRole.Name);
                    return RedirectToAction("Index", _userManager.Users.ToList());
                }
                if (!userModel.RolesName.Contains(newRole.Name))
                {
                    userModel.RolesName.Add(newRole.Name);
                    await _userManager.AddToRoleAsync(user, newRole.Name);
                    return RedirectToAction("Index", _userManager.Users.ToList());
                }
            }
            return View(userModel);
        }
        public async Task<IActionResult> RemoveRole(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            var userModel = new UserRolesModel
            {
                Id = id,
                Email = user.Email,
                RolesName = new List<string>(),
                NewRole = null
            };
            foreach (var item in _roleManager.Roles)
            {
                if (_userManager.IsInRoleAsync(user, item.Name).Result)
                {
                    userModel.RolesName.Add(item.Name);
                }
            }
            return View(userModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("RemoveRole")]
        public async Task<IActionResult> RemoveRoleFrUser(UserRolesModel userModel)
        {
            if (ModelState.IsValid)
            {
                var roleRemove = await _roleManager.FindByNameAsync(userModel.NewRole);
                var user = await _userManager.FindByIdAsync(userModel.Id);
                if (roleRemove != null)
                {
                    if (await _userManager.IsInRoleAsync(user, roleRemove.Name))
                    {
                        userModel.RolesName.Remove(roleRemove.Name);
                        await _userManager.RemoveFromRoleAsync(user, roleRemove.Name);
                        return RedirectToAction("Index", _userManager.Users.ToList());
                    }
                }
            }
            return View(userModel);
        }
    }
   
}
