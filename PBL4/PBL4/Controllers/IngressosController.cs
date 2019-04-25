using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PBL4.Models;

namespace PBL4.Controllers
{
    public class IngressosController : Controller
    {
        private PBL4Context db = new PBL4Context();

        // GET: Ingressos
        public ActionResult Index()
        {
            var ingressoes = db.Ingressoes.Include(i => i.Evento);
            return View(ingressoes.ToList());
        }

        // GET: Ingressos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ingresso ingresso = db.Ingressoes.Find(id);
            if (ingresso == null)
            {
                return HttpNotFound();
            }
            return View(ingresso);
        }

        // GET: Ingressos/Create
        public ActionResult Create()
        {
            ViewBag.EventoId = new SelectList(db.Eventoes, "EventoId", "Nome");
            return View();
        }

        // POST: Ingressos/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IngressoId,EventoId,Valor")] Ingresso ingresso)
        {
            if (ModelState.IsValid)
            {
                db.Ingressoes.Add(ingresso);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.EventoId = new SelectList(db.Eventoes, "EventoId", "Nome", ingresso.EventoId);
            return View(ingresso);
        }

        // GET: Ingressos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ingresso ingresso = db.Ingressoes.Find(id);
            if (ingresso == null)
            {
                return HttpNotFound();
            }
            ViewBag.EventoId = new SelectList(db.Eventoes, "EventoId", "Nome", ingresso.EventoId);
            return View(ingresso);
        }

        // POST: Ingressos/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IngressoId,EventoId,Valor")] Ingresso ingresso)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ingresso).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.EventoId = new SelectList(db.Eventoes, "EventoId", "Nome", ingresso.EventoId);
            return View(ingresso);
        }

        // GET: Ingressos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ingresso ingresso = db.Ingressoes.Find(id);
            if (ingresso == null)
            {
                return HttpNotFound();
            }
            return View(ingresso);
        }

        // POST: Ingressos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Ingresso ingresso = db.Ingressoes.Find(id);
            db.Ingressoes.Remove(ingresso);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
