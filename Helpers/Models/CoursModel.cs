using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace Helpers.Models
{
    public class CoursModel
    {
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        [Key]
        public Guid id { get; set; }

        [Display(Name = "Heure début")]
        [Required]
        public DateTime heureDebut { get; set; }

        [Display(Name = "Heure fin")]
        [Required]
        public DateTime heureFin { get; set; }

        [Display(Name = "Nombre de places max")]
        [Required]
        public int nombreMax { get; set; }

        [Display(Name = "Type de cours")]
        [Required]
        public Guid typeDeCours { get; set; }

        [Display(Name = "Niveau")]
        [Required]
        public Guid niveau { get; set; }

        [Display(Name = "Professeur")]
        [Required]
        public Guid professeur { get; set; }
    }
}
