using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PSR09554.API.Models
{
    public class FiltreModel
    {
        public string typeCours { get; set; }

        public string typediscipline { get; set; }

        public string niveau { get; set; }

        public DateTime date { get; set; }
    }
}