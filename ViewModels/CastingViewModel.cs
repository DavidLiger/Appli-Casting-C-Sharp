using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Trululu.web.ViewModels
{
    public class CastingViewModel
    {
        [Required]
        public string Libelle { get; set; }
        [Required]
        public int AgeMin { get; set; }
        [Required]
        public int AgeMax { get; set; }
        [Required]
        public String DescriptionPoste { get; set; }
        [Required]
        public string DescriptionProfil { get; set; }
    }
}
