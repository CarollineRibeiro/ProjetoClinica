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
    public class ClinicasController : Controller
    {
        public static Clinica c = new Clinica();


        private Entities db = Singleton.Instance.Entities;

        // GET: Clinicas
        public ActionResult Index()
        {
            Clinica cliente = new Clinica();
            cliente = ClinicaLoginDAO.RetornarClinicaLogada();
            return View(cliente);
        }

        // GET: Clinicas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clinica clinica = db.Clinicas.Find(id);
            if (clinica == null)
            {
                return HttpNotFound();
            }
            return View(clinica);
        }

        // GET: Clinicas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Clinicas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ClinicaId,ClinicaNome,ClinicaMedico,Login,Senha")] Clinica clinica)
        {
            if (ModelState.IsValid)
            {
                Clinica cli = new Clinica();
                cli = ClinicaDAO.LoginExistente(clinica);
                if (cli == null) {
                    db.Clinicas.Add(clinica);
                    db.SaveChanges();
                    return RedirectToAction("Login");
                }
            }
            ViewBag.Mensagem = "ERRO - O login inserido já está sendo utilizado por outra clínica";
            return View(clinica);
        }

        // GET: Clinicas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clinica clinica = db.Clinicas.Find(id);
            if (clinica == null)
            {
                return HttpNotFound();
            }
            return View(clinica);
        }

        // POST: Clinicas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ClinicaId,ClinicaNome,ClinicaMedico,Login,Senha")] Clinica clinica)
        {
            if (ModelState.IsValid)
            {

                Clinica ClinicaAux = ClinicaDAO.RetornaClinicaPorId(clinica.ClinicaId);
                ClinicaAux.ClinicaNome = clinica.ClinicaNome;
                ClinicaAux.ClinicaMedico = clinica.ClinicaMedico;
                ClinicaAux.Login = clinica.Login;
                ClinicaAux.Senha = clinica.Senha;
                try
                {
                    db.Entry(ClinicaAux).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Login");
                }
                catch (Exception e)
                {
                    ViewBag.Erro = "Erro ao Editar Informações!";
                    return RedirectToAction("Edit");
                }
            }
            return View(clinica);
        }

        // GET: Clinicas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Clinica clinica = db.Clinicas.Find(id);
            if (clinica == null)
            {
                return HttpNotFound();
            }
            return View(clinica);
        }

        // POST: Clinicas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Clinica clinica = db.Clinicas.Find(id);
            db.Clinicas.Remove(clinica);
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


        // GET: Clinicas/Login
        public ActionResult Login()
        {
            ClinicaLoginDAO.NovoGuidPraSessao();
            return View();
        }

        // POST: Clinicas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login([Bind(Include = "ClinicaId,ClinicaNome,ClinicaMedico,Login,Senha")] Clinica clinica)
        {
            if (ModelState.IsValid)
            {
                c = ClinicaDAO.LoginUsuario(clinica);
                if (c != null)
                {
                    ClinicaDAO.AdicionarLogin(c);
                    return RedirectToAction("Index");
                }
            }
            ViewBag.Mensagem = "Login e/ou Senha inválido (s)";
            return View(clinica);
        }
    }
}
