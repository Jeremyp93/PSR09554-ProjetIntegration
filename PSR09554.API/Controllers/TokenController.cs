using System.Net;
using System.Web.Http;

namespace PSR09554.API.Controllers
{
    public class TokenController : ApiController
    {
        [Authorize]
        [HttpGet]
        [Route("v1/token/VerifyToken")]
        public IHttpActionResult VerifyToken()
        {
            return Json(HttpStatusCode.Accepted);
        }
    }
}
