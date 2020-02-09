using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Helpers.Models;
using DataAccess;

namespace BusinessLayer
{
    public class BL
    {
        public static List<CoursEventModel> getAllCoursEvent()
        {
            try
            {
                var lstToReturn = new List<CoursEventModel>();
                foreach (var events in Data.getAllCoursEvent())
                {
                    lstToReturn.Add(new CoursEventModel
                    {
                        id = events.COURS_id,
                        titre = events.Titre,
                        description = events.Description,
                        coursDebut = events.COURS_debut,
                        coursFin = events.COURS_fin,
                        nombreMax = events.COURS_NombreDePlaces,
                        couleur = events.NIVEAU_Couleur,
                        professeur = events.Professeur
                    });
                }

                return lstToReturn;
            }
            catch (Exception e)
            {
                var sqlex = e.InnerException as SqlException;

                if (sqlex != null)
                {
                    switch (sqlex.Number)
                    {
                        default:
                            throw new Exception(sqlex.Number + " - " + sqlex.Message);
                    }
                }

                throw e;
            }
        }

        public static List<CoursFiltreModel> getAllCoursFiltre(string typecours, string typediscipline, string niveau,
            DateTime date, string username)
        {
            try
            {
                var lstToReturn = new List<CoursFiltreModel>();
                foreach (var filtre in Data.getFiltre(typecours, typediscipline, niveau, date, username))
                {
                    lstToReturn.Add(new CoursFiltreModel
                    {
                        id = filtre.COURS_id,
                        cours_debut = filtre.COURS_debut,
                        cours_fin = filtre.COURS_fin,
                        cours_nombreDePlaces = filtre.COURS_NombreDePlaces,
                        cours = filtre.cours,
                        niveau = filtre.NIVEAU_libelle,
                        professeur_prenom = filtre.PROFESSEUR_prenom,
                        professeur_nom = filtre.PROFESSEUR_nom
                    });
                }

                return lstToReturn;
            }
            catch (Exception e)
            {
                var sqlex = e.InnerException as SqlException;

                if (sqlex != null)
                {
                    switch (sqlex.Number)
                    {
                        default:
                            throw new Exception(sqlex.Number + " - " + sqlex.Message);
                    }
                }

                throw e;
            }
        }

        public static List<CoursFiltreDetailModel> getAllCoursFiltreDetail(Guid id)
        {
            try
            {
                var lstToReturn = new List<CoursFiltreDetailModel>();
                foreach (var detail in Data.GetFiltreDetail(id))
                {
                    lstToReturn.Add(new CoursFiltreDetailModel
                    {
                        coursDebut = detail.COURS_debut,
                        coursFin = detail.COURS_fin,
                        nombrePlaces = detail.COURS_NombreDePlaces,
                        professeurPrenom = detail.PROFESSEUR_prenom,
                        professeurNom = detail.PROFESSEUR_nom
                    });
                }

                return lstToReturn;
            }
            catch (Exception e)
            {
                var sqlex = e.InnerException as SqlException;

                if (sqlex != null)
                {
                    switch (sqlex.Number)
                    {
                        default:
                            throw new Exception(sqlex.Number + " - " + sqlex.Message);
                    }
                }

                throw e;
            }
        }

        public static List<ChevauxFiltreModel> getChevauxFiltre(string typecours, string typediscipline, string niveau,
            Guid id)
        {
            try
            {
                var lstToReturn = new List<ChevauxFiltreModel>();
                foreach (var cheval in Data.GetChevauxFiltre(typecours, typediscipline, niveau, id))
                {
                    lstToReturn.Add(new ChevauxFiltreModel
                    {
                        id = cheval.CHEVAL_id,
                        nom = cheval.CHEVAL_nom
                    });
                }

                return lstToReturn;
            }
            catch (Exception e)
            {
                var sqlex = e.InnerException as SqlException;

                if (sqlex != null)
                {
                    switch (sqlex.Number)
                    {
                        default:
                            throw new Exception(sqlex.Number + " - " + sqlex.Message);
                    }
                }

                throw e;
            }
        }

