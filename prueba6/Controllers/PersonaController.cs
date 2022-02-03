using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Windows;
using prueba6.Models;

namespace prueba6.Controllers
{
    public class PersonaController : Controller
    {
        // GET: Persona
        public ActionResult Index()
        {
            List<Persona> personas = new List<Persona>();
            using (EmpresaEntities1 empresa = new EmpresaEntities1())
            {
                personas = empresa.Persona.ToList<Persona>();
            }
            return View(personas);
        }

        // GET: Persona/Details/5
        public ActionResult Details(int id)
        {
            Persona persona = new Persona();
            using (EmpresaEntities1 empresa = new EmpresaEntities1())
            {
                persona = empresa.Persona.Where(x => x.id == id).FirstOrDefault();
            }
            return View(persona);
        }

        // GET: Persona/Create
        public ActionResult Create()
        {
            return View(new Persona());
        }

        // POST: Persona/Create
        [HttpPost]
        public ActionResult Create(Persona persona)
        {
            using (EmpresaEntities1 empresa = new EmpresaEntities1())
            {
                empresa.Persona.Add(persona);
                MessageBoxResult result = System.Windows.MessageBox.Show("Mensaje de Alerta", "Persona agregada con exito", MessageBoxButton.OKCancel);
                empresa.SaveChanges();
                
            }
            return RedirectToAction("Index");
        }

        // GET: Persona/Edit/5
        public ActionResult Edit(int id)
        {
            Persona persona = new Persona();
            using (EmpresaEntities1 empresa = new EmpresaEntities1())
            {
                persona = empresa.Persona.Where(x=> x.id == id).FirstOrDefault();
            }
            return View(persona);
        }

        // POST: Persona/Edit/5
        [HttpPost]
        public ActionResult Edit(Persona persona)
        {
            using (EmpresaEntities1 empresa = new EmpresaEntities1())
            {
                empresa.Entry(persona).State = System.Data.Entity.EntityState.Modified;
                empresa.SaveChanges();
                MessageBoxResult mensaje = MessageBox.Show("Datos Modificadinios");
            }
            return RedirectToAction("Index");
        }

        // GET: Persona/Delete/5
        public ActionResult Delete(int id)
        {
            Persona persona = new Persona();
            using (EmpresaEntities1 empresa = new EmpresaEntities1())
            {
                persona = empresa.Persona.Where(x => x.id == id).FirstOrDefault();
            }
            return View(persona);
        }

        // POST: Persona/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            using (EmpresaEntities1 empresa = new EmpresaEntities1())
            {
                Persona persona = empresa.Persona.Where(x => x.id == id).FirstOrDefault();
                empresa.Persona.Remove(persona);
                empresa.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
