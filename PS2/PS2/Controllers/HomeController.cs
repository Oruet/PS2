using DAL;
using Microsoft.AspNetCore.Mvc;
using PS2.Models;
using Shared;
using System;

namespace PS2.Controllers
{
    public class HomeController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Istoric()
        {
         
            return View();
        }
        [HttpGet]
        public JsonResult Stare()
        {
            Stare stare = new Stare { Umplut =SharedVariables.Umplut, Activat = SharedVariables.Activat, Pornit = SharedVariables.Pornit, Deschis = SharedVariables.Deschis };

            return Json(stare);
        }

        [HttpPost]
        public IActionResult UpdateStare([FromBody]Stare model)
        {
            SharedVariables.Umplut = model.Umplut;
            SharedVariables.Activat = model.Activat;
            SharedVariables.Pornit = model.Pornit;
            SharedVariables.Deschis = model.Deschis;

            return Json(new{ });
        }

    }
}
