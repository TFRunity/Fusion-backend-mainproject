using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Fusion.Models
{
    public class User : IdentityUser<Guid>
    {
        public override string UserName { get => base.UserName; set => base.UserName = value; }
        public string Year { get; set; }
        public virtual List<UsersPicture> UsersPictures { get; set; } = new List<UsersPicture>();
        public string MainPicture { get; set; }
        public string Gradient { get; set; }
        public string BackgroundPicture { get; set; }
        public string Description { get; set; }
        public string FutureJob { get; set; }
    }
}
