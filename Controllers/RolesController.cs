using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Fusion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fusion.ViewModels;

namespace Fusion.Controllers
{
    [Authorize(Policy = "Admin")]
    public class RolesController : Controller
    {
        RoleManager<UserRole> _roleManager;
        UserManager<User> _userManager;
        public RolesController(RoleManager<UserRole> roleManager, UserManager<User> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }
        public IActionResult Index() => View(_roleManager.Roles.ToList());

        public IActionResult Create() => View();
        [HttpPost]
        public async Task<IActionResult> Create(string name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                IdentityResult result = await _roleManager.CreateAsync(new UserRole(name));
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                    
                }
            }
            return View(name);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            UserRole role = await _roleManager.FindByIdAsync(id);
            if (role != null)
            {
                var result = await _roleManager.DeleteAsync(role);
            }
            return RedirectToAction("Index");
        }

        public IActionResult UserList() => View(_userManager.Users.ToList());

        public async Task<IActionResult> Edit(string name)
        {
            // получаем пользователя
            User user = await _userManager.FindByNameAsync(name);
            if (user != null)
            {
                // получем список ролей пользователя
                var userRoles = await _userManager.GetRolesAsync(user);
                var allRoles = _roleManager.Roles.ToList();
                ChangeRoleViewModel model = new ChangeRoleViewModel
                {
                    Id = user.Id,
                    UserEmail = user.Email,
                    UserRoles = userRoles,
                    AllRoles = allRoles
                };
                return View(model);
            }

            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(string name, List<string> roles)
        {
            // получаем пользователя
            User user = await _userManager.FindByEmailAsync(name);
            if (user != null)
            {
                // получем список ролей пользователя
                var userRoles = await _userManager.GetRolesAsync(user);
                // получаем все роли
                var allRoles = _roleManager.Roles.ToList();
                // получаем список ролей, которые были добавлены
                var addedRoles = roles.Except(userRoles);
                // получаем роли, которые были удалены
                var removedRoles = userRoles.Except(roles);
                if (addedRoles != null)
                {
                    await _userManager.AddToRolesAsync(user, addedRoles);
                }
                else
                {
                    await _userManager.AddToRoleAsync(user, "Anon");
                }
                await _userManager.RemoveFromRolesAsync(user, removedRoles);

                return RedirectToAction("UserList");
            }

            return NotFound();
        }
    }
}
