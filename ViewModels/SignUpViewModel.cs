using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Trululu.web.ViewModels
{
    public class SignUpViewModel 
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string FisrtName { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        [StringLength(100, ErrorMessage = "Trop long")]
        public string Mail { get; set; }
        [Required]
        public string Phone { get; set;  }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
