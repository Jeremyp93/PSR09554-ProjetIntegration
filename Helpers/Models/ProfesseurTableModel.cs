using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpers.Models
{
    public class ProfesseurTableModel
    {
        public Guid id { get; set; }

        public string prenom { get; set; }

        public string nom { get; set; }

        public string typeCours { get; set; }

        public string discipline { get; set; }

        public string niveau { get; set; }
    }
}
