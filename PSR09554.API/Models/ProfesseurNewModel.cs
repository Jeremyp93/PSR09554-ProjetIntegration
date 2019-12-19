using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PSR09554.API.Models
{
    public class ProfesseurNewModel
    {
        [Required]
        public string prenom { get; set; }
        [Required]
        public string nom { get; set; }
        [Required]
        public string typeCours { get; set; }
        [Required]
        public string[] discipline { get; set; }
        [Required]
        public string[] niveau { get; set; }
    }
}