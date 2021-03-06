﻿using System;
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
    public class PacientesController : Controller
    {
        private Entities db = Singleton.Instance.Entities;

        // GET: Pacientes
        public ActionResult Index()
        {
            return View(PacienteDAO.ListaDePacientesDaClinicaLogada());
        }

        // GET: Pacientes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Paciente paciente = db.Pacientes.Find(id);
            if (paciente == null)
            {
                return HttpNotFound();
            }
            return View(paciente);
        }

        // GET: Pacientes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Pacientes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PacienteId,PacienteNome,PacienteCPF")] Paciente paciente)
        {
            if (ModelState.IsValid)
            {
                PacienteDAO.AdicionaPaciente(paciente);
                return RedirectToAction("Index");
            }
            return View(paciente);
        }

        // GET: Pacientes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Paciente paciente = db.Pacientes.Find(id);
            if (paciente == null)
            {
                return HttpNotFound();
            }
            return View(paciente);
        }

        // POST: Pacientes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PacienteId,PacienteNome,PacienteCPF")] Paciente paciente)
        {
            if (ModelState.IsValid)
            {
                Paciente pacienteAux = PacienteDAO.RetornaPacientePorId(paciente.PacienteId);
                pacienteAux.PacienteNome = paciente.PacienteNome;
                pacienteAux.PacienteCPF = paciente.PacienteCPF;

                //Clinica c = new Clinica();
                //c = ClinicaLoginDAO.RetornarClinicaLogada();
                //paciente.ClinicaId = c.ClinicaId;
                //db.Entry(paciente).State = EntityState.Modified;
                //db.SaveChanges();
                //return RedirectToAction("Index");

                try
                {
                    db.Entry(pacienteAux).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                catch (Exception)
                {
                    ViewBag.Erro = "Erro ao Editar Informações!";
                    return RedirectToAction("Edit"); 
                }
            }
            return View(paciente);
        }

        // GET: Pacientes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Paciente paciente = db.Pacientes.Find(id);
            if (paciente == null)
            {
                return HttpNotFound();
            }
            return View(paciente);
        }

        // POST: Pacientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Paciente paciente = db.Pacientes.Find(id);
            db.Pacientes.Remove(paciente);
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
