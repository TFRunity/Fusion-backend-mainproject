using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fusion.Models;
using Fusion.DatabaseMethods;
using Fusion.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Fusion.Controllers
{
    [AllowAnonymous]
    public class HomeController : Controller
    {
        private readonly IUserMethods _userMethods;
        public HomeController(IUserMethods userMethods)
        {
            _userMethods = userMethods;
        }
        public IActionResult Index()
        {
            List<UserAtSite> users = _userMethods.GetAllSiteUsers();
            return View(users);
        }
        public IActionResult AccessDenied()
        {
            return View();
        }
        public IActionResult Visitor(string name)
        {
            UserAtSite user = _userMethods.GetCurrentSiteUser(name);
            return View(user);
        }
    }
}
