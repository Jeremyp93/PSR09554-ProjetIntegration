using System;
using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
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

        public static List<GetFiltre_Result> getFiltre(string typecours, string typediscipline, string niveau, DateTime date, string username)
        {
            using (ExamenProjetIntegrationEntities db = new ExamenProjetIntegrationEntities())
            {
                var lstToReturn = db.GetFiltre(typecours, typediscipline, niveau, date, username).ToList();
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
        public static List<GetChevauxFiltre_Result> GetChevauxFiltre(string typecours, string typediscipline, string niveau, Guid id)
        {
            using (ExamenProjetIntegrationEntities db = new ExamenProjetIntegrationEntities())
            {
                var lstToReturn = db.GetChevauxFiltre(typecours, typediscipline, niveau, id).ToList();
                return lstToReturn;
            }
        }

        public static void AddReservation(Guid idUser, Guid idCours, Guid idCheval)
        {
            using (ExamenProjetIntegrationEntities db = new ExamenProjetIntegrationEntities())
            {
                db.AddReservation(idUser, idCours, idCheval);
            }
        }

        public static void UpdateCoursParticipant(Guid idCours)
        {
            using (ExamenProjetIntegrationEntities db = new ExamenProjetIntegrationEntities())
            {
                db.UpdateCoursParticipant(idCours);
            }
        }

        public static Guid GetIdCheval(string nom)
        {
            using (ExamenProjetIntegrationEntities db = new ExamenProjetIntegrationEntities())
            {
                var guidToReturn = db.Chevals.FirstOrDefault(x => x.CHEVAL_nom == nom).CHEVAL_id;
                return guidToReturn;
            }
        }

        public static List<GetUser_Result> GetUserAPI(string username)
        {
            using (ExamenProjetIntegrationEntities db = new ExamenProjetIntegrationEntities())
            {
                var lstToReturn = db.GetUser(username).ToList();
                return lstToReturn;
            }
        }

        public static List<GetProfesseur_Result> GetProfesseurFiltre(string typecours, string niveau)
        {
            using (ExamenProjetIntegrationEntities db = new ExamenProjetIntegrationEntities())
            {
                var lstToReturn = db.GetProfesseur(typecours,niveau).ToList();
                return lstToReturn;
            }
        }

        public static void AddCours(DateTime coursDebut, DateTime coursFin, string typeCours, string discipline, string niveau, Guid idProfesseur)
        {
            using (ExamenProjetIntegrationEntities db = new ExamenProjetIntegrationEntities())
            {
                db.AddCours(coursDebut, coursFin, typeCours, discipline, niveau, idProfesseur);
            }
        }
        public static void DeleteCours(Guid idCours)
        {
            using (ExamenProjetIntegrationEntities db = new ExamenProjetIntegrationEntities())
            {
                db.DeleteCours(idCours);
            }
        }

        public static List<GetProfesseurTable_Result> GetProfesseurTable()
        {
            using (ExamenProjetIntegrationEntities db = new ExamenProjetIntegrationEntities())
            {
                var lstToReturn = db.GetProfesseurTable().ToList();
                return lstToReturn;
            }
        }

        public static List<GetChevauxTable_Result> GetChevauxTable()
        {
            using (ExamenProjetIntegrationEntities db = new ExamenProjetIntegrationEntities())
            {
                var lstToReturn = db.GetChevauxTable().ToList();
                return lstToReturn;
            }
        }

        public static Guid AddProfesseur(string prenom, string nom)
        {
            using (ExamenProjetIntegrationEntities db = new ExamenProjetIntegrationEntities())
            {
                ObjectParameter objParam = new ObjectParameter("identity", typeof(Guid));
                var resultToReturn = db.AjouterProfesseur(prenom, nom, objParam).Count();
                return  Guid.Parse(objParam.Value.ToString());
            }
        }

        public static void AddProfesseurCours(Guid idProfesseur, string typeCours, string discipline, string niveau)
        {
            using (ExamenProjetIntegrationEntities db = new ExamenProjetIntegrationEntities())
            {
                db.AjouterProfesseurCours(idProfesseur, typeCours, discipline, niveau);
            }
        }

        public static List<GetReservationUser_Result> GetReservationUser(string id)
        {
            using (ExamenProjetIntegrationEntities db = new ExamenProjetIntegrationEntities())
            {
                var lstToReturn = db.GetReservationUser(id).OrderByDescending(x => x.COURS_debut).ToList();
                return lstToReturn;
            }
        }

        public static void DeleteReservation(Guid idReservation)
        {
            using (ExamenProjetIntegrationEntities db = new ExamenProjetIntegrationEntities())
            {
                db.DeleteReservation(idReservation);
            }
        }
    }
}
