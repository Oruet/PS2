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
            TcpCommunication tcp = new TcpCommunication();
            tcp.StateChanged += Tcp_StateChanged;
            tcp.StartTcp();
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

        private void Tcp_StateChanged(object sender, CustomEventArgs e)
        {
            if(e.AutomationState.b1)
            {
                //do smth
            }
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
