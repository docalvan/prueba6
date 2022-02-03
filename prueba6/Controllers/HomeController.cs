using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using prueba6.Models;

namespace prueba6.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            List<Persona> personas = new List<Persona>();
            using (EmpresaEntities1 empresa = new EmpresaEntities1())
            {
                personas = empresa.Persona.ToList<Persona>();
            }
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}