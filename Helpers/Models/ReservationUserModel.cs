using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Helpers.Models
{
    public class ReservationUserModel
    {
        public Guid idReservation { get; set; }

        [Required]
        public DateTime heureDebut { get; set; }

        [Required]
        public DateTime heureFin { get; set; }

        [Display(Name = "Type de cours")]
        [Required]
        public string typeDeCours { get; set; }

        [Display(Name = "Discipline")]
        public string discipline { get; set; }

        [Display(Name = "Niveau")]
        [Required]
        public string niveau { get; set; }

        [Required]
        public string professeur_prenom { get; set; }

        [Required]
        public string professeur_nom { get; set; }
    }
}
