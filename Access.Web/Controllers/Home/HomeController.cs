using Microsoft.AspNetCore.Mvc;

namespace Access.Web.Controllers.Home
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
