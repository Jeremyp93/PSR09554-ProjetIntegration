using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using BusinessLayer;
using Newtonsoft.Json;

namespace PSR09554.Controllers
{
    public class EcurieController : Controller
    {
        [HttpGet]
        // GET: Ecurie
        public async Task<ActionResult> Horaires()
        {
            if (User.IsInRole("Admin"))
            {
                if (Session["TokenNumber"] != null)
                {
                    await ValidateToken(Session["TokenNumber"].ToString());
                    if (Session["ValidToken"].ToString() == "202")
                    {
                        ViewBag.Token = Session["TokenNumber"].ToString();
                        return View();
                    }
                    else
                    {
                        return RedirectToAction("Login", "Account");
                    }
                }
                return RedirectToAction("Login", "Account");
            }
            return View();
        }

        [HttpGet]
        public JsonResult GetCours()
        {
            var events = BL.getAllCoursEvent();
            return new JsonResult{Data = events, JsonRequestBehavior = JsonRequestBehavior.AllowGet};
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult> Reservation()
        {
            if (Session["TokenNumber"] != null)
            {
                await ValidateToken(Session["TokenNumber"].ToString());
                if (Session["ValidToken"].ToString() == "202")
                {
                    ViewBag.Token = Session["TokenNumber"].ToString();
                    return View();
                }
                else
                {
                    return RedirectToAction("Login", "Account");
                }
            }
            return RedirectToAction("Login", "Account");
        }

        internal async Task<ActionResult> ValidateToken(string token)
        {
            string apiUrl = Helpers.CUtil.GetValueBaseOnKey("apiBaseUrl");
            var resultContent = String.Empty;

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(apiUrl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Authorization
                         = new AuthenticationHeaderValue("Bearer", token);
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                var result = await client.GetAsync("/v1/token/VerifyToken");
                if (result.IsSuccessStatusCode)
                {
                    resultContent = await result.Content.ReadAsStringAsync();
                    Session["ValidToken"] = resultContent;
                    return Content(resultContent);
                }
            }
            Session["ValidToken"] = "Error";
            return Content("Error");
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> AjouterCours()
        {
            if (Session["TokenNumber"] != null)
            {
                await ValidateToken(Session["TokenNumber"].ToString());
                if (Session["ValidToken"].ToString() == "202")
                {
                    ViewBag.Token = Session["TokenNumber"].ToString();
                    return View();
                }
                else
                {
                    return RedirectToAction("Login", "Account");
                }
            }
            return RedirectToAction("Login", "Account");
        }
    }
}