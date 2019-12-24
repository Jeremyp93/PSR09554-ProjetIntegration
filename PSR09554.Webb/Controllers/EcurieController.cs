using System;
using System.Collections.Generic;
using System.IO;
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

namespace PSR09554.Webb.Controllers
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
            return new JsonResult { Data = events, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
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

        [HttpGet]
        public ActionResult Professeurs()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Chevaux()
        {
            return View();
        }

        [HttpGet]
        [Authorize(Roles = "Admin")]
        public async Task<ActionResult> AjouterProfesseur()
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

        [HttpPost]
        public ActionResult UploadFiles(string id)
        {
            // Checking no of files injected in Request object  
            if (Request.Files.Count > 0 && Request.Files[0].FileName.EndsWith(".jpg"))
            {
                try
                {
                    //  Get all files from Request object  
                    HttpFileCollectionBase files = Request.Files;
                    string fname = String.Empty;
                    for (int i = 0; i < files.Count; i++)
                    {
                        //string path = AppDomain.CurrentDomain.BaseDirectory + "Uploads/";  
                        //string filename = Path.GetFileName(Request.Files[i].FileName);  

                        HttpPostedFileBase file = files[i];
                        string fullname = String.Empty;

                        // Checking for Internet Explorer  
                        //if (Request.Browser.Browser.ToUpper() == "IE" || Request.Browser.Browser.ToUpper() == "INTERNETEXPLORER")
                        //{
                        //    string[] testfiles = file.FileName.Split(new char[] { '\\' });
                        //    fname = testfiles[testfiles.Length - 1];
                        //}
                        //else
                        //{
                        //    fname = file.FileName;
                        //}

                        fname = id + ".jpg";
                        // Get the complete folder path and store the file inside it.  
                        fullname = Path.Combine(Server.MapPath("~/Images/Professeurs/"), fname);
                        file.SaveAs(fullname);
                    }
                    // Returns message that successfully uploaded  
                    return Json(fname);
                }
                catch (Exception ex)
                {
                    return Json("Error occurred. Error details: " + ex.Message);
                }
            }
            else
            {
                return Json("No files selected.");
            }
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult> GetReservationUser()
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