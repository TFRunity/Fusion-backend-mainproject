using Fusion.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Fusion.Models;
using System.Threading.Tasks;
using Fusion.ViewModels;
using Microsoft.AspNetCore.Identity;
using System;

namespace Fusion.Controllers
{
    //Сделать вьюхи всем контроллерам, где это необходимо
    [Authorize(Policy = "Manager")]
    public class ModeratorController : Controller
    {
        private readonly IRepository<UsersPicture> _dBMethods;
        private readonly IUserRepository<User> _identityMethods;
        public ModeratorController(IRepository<UsersPicture> dBMethods, IUserRepository<User> identityMethods)
        {
            _dBMethods = dBMethods;
            _identityMethods = identityMethods;
        }
        [HttpGet]
        public IActionResult List()
        {
            List<User> users = _identityMethods.GetAll();
            return View(users);
        }
        //Сюда попасть через ссылку в List
        [HttpGet]
        public async Task<IActionResult> EditUser(string email)
        {
            User user = await _identityMethods.Get(email);
            return View(user);
        }
        [HttpPost]
        public async Task<IActionResult> EditedUser(User editedUser)
        {
            await _identityMethods.Update(editedUser);
            return RedirectToAction(nameof(List));
        }
        //Реализовать как кнопку
        public async Task<IActionResult> Delete(string email)
        {
            await _identityMethods.Delete(email);
            return RedirectToAction(nameof(List));
        }
        //Картинки, не Async
        public async Task<IActionResult> UsersPictures(string email)
        {
            User user = await _identityMethods.Get(email);
            List<UsersPicture> usersPictures = user.UsersPictures;
            return View(usersPictures);
        }
        //
        public async Task<IActionResult> DeletePicture(Guid id)
        {
            User user = _dBMethods.Get(id).User;
            await _dBMethods.Delete(id);
            return RedirectToAction(nameof(List));
        }
        public IActionResult AddPicture(string email)
        {
            AddPictureViewModel model = new AddPictureViewModel { Email = email };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> AddPicture(AddPictureViewModel pictureViewModel)
        {
            UsersPicture picture = new UsersPicture {
                URL = pictureViewModel.Url,
                User = await _identityMethods.Get(pictureViewModel.Email)
            };
            await _dBMethods.Create(picture);
            return RedirectToAction(nameof(List));
        }
    }
}
