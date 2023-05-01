using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Fusion.Models;

namespace Fusion.Models
{
    public class UserAtSite
    {
        public UserAtSite(User user)
        {
            Name = user.UserName;
            Description = user.Description;
            UserPictures = (List<UsersPicture>)user.UsersPictures;
            Year = user.Year;
            MainPicture = user.MainPicture;
            Gradient = user.Gradient;
            BackgroundPicture = user.BackgroundPicture;
            FutureJob = user.FutureJob;
        }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<UsersPicture> UserPictures { get; set; }
        public string Year { get; set; }
        public string MainPicture { get; set; }
        public string Gradient { get; set; }
        public string BackgroundPicture { get; set; }
        public string FutureJob { get; set; }

    }
}
