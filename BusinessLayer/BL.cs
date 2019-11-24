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
        public static List<CoursModel> getAllCours()
        {
            try
            {
                var lstToReturn = new List<CoursModel>();
                foreach (var cours in Data.getAllCours())
                {
                    lstToReturn.Add(new CoursModel
                    {
                        id = cours.COURS_id,
                        heureDebut = cours.COURS_debut,
                        heureFin = cours.COURS_fin,
                        nombreMax = cours.COURS_NombreDePlaces,
                        typeDeCours = cours.TYPECOURS_id,
                        niveau = cours.NIVEAU_id,
                        professeur = cours.PROFESSEUR_id
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

        public static List<CoursEventModel> getAllCoursEvent()
        {
            try
            {
                var lstToReturn = new List<CoursEventModel>();
                foreach (var events in Data.getAllCoursEvent())
                {
                    lstToReturn.Add(new CoursEventModel
                    {
                        titre = events.Titre,
                        description = events.Description,
                        coursDebut = events.COURS_debut,
                        coursFin = events.COURS_fin,
                        nombreMax = events.COURS_NombreDePlaces,
                        couleur = events.NIVEAU_couleur,
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

        public static List<CoursFiltreModel> getAllCoursFiltre(string typecours, string typediscipline, string niveau, DateTime date)
        {
            try
            {
                var lstToReturn = new List<CoursFiltreModel>();
                foreach (var filtre in Data.getFiltre(typecours, typediscipline, niveau, date))
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
    }
}
