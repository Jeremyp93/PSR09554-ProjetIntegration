﻿using System;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Transactions;
using System.Web.Http;
using BusinessLayer;
using PSR09554.API.Models;
using PSR09554.Hash;

namespace PSR09554.API.Controllers
{
    public class EcurieController : ApiController
    {
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("v1/ecurie/Cours")]
        public IHttpActionResult GetEvents()
        {
            var events = BL.getAllCoursEvent();
            return Json(events);
        }

        [System.Web.Http.Authorize]
        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("v1/ecurie/CoursFiltre")]
        public IHttpActionResult GetCoursFiltre([FromBody] FiltreModel filtre)
        {
            var identity = (ClaimsIdentity)User.Identity;
            var UserName = identity.Name;
            var events = BL.getAllCoursFiltre(filtre.typeCours, filtre.typediscipline, filtre.niveau, filtre.date, UserName);
            return Json(events);
        }

        [System.Web.Http.Authorize]
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("v1/ecurie/CoursFiltreDetail")]
        public IHttpActionResult GetCoursFiltreDetail([FromUri] string id)
        {
            Guid idCours;
            if (Guid.TryParse(id, out idCours))
            {
                var events = BL.getAllCoursFiltreDetail(idCours);
                return Json(events);
            }
            return NotFound();
        }

        [System.Web.Http.Authorize]
        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("v1/ecurie/ChevauxFiltre")]
        public IHttpActionResult GetChevauxFiltre([FromUri] string id, [FromBody] FiltreModel filtre)
        {
            Guid idCours;
            if (Guid.TryParse(id, out idCours))
            {
                var events = BL.getChevauxFiltre(filtre.typeCours, filtre.typediscipline, filtre.niveau, idCours);
                return Json(events);
            }
            return NotFound();
        }

        [System.Web.Http.Authorize]
        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("v1/ecurie/AjouterReservation")]
        public IHttpActionResult AddReservation([FromBody] ReservationNewModel reservation)
        {
            using (var txscope = new TransactionScope(TransactionScopeOption.RequiresNew))
            {
                try
                {
                    var identity = (ClaimsIdentity)User.Identity;
                    string id = identity.Claims
                        .FirstOrDefault(c => c.Type == "id").Value;
                    Guid idUser;
                    if (Guid.TryParse(id, out idUser))
                    {
                        Guid idCheval = BL.getIdCheval(reservation.cheval);
                        BL.addReservation(idUser, reservation.idCours, idCheval);
                        BL.updateCoursParticipant(reservation.idCours);
                        txscope.Complete();
                        return Content(HttpStatusCode.Created, "Created");
                    }
                    return NotFound();
                }
                catch
                {
                    txscope.Dispose();
                    return BadRequest();
                }
            }
        }

        [System.Web.Http.Authorize(Roles = "Admin")]
        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("v1/ecurie/RechercheProfesseur")]
        public IHttpActionResult RechercheProfesseur([FromBody] FiltreModel filtre)
        {
            var professeur = BL.getProfesseurFiltre(filtre.typeCours, filtre.niveau);
            return Json(professeur);
        }

        [System.Web.Http.Authorize(Roles = "Admin")]
        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("v1/ecurie/AjouterCours")]
        public IHttpActionResult AddCours([FromBody] CoursNewModel cours)
        {
            string message = string.Empty;
            using (var txscope = new TransactionScope(TransactionScopeOption.RequiresNew))
            {
                try
                {
                    DateTime jour = cours.dateDebut;
                    while (jour <= cours.dateFin)
                    {
                        for (int i = 0; i < cours.jourSemaine.Count(); i++)
                        {
                            if (jour.DayOfWeek.ToString() == cours.jourSemaine[i])
                            {
                                var debut = jour.Date.Add(cours.heureDebut.TimeOfDay);
                                var fin = jour.Date.Add(cours.heureDebut.AddHours(1).TimeOfDay);
                                if (!BL.getAllCoursEvent().Where(x => x.coursDebut == debut).Any())
                                {
                                    BL.addCours(debut, fin, cours.typeCours, cours.discipline, cours.niveau, cours.idProfesseur);
                                }
                                else
                                {
                                    message = message + "Les cours pour les dates suivantes n'ont pas pu être ajouté : " + jour.Date + " - ";
                                }
                            }
                        }

                        jour = jour.AddDays(1);
                    }
                    txscope.Complete();
                    if (string.IsNullOrEmpty(message))
                        message = "Les cours ont été ajoutés";
                    return Content(HttpStatusCode.Created, message);
                }
                catch
                {
                    txscope.Dispose();
                    return BadRequest();
                }
            }
        }

        [System.Web.Http.Authorize(Roles = "Admin")]
        [System.Web.Http.HttpDelete]
        [System.Web.Http.Route("v1/ecurie/DeleteCours")]
        public IHttpActionResult DeleteCours([FromUri] string id)
        {
            try
            {
                Guid idCours;
                if (Guid.TryParse(id, out idCours))
                {
                    BL.deleteCours(idCours);
                    return Content(HttpStatusCode.OK, "Deleted");
                }
                return NotFound();
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.BadRequest, e.Message);
            }
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("v1/ecurie/Professeurs")]
        public IHttpActionResult ProfesseurTable()
        {
            var professeur = BL.getProfesseurTable();
            return Json(professeur);
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("v1/ecurie/Chevaux")]
        public IHttpActionResult ChevauxTable()
        {
            var chevaux = BL.getChevauxTable();
            return Json(chevaux);
        }

        [System.Web.Http.Authorize(Roles = "Admin")]
        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("v1/ecurie/AjouterProfesseur")]
        public IHttpActionResult AjouterProfesseur([FromBody] ProfesseurNewModel professeur)
        {
            string message = string.Empty;
            using (var txscope = new TransactionScope(TransactionScopeOption.RequiresNew))
            {
                try
                {
                    if (ModelState.IsValid)
                    {
                        var idProfesseur = BL.addProfesseur(professeur.prenom, professeur.nom);
                        BL.addUtilisateur(professeur.prenom.ToLower()+"@scotex.be", MyHash.HashPassword(professeur.prenom.ToLower()), professeur.prenom, professeur.nom);
                        if (professeur.discipline.Length != 0)
                        {
                            foreach (var discipline in professeur.discipline)
                            {
                                foreach (var niveau in professeur.niveau)
                                {
                                    BL.addProfesseurCours(idProfesseur, professeur.typeCours, discipline, niveau);
                                }
                            }
                        }
                        else
                        {
                            foreach (var niveau in professeur.niveau)
                            {
                                BL.addProfesseurCours(idProfesseur, professeur.typeCours, null, niveau);
                            }
                        }
                        txscope.Complete();
                        message = "Le professeur " + professeur.prenom + " " + professeur.nom + " a été ajouté !";
                        return Content(HttpStatusCode.Created, idProfesseur);
                    }
                    else
                    {
                        return BadRequest("Veuillez remplir tous les champs !");
                    }
                }
                catch
                {
                    txscope.Dispose();
                    return BadRequest("L'ajout n'a pas reussi !");
                }
            }
        }

        [System.Web.Http.Authorize(Roles = "Client")]
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("v1/ecurie/MesReservations")]
        public IHttpActionResult GetReservationUser()
        {
            var identity = (ClaimsIdentity)User.Identity;
            string id = identity.Claims
                .FirstOrDefault(c => c.Type == "id").Value;
            var reservation = BL.getReservationUser(id);
            return Json(reservation);
        }

        [System.Web.Http.Authorize(Roles = "Client")]
        [System.Web.Http.HttpDelete]
        [System.Web.Http.Route("v1/ecurie/DeleteReservation")]
        public IHttpActionResult DeleteReservation([FromUri] string id)
        {
            try
            {
                Guid idRes;
                if (Guid.TryParse(id, out idRes))
                {
                    BL.deleteReservation(idRes);
                    return Content(HttpStatusCode.OK, "Deleted");
                }
                return NotFound();
            }
            catch (Exception e)
            {
                return Content(HttpStatusCode.BadRequest, e.Message);
            }
        }

        [System.Web.Http.HttpGet]
        [System.Web.Http.Authorize(Roles = "Professeur")]
        [System.Web.Http.Route("v1/ecurie/CoursProfesseurs")]
        public IHttpActionResult GetEventsProfesseur()
        {
            var identity = (ClaimsIdentity)User.Identity;
            var prenom = identity.
                FindFirst("prenom").Value;
            var nom = identity.
                FindFirst("nom").Value;
            var events = BL.getAllCoursEvent().Where(x => x.professeur == prenom+" "+nom).ToList();
            for (int i = 0; i < events.Count(); i++)
            {
                var nomComplet = string.Empty;
                var participant = BL.getParticipantsCours(events[i].id);
                foreach (var y in participant)
                {
                    nomComplet = nomComplet + y.prenom + " " + y.nom + ";";
                }

                events[i].professeur = nomComplet;
            }
            return Json(events);
        }
    }
}
