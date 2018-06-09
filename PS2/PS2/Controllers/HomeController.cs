using DAL;
using Microsoft.AspNetCore.Mvc;
using PS2.Models;
using System;

namespace PS2.Controllers
{
    public class HomeController : Controller
    {
        public static bool Umplut { get; set; }
        public static bool Pornit { get; set; }
        public static bool Deschis { get; set; }

        public static bool Activat { get; set; }


        [HttpPost]
        public IActionResult Activare(ActivareViewModel model)
        {
            if (model.ButonActivare != null && model.ButonActivare.Equals("activat"))
            {
                Activat = true;
            }
            else
            {
                Activat = false;
                Deschis = false;
            }

            ViewData["Umplut"] = Umplut;
            ViewData["Pornit"] = Pornit;
            ViewData["Deschis"] = Deschis;
            ViewData["Activat"] = Activat;
            return View("Index");
        }


        public IActionResult Index()
        {
            // Umplut = true;
            ViewData["Umplut"] = Umplut;
            ViewData["Pornit"] = Pornit;
            ViewData["Deschis"] = Deschis;
            ViewData["Activat"] = Activat;
            return View();
        }

        public IActionResult Umplere()
        {
            if (Activat == true)
            {
                if(Umplut == false)
                {
                    ViewData["FostGolit"] = true;
                }
                Umplut = true;
               Pornit = true;
                Deschis = false;
            }
            ViewData["Umplut"] = Umplut;          
            ViewData["Pornit"] = Pornit;        
            ViewData["Deschis"] = Deschis;
            ViewData["Activat"] = Activat;
            return View("Index");
        }

        public IActionResult Golire()
        {
            if (Activat == true)
            {

                if(Umplut == true)
                {
                    Deschis = true;
                    Pornit = true;
                    ViewData["FostUmplut"] = true;
                }
                else
                {
                    Deschis = false;
                    Pornit = false;
                }
                Umplut = false;
                
               
            }

            ViewData["Umplut"] = Umplut;
            ViewData["Pornit"] = Pornit;
            ViewData["Deschis"] = Deschis;
            ViewData["Activat"] = Activat;

            return View("Index");
        }

        public IActionResult Istoric()
        {
         
            return View();
        }


    }
}
