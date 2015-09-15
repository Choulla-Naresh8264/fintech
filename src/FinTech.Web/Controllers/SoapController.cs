using Microsoft.AspNet.Mvc;

namespace FinTech.Web.Controllers
{
    [Route("api/soap")]
    public class SoapController : Controller
    {
        [HttpGet("")]
        public IActionResult Soap()
        {
            var service = new WcfWrapper.ServiceReference1.Service1Client();
            var d1 = service.GetData(1);

            return new JsonResult(d1);
        }
    }
}
