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
        public IActionResult Offer()
        {
            return View();
        }
        public IActionResult Purchasing()
        {
            return View();
        }
        public IActionResult General()
        {
            return View();
        }
        public IActionResult Manager()
        {
            return View();
        }
    }
}
