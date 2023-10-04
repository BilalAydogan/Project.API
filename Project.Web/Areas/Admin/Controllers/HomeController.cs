using Microsoft.AspNetCore.Mvc;

namespace Project.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Rol()
        {
            return View();
        }
        public IActionResult Department()
        {
            return View();
        }
        public IActionResult Company()
        {
            return View();
        }
        public IActionResult User()
        {
            return View();
        }
    }
}
