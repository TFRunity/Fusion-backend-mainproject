using Fusion.DataBase;
using Fusion.Interfaces;
using Fusion.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fusion.DatabaseMethods
{
    public class DBModeratorMethods<T> : IRepository<T> where T: UsersPicture
    {
        private readonly IdentityDBContext _appDBContext;
        private readonly UserManager<User> _userManager;
        public DBModeratorMethods(IdentityDBContext appDBContext, UserManager<User> userManager)
        {
            _appDBContext = appDBContext;
            _userManager = userManager;
            }
        public async Task Create(T copyFirstModel)
        {
            User olduser = await _userManager.FindByEmailAsync(copyFirstModel.User.Email);
            if (olduser.UsersPictures != null)
            {
                List<UsersPicture> newpictures = olduser.UsersPictures;
                newpictures.Add(copyFirstModel);
                olduser.UsersPictures = newpictures;
            }
            else
            {
                List<UsersPicture> pictures = new List<UsersPicture>
                {
                    copyFirstModel
                };
                olduser.UsersPictures = pictures;
            }
            await _userManager.UpdateAsync(olduser);
        }
        public async Task Delete(Guid Id)
        {
            var userpicture = _appDBContext.UsersPictures.Find(Id);
            _appDBContext.UsersPictures.Remove(userpicture);
            await _appDBContext.SaveChangesAsync();
        }
        public T Get(Guid id)
        {
            T userpicture = (T)_appDBContext.UsersPictures.Find(id);
            return userpicture;
        }
        public List<T> GetAll(int id)
        {
            T picture = (T)_appDBContext.UsersPictures.ElementAt(id);
            User user = picture.User;
            List<T> AllModelPictures = new List<T>();
            foreach (T _picture in _appDBContext.UsersPictures)
            {
                if(_picture.User == user)
                    AllModelPictures.Add(_picture);
            }
            return AllModelPictures;
        }
    }
}
