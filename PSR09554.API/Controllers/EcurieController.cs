using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Transactions;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Security;
using BusinessLayer;
using PSR09554.API.Models;
using Microsoft.AspNet.Identity;

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
    }
}