        public static void addReservation(Guid idUser, Guid idCours, Guid idCheval)
        {
            try
            {
                Data.AddReservation(idUser, idCours, idCheval);
            }
            catch (Exception e)
            {
                var sqlex = e.InnerException as SqlException;

                if (sqlex != null)
                {
                    switch (sqlex.Number)
                    {
                        default:
                            throw new Exception(sqlex.Number + " - " + sqlex.Message);
                    }
                }

                throw e;
            }
        }

        public static void updateCoursParticipant(Guid idCours)
        {
            try
            {
                Data.UpdateCoursParticipant(idCours);
            }
            catch (Exception e)
            {
                var sqlex = e.InnerException as SqlException;

                if (sqlex != null)
                {
                    switch (sqlex.Number)
                    {
                        default:
                            throw new Exception(sqlex.Number + " - " + sqlex.Message);
                    }
                }

                throw e;
            }
        }

        public static Guid getIdCheval(string nom)
        {
            try
            {
                var guidToReturn = Data.GetIdCheval(nom);
                return guidToReturn;
            }
            catch (Exception e)
            {
                var sqlex = e.InnerException as SqlException;

                if (sqlex != null)
                {
                    switch (sqlex.Number)
                    {
                        default:
                            throw new Exception(sqlex.Number + " - " + sqlex.Message);
                    }
                }

                throw e;
            }
        }

        public static List<AuthenticationModel> getUserAPI(string username)
        {
            try
            {
                var lstToReturn = new List<AuthenticationModel>();
                foreach (var user in Data.GetUserAPI(username))
                {
                    lstToReturn.Add(new AuthenticationModel
                    {
                        id = user.Id,
                        username = user.UserName,
                        hash = user.PasswordHash,
                        role = user.Name,
                        prenom = user.Prenom,
                        nom = user.Nom
                    });
                }

                return lstToReturn;
            }
            catch (Exception e)
            {
                var sqlex = e.InnerException as SqlException;

                if (sqlex != null)
                {
                    switch (sqlex.Number)
                    {
                        default:
                            throw new Exception(sqlex.Number + " - " + sqlex.Message);
                    }
                }

                throw e;
            }
        }

        public static List<ProfesseurFiltreModel> getProfesseurFiltre(string typecours, string niveau)
        {
            try
            {
                var lstToReturn = new List<ProfesseurFiltreModel>();
                foreach (var professeur in Data.GetProfesseurFiltre(typecours, niveau))
                {
                    lstToReturn.Add(new ProfesseurFiltreModel
                    {
                        id = professeur.PROFESSEUR_id,
                        prenom = professeur.PROFESSEUR_prenom,
                        nom = professeur.PROFESSEUR_nom
                    });
                }

                return lstToReturn;
            }
            catch (Exception e)
            {
                var sqlex = e.InnerException as SqlException;

                if (sqlex != null)
                {
                    switch (sqlex.Number)
                    {
                        default:
                            throw new Exception(sqlex.Number + " - " + sqlex.Message);
                    }
                }

                throw e;
            }
        }

        public static void addCours(DateTime coursDebut, DateTime coursFin, string typeCours, string discipline, string niveau, Guid idProfesseur)
        {
            try
            {
                Data.AddCours(coursDebut, coursFin, typeCours, discipline, niveau, idProfesseur);
            }
            catch (Exception e)
            {
                var sqlex = e.InnerException as SqlException;

                if (sqlex != null)
                {
                    switch (sqlex.Number)
                    {
                        default:
                            throw new Exception(sqlex.Number + " - " + sqlex.Message);
                    }
                }

                throw e;
            }
        }

