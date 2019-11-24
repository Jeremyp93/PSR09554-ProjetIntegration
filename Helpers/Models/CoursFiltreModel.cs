using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpers.Models
{
    public class CoursFiltreModel
    {
        public Guid id { get; set; }

        public DateTime cours_debut { get; set; }

        public DateTime cours_fin { get; set; }

        public int cours_nombreDePlaces { get; set; }

        public string cours { get; set; }

        public string niveau { get; set; }

        public string professeur_prenom { get; set; }

        public string professeur_nom { get; set; }

    }
}
