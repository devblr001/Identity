using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using AdminUI_Identity.Models;

namespace AdminUI_Identity.ViewModels
{
    public class SetCustomPropsVm
    {
        [Required]
        public Continents Continent { get; set; }

        [Required]
        public ExperienceLevels ExperienceLevel { get; set; }
    }
}
