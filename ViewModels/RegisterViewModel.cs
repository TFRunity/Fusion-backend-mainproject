using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fusion.ViewModels
{
    public class RegisterViewModel
    {
        public string Name { get; set; }
        public string Email { get; set; }

        public string Year { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Compare("Password")]
        [DataType(DataType.Password)]
        public string PasswordConfirm { get; set; }
        public string FutureJob { get; set; }
    }
}
