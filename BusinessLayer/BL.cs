﻿using System;
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
                        role = user.Name
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
    }
}