using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fusion.ViewModels
{
    public class LoginViewModel
    {
        public string Name { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool RememberMe { get; set; }

        public string ReturnUrl { get; set; }
    }
}
