using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Trululu.web.ViewModels;

namespace Trululu.web.Entities
{
    public class Casting
    {
        public int Id { get; set; }
        public string Wording { get; set; }
        public int AgeMin { get; set; }
        public int AgeMax { get; set; }
        public string DescriptionPost { get; set; }
        public string DescriptionProfile { get; set; }
        public int CreatorId { get; set; }

        public Casting NewFromForm(CastingViewModel viewModel)
        {
            this.Wording = viewModel.Libelle;
            this.AgeMin = viewModel.AgeMin;
            this.AgeMax = viewModel.AgeMax;
            this.DescriptionPost = viewModel.DescriptionPoste;
            this.DescriptionProfile = viewModel.DescriptionProfil;

            return this;
        }
    }
}