        public static void deleteCours(Guid idCours)
        {
            try
            {
                Data.DeleteCours(idCours);
            }
            catch (Exception e)
            {
                var sqlex = e.InnerException as SqlException;

                if (sqlex != null)
                {
                    switch (sqlex.Number)
                    {
                        default:
                            throw new Exception(sqlex.Number + " - " + sqlex.Message);
                    }
                }

                throw e;
            }
        }

        public static List<ProfesseurTableModel> getProfesseurTable()
        {
            try
            {
                var lstToReturn = new List<ProfesseurTableModel>();
                foreach (var professeur in Data.GetProfesseurTable())
                {
                    if (lstToReturn.FirstOrDefault(x => x.id == professeur.PROFESSEUR_id) == null)
                    {
                        var newProf = new ProfesseurTableModel();
                        newProf.id = professeur.PROFESSEUR_id;
                        newProf.prenom = professeur.PROFESSEUR_prenom;
                        newProf.nom = professeur.PROFESSEUR_nom;
                        newProf.typeCours = professeur.TYPECOURS_libelle;
                        if (newProf.typeCours != "Randonnee")
                            newProf.discipline = professeur.TYPECOURS_discipline;
                        newProf.niveau = professeur.NIVEAU_libelle;
                        foreach (var prof in Data.GetProfesseurTable().Where(x => x.PROFESSEUR_id == newProf.id))
                        {
                            if (!newProf.typeCours.Contains(prof.TYPECOURS_libelle))
                                newProf.typeCours = newProf.typeCours + ", " + prof.TYPECOURS_libelle;
                            if (newProf.typeCours != "Randonnee")
                            {
                                if (!newProf.discipline.Contains(prof.TYPECOURS_discipline))
                                    newProf.discipline = newProf.discipline + ", " + prof.TYPECOURS_discipline;
                            }
                            if (!newProf.niveau.Contains(prof.NIVEAU_libelle))
                                newProf.niveau = newProf.niveau + ", " + prof.NIVEAU_libelle;
                        }
                        lstToReturn.Add(newProf);
                    }
                }

                return lstToReturn;
            }
            catch (Exception e)
            {
                var sqlex = e.InnerException as SqlException;

                if (sqlex != null)
                {
                    switch (sqlex.Number)
                    {
                        default:
                            throw new Exception(sqlex.Number + " - " + sqlex.Message);
                    }
                }

                throw e;
            }
        }

        public static List<ChevauxTableModel> getChevauxTable()
        {
            try
            {
                var lstToReturn = new List<ChevauxTableModel>();
                foreach (var cheval in Data.GetChevauxTable())
                {
                    if (lstToReturn.FirstOrDefault(x => x.id == cheval.CHEVAL_id) == null)
                    {
                        var newCheval = new ChevauxTableModel();
                        newCheval.id = cheval.CHEVAL_id;
                        newCheval.nom = cheval.CHEVAL_nom;
                        newCheval.typeCours = cheval.TYPECOURS_libelle;
                        newCheval.discipline = cheval.TYPECOURS_discipline;
                        newCheval.niveau = cheval.NIVEAU_libelle;
                        foreach (var chev in Data.GetChevauxTable().Where(x => x.CHEVAL_id == newCheval.id))
                        {
                            if (!newCheval.typeCours.Contains(chev.TYPECOURS_libelle))
                                newCheval.typeCours = newCheval.typeCours + ", " + chev.TYPECOURS_libelle;
                            if (!newCheval.discipline.Contains(chev.TYPECOURS_discipline))
                                newCheval.discipline = newCheval.discipline + ", " + chev.TYPECOURS_discipline;
                            if (!newCheval.niveau.Contains(chev.NIVEAU_libelle))
                                newCheval.niveau = newCheval.niveau + ", " + chev.NIVEAU_libelle;
                        }
                        lstToReturn.Add(newCheval);
                    }
                }

                return lstToReturn;
            }
            catch (Exception e)
            {
                var sqlex = e.InnerException as SqlException;

                if (sqlex != null)
                {
                    switch (sqlex.Number)
                    {
                        default:
                            throw new Exception(sqlex.Number + " - " + sqlex.Message);
                    }
                }

                throw e;
            }
        }

