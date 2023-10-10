using Microsoft.AspNetCore.Mvc;

namespace Project.Web.Areas.Personel.Controllers
{
    [Area("Personel")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Request()
        {
            return View();
        }
        public IActionResult Approve()
        {
            return View();
        }
    }
}
