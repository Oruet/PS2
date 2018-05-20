using Microsoft.AspNetCore.Mvc;

namespace PS2.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

       
    }
}
