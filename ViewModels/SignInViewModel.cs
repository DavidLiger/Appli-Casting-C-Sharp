using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Trululu.web.Controllers;

namespace Trululu.web.ViewModels
{
    public class SignInViewModel
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        [StringLength(100, ErrorMessage = "Trop long")]
        public string Mail { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
