using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Mvc;
using BusinessLayer;
using PSR09554.API.Models;

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

        [System.Web.Http.HttpPost]
        [System.Web.Http.Route("v1/ecurie/CoursFiltre")]
        public IHttpActionResult GetCoursFiltre([FromBody] FiltreModel filtre)
        {
            var events = BL.getAllCoursFiltre(filtre.typeCours, filtre.typediscipline, filtre.niveau, filtre.date);
            return Json(events);
        }

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
    }
}
