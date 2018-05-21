using Microsoft.AspNetCore.Mvc;

namespace PS2.Controllers
{
    public class HomeController : Controller
    {
        public bool Umplut { get; set; }
        public bool Pornit { get; set; }

        public IActionResult Index()
        {
           // Umplut = true;
            ViewData["Umplut"] = Umplut;
            ViewData["Pornit"] = Pornit;
            return View();
        }

        public IActionResult Umplere()
        {
            Umplut = true;
            ViewData["Umplut"] = Umplut;
            Pornit = true;
            ViewData["Pornit"] = Pornit;
            return View("Index");
        }

        public IActionResult Golire()
        {
            Umplut = false;
            ViewData["Umplut"] = Umplut;
            Pornit = false;
            ViewData["Pornit"] = Pornit;

            return View("Index");
        }


    }
}
