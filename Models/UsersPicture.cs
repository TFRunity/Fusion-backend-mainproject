using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Fusion.Models
{
    public class UsersPicture
    {
        public Guid Id { get; set; }
        public string URL { get; set; }
        public Guid UserId { get; set; }
        public virtual User User { get; set; }
    }
}
