using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpers.Models
{
    public class CoursFiltreDetailModel
    {
        public DateTime coursDebut { get; set; }

        public DateTime coursFin { get; set; }

        public int nombrePlaces { get; set; }

        public string professeurPrenom { get; set; }

        public string professeurNom { get; set; }
    }
}
