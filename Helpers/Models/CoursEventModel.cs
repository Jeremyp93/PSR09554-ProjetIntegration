using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Helpers.Models
{
    public class CoursEventModel
    {
        [Display(Name = "Date")]
        [Required]
        public string titre { get; set; }

        [Display(Name = "Description")]
        [Required]
        public string description { get; set; }

        [Display(Name = "Professeur")]
        [Required]
        public string professeur { get; set; }

        [Display(Name = "Debut")]
        [Required]
        public DateTime coursDebut { get; set; }

        [Display(Name = "Debut")]
        [Required]
        public DateTime coursFin { get; set; }

        [Display(Name = "Nombre de places max")]
        [Required]
        public int nombreMax { get; set; }

        [Required]
        public string couleur { get; set; }
    }
}
