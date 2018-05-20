using Microsoft.AspNetCore.Mvc;

namespace PS2.Controllers
{
    public class HomeController : Controller
    {
        public bool Umplut { get; set; }

        public IActionResult Index()
        {
           // Umplut = true;
            ViewData["Umplut"] = Umplut;
            return View();
        }

        public IActionResult Umplere()
        {
            Umplut = true;
            ViewData["Umplut"] = Umplut;
            return View("Index");
        }

        public IActionResult Golire()
        {
            Umplut = false;
            ViewData["Umplut"] = Umplut;
            return View("Index");
        }


    }
}
