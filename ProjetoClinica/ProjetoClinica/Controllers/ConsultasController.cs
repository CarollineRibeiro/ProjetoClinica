using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjetoClinica.Models;
using ProjetoClinica.DAO;

namespace ProjetoClinica.Controllers
{
    public class ConsultasController : Controller
    {
        private static Entities db = Singleton.Instance.Entities;

        // GET: Consultas
        public ActionResult Index()
        {
            return View(ConsultaDAO.RetornarListaConsultasDaClinicaLogada());
        }

        // GET: Consultas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Consulta consulta = db.Consultas.Find(id);
            if (consulta == null)
            {
                return HttpNotFound();
            }
            return View(consulta);
        }

        // GET: Consultas/Create
        public ActionResult Create()
        {
            List<Paciente> ListaPaciente = new List<Paciente>();
            ListaPaciente = PacienteDAO.ListaDePacientesDaClinicaLogada();
            ViewBag.PacienteId = new SelectList(ListaPaciente, "PacienteId", "PacienteNome");
            return View();
        }

        // POST: Consultas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ConsultaId, PacienteId, DataConsulta")] Consulta consulta)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    consulta.Clinica = ClinicaLoginDAO.RetornarClinicaLogada();
                    db.Consultas.Add(consulta);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception e)
                {
                    return RedirectToAction("Index");
                }
            }

            return View(consulta);
        }

        // GET: Consultas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Consulta consulta = db.Consultas.Find(id);
            if (consulta == null)
            {
                return HttpNotFound();
            }
            return View(consulta);
        }

        // POST: Consultas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ConsultaId,DataConsulta")] Consulta consulta)
        {
            if (ModelState.IsValid)
            {

                Console.WriteLine(consulta.DataConsulta);
                Consulta c = new Consulta();
                c = ConsultaDAO.RetornarConsultaPorId(consulta.ConsultaId);
                consulta.PacienteId = c.PacienteId;

                consulta.Paciente = PacienteDAO.RetornaPacientePorId(c.PacienteId);

                Clinica clinica = new Clinica();
                clinica = ClinicaLoginDAO.RetornarClinicaLogada();
                consulta.Clinica = clinica;

                db.Entry(consulta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(consulta);
        }

        // GET: Consultas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Consulta consulta = db.Consultas.Find(id);
            if (consulta == null)
            {
                return HttpNotFound();
            }
            return View(consulta);
        }

        // POST: Consultas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Consulta consulta = db.Consultas.Find(id);
            db.Consultas.Remove(consulta);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
