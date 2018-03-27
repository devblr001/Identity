using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace AdminUI_Identity.Models
{
    public enum Continents
    {
        None, Africa, Asia, Australia, Europe, America
    }

    public enum ExperienceLevels
    {
        None, Novice, Intermediate, Advanced, Expert, Master
    }

    public class User : IdentityUser
    {
        public Continents Continent { get; set; }
        public ExperienceLevels ExperienceLevel { get; set; }
    }
}