        public static Guid addProfesseur(string prenom, string nom)
        {
            try
            {
                var data = Data.AddProfesseur(prenom, nom);
                return data;
            }
            catch (Exception e)
            {
                var sqlex = e.InnerException as SqlException;

                if (sqlex != null)
                {
                    switch (sqlex.Number)
                    {
                        default:
                            throw new Exception(sqlex.Number + " - " + sqlex.Message);
                    }
                }

                throw e;
            }
        }

        public static void addProfesseurCours(Guid idProfesseur, string typeCours, string discipline, string niveau)
        {
            try
            {
                Data.AddProfesseurCours(idProfesseur, typeCours, discipline, niveau);
            }
            catch (Exception e)
            {
                var sqlex = e.InnerException as SqlException;

                if (sqlex != null)
                {
                    switch (sqlex.Number)
                    {
                        default:
                            throw new Exception(sqlex.Number + " - " + sqlex.Message);
                    }
                }

                throw e;
            }
        }

        public static List<ReservationUserModel> getReservationUser(string id)
        {
            try
            {
                var lstToReturn = new List<ReservationUserModel>();
                foreach (var reservation in Data.GetReservationUser(id))
                {
                    lstToReturn.Add(new ReservationUserModel
                    {
                        idReservation = reservation.RESERVATION_id,
                        heureDebut = reservation.COURS_debut,
                        heureFin = reservation.COURS_fin,
                        typeDeCours = reservation.TYPECOURS_libelle,
                        discipline = reservation.TYPECOURS_discipline,
                        niveau = reservation.NIVEAU_libelle,
                        professeur_prenom = reservation.PROFESSEUR_prenom,
                        professeur_nom = reservation.PROFESSEUR_nom
                    });
                }

                return lstToReturn;
            }
            catch (Exception e)
            {
                var sqlex = e.InnerException as SqlException;

                if (sqlex != null)
                {
                    switch (sqlex.Number)
                    {
                        default:
                            throw new Exception(sqlex.Number + " - " + sqlex.Message);
                    }
                }

                throw e;
            }
        }

        public static void deleteReservation(Guid idReservation)
        {
            try
            {
                Data.DeleteReservation(idReservation);
            }
            catch (Exception e)
            {
                var sqlex = e.InnerException as SqlException;

                if (sqlex != null)
                {
                    switch (sqlex.Number)
                    {
                        default:
                            throw new Exception(sqlex.Number + " - " + sqlex.Message);
                    }
                }

                throw e;
            }
        }

        public static List<ParticpantsCoursModel> getParticipantsCours(Guid idCours)
        {
            try
            {
                var lstToReturn = new List<ParticpantsCoursModel>();
                foreach (var participant in Data.GetParticipantsCours(idCours))
                {
                    lstToReturn.Add(new ParticpantsCoursModel
                    {
                        idUser = participant.Id,
                        username = participant.UserName,
                        prenom = participant.Prenom,
                        nom = participant.Nom,
                        idCours = participant.COURS_id,
                        idReservation = participant.RESERVATION_id
                    });
                }

                return lstToReturn;
            }
            catch (Exception e)
            {
                var sqlex = e.InnerException as SqlException;

                if (sqlex != null)
                {
                    switch (sqlex.Number)
                    {
                        default:
                            throw new Exception(sqlex.Number + " - " + sqlex.Message);
                    }
                }

                throw e;
            }
        }

        public static void addUtilisateur(string email, string passwordHash, string prenom, string nom)
        {
            try
            {
                Data.AddUtilisateur(email, passwordHash, prenom, nom);
            }
            catch (Exception e)
            {
                var sqlex = e.InnerException as SqlException;

                if (sqlex != null)
                {
                    switch (sqlex.Number)
                    {
                        default:
                            throw new Exception(sqlex.Number + " - " + sqlex.Message);
                    }
                }

                throw e;
            }
        }
    }
}