using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fusion.ViewModels
{
    public class AddPictureViewModel
    {
        [Required]
        public string Url { get; set; }
        [Required]
        public string Email { get; set; }
    }
}
