using Microsoft.AspNet.Mvc;

namespace FinTech.Web.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet("")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
