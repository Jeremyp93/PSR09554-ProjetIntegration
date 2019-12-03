using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PSR09554.API.Models
{
    public class ReservationNewModel
    {
        [Required]
        public Guid idCours { get; set; }

        [Required]
        public string cheval { get; set; }
    }
}