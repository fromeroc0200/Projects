using PatternDependencyInjectionUnity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PatternDependencyInjectionUnity.Controllers
{
    public class HomeController : Controller
    {
        private ILog log;
        // GET: Home

        public HomeController(ILog log)
        {
            this.log = log;
        }

        public ActionResult Index()
        {
            //Se visualiza en el output de visual studio
            log.Log("Escribiendo log");

            return View();
        }
    }
}