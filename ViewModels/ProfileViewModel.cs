using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Trululu.web.Entities;

namespace Trululu.web.ViewModels
{
    public class ProfileViewModel
    {
        [Required]
        public User user { get; set; }

        [Required]
        public IEnumerable<Casting> castings { get; set; }
    }
}
