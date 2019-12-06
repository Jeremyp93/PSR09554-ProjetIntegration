using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PSR09554.API.Models
{
    public class CoursNewModel
    {
        [DataType(DataType.Date)]
        public DateTime dateDebut { get; set; }
        [DataType(DataType.Time)]
        public DateTime heureDebut { get; set; }
        [DataType(DataType.Date)]
        public DateTime dateFin { get; set; }

        public string jourSemaine { get; set; }

        public string typeCours { get; set; }

        public string discipline { get; set; }

        public string niveau { get; set; }

        public Guid idProfesseur { get; set; }
    }
}