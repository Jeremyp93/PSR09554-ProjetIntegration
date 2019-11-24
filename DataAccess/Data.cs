using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class Data
    {
        public static List<Cour> getAllCours()
        {
            using (ExamenProjetIntegrationEntities db = new ExamenProjetIntegrationEntities())
            {
                var lstToReturn = db.Cours.ToList();
                return lstToReturn;
            }
        }

        public static List<GetAllCours_Result> getAllCoursEvent()
        {
            using (ExamenProjetIntegrationEntities db = new ExamenProjetIntegrationEntities())
            {
                var lstToReturn = db.GetAllCours().ToList();
                return lstToReturn;
            }
        }

        public static List<GetFiltre_Result> getFiltre(string typecours, string typediscipline, string niveau, DateTime date)
        {
            using (ExamenProjetIntegrationEntities db = new ExamenProjetIntegrationEntities())
            {
                var lstToReturn = db.GetFiltre(typecours, typediscipline, niveau, date).ToList();
                return lstToReturn;
            }
        }

        public static List<GetFiltreDetail_Result> GetFiltreDetail(Guid id)
        {
            using (ExamenProjetIntegrationEntities db = new ExamenProjetIntegrationEntities())
            {
                var lstToReturn = db.GetFiltreDetail(id).ToList();
                return lstToReturn;
            }
        }
    }
}
