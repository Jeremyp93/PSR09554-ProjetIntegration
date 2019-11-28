using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PSR09554.API.Models
{
    public class ReservationNewModel
    {
        public Guid idCours { get; set; }

        public string cheval { get; set; }
    }
}