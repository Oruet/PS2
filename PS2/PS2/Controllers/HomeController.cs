using DAL;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.AspNetCore.Mvc;
using PS2.Models;
using Shared;
using System;
using System.Threading.Tasks;

namespace PS2.Controllers
{
    public class HomeController : Controller
    {
        private static bool tcpInitialized = false;
        private static TcpCommunication tcpCommunication;

        public HomeController()
        {
            if (!tcpInitialized)
            {
                tcpCommunication = new TcpCommunication();
                tcpCommunication.StateChanged += StareHandler.Tcp_StateChanged;
                tcpCommunication.StartTcp();
                tcpInitialized = true;
            }
        }

        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Istoric()
        {
            DBHelper.reloadData();
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
            try
            {
                if (SharedVariables.Activat == false && model.Activat == true)
                {
                    tcpCommunication.On();
                }

                if (SharedVariables.Activat == true && model.Activat == false)
                {
                    tcpCommunication.Off();
                }

                if (SharedVariables.Umplut == true && model.Umplut == false)
                {
                    Task.Run(() =>
                    {
                        DBHelper.addUser("User1", DateTime.Now, "Golire", "Nivel 5");
                        tcpCommunication.Golire();
                    });

                   
                }

                if (SharedVariables.Umplut == false && model.Umplut == true)
                {
                    Task.Run(() =>
                    {
                        DBHelper.addUser("User1", DateTime.Now, "Umplere", "Nivel 1");
                        tcpCommunication.Umplere();
                    });
                   
                }
            }
            catch (Exception ex) { }

            SharedVariables.Umplut = model.Umplut;
            SharedVariables.Activat = model.Activat;
            SharedVariables.Pornit = model.Pornit;
            SharedVariables.Deschis = model.Deschis;

            return Json(new{ });
        }

    }
}
