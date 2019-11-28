using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using BusinessLayer;
using Newtonsoft.Json;

namespace PSR09554.Controllers
{
    public class EcurieController : Controller
    {
        // GET: Ecurie
        public ActionResult Horaires()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetCours()
        {
            var events = BL.getAllCoursEvent();
            return new JsonResult{Data = events, JsonRequestBehavior = JsonRequestBehavior.AllowGet};
        }

        [Authorize]
        public ActionResult Reservation()
        {
            return View();
        }
    }
}