using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpers.Models
{
    public class ParticpantsCoursModel
    {
        public string idUser { get; set; }

        public string username { get; set; }

        public string prenom { get; set; }

        public string nom { get; set; }

        public Guid idCours { get; set; }

        public Guid idReservation { get; set; }
    }
}
