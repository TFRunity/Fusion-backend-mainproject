using Fusion.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Fusion.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Claims;
using Fusion.Interfaces;

namespace Fusion.Controllers
{
    [AllowAnonymous]
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly IUserMethods _userRepository;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, IUserMethods userMethods)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _userRepository = userMethods;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = new User { Email = model.Email, UserName = model.Name, Year = model.Year, FutureJob = model.FutureJob};
                // добавляем пользователя
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    // установка куки
                    await _userManager.AddClaimAsync(user, new Claim(ClaimTypes.Role, "Anon"));
                    await _signInManager.SignInAsync(user, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return View(model);
        }
        public IActionResult PersonalArea()
        {
            return View();
        }
        [Authorize(Policy = "Manager")]
        public IActionResult AdminArea()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Login(string returnUrl = null)
        {
            return View(new LoginViewModel { ReturnUrl = returnUrl });
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            
                var result =
                    await _signInManager.PasswordSignInAsync(model.Name, model.Password, model.RememberMe, false);
                if (result.Succeeded)
                {
                    // проверяем, принадлежит ли URL приложению
                    if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
                    {
                        return Redirect(model.ReturnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Неправильный логин и (или) пароль");
                }
            return View(model);
        }
        [Authorize(Policy = "Member")]
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            // удаляем аутентификационные куки
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
