using Fusion.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Fusion.Interfaces
{
    public interface IUserMethods
    {
        //Метод для получения пользователя
        public UserAtSite GetCurrentSiteUser(string name);
        public List<UserAtSite> GetAllSiteUsers();
        //Метод для изменения данных о пользователе
        
    }
}
