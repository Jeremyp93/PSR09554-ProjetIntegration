using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PSR09554.API.Models
{
    public class ProfesseurNewModel
    {
        public string prenom { get; set; }

        public string nom { get; set; }

        public string typeCours { get; set; }

        public string[] discipline { get; set; }

        public string[] niveau { get; set; }
    }
}