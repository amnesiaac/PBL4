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
    public class VendaIngressosController : Controller
    {
        private PBL4Context db = new PBL4Context();

        // GET: VendaIngressos
        public ActionResult Index()
        {
            var vendaIngressoes = db.VendaIngressoes.Include(v => v.Bilheteria).Include(v => v.Ingresso).Include(v => v.Pessoa);
            return View(vendaIngressoes.ToList());
        }

        // GET: VendaIngressos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VendaIngresso vendaIngresso = db.VendaIngressoes.Find(id);
            if (vendaIngresso == null)
            {
                return HttpNotFound();
            }
            return View(vendaIngresso);
        }

        // GET: VendaIngressos/Create
        public ActionResult Create()
        {
            ViewBag.BilheteriaId = new SelectList(db.Bilheterias, "BilheteriaId", "Nome");
            ViewBag.IngressoId = new SelectList(db.Ingressoes.Where(a => a.QuantidadeIngressos!=0), "IngressoId", "IngressoId");
            ViewBag.PessoaId = new SelectList(db.Pessoas, "PessoaId", "Nome");
            return View();
        }

        // POST: VendaIngressos/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "VendaIngressoId,IngressoId,PessoaId,BilheteriaId")] VendaIngresso vendaIngresso)
        {
            if (ModelState.IsValid)
            {
                Ingresso ingresso = db.Ingressoes.Find(vendaIngresso.IngressoId);
                vendaIngresso.Ingresso = ingresso;
                if (vendaIngresso.decrementaIngresso())
                {
                    db.VendaIngressoes.Add(vendaIngresso);
                    db.SaveChanges();
                    ingresso.QuantidadeIngressos -= 1;
                    db.Entry(ingresso).State = EntityState.Modified;
                    db.SaveChanges();
                }
                return RedirectToAction("Index");
            }

            ViewBag.BilheteriaId = new SelectList(db.Bilheterias, "BilheteriaId", "Nome", vendaIngresso.BilheteriaId);
            ViewBag.IngressoId = new SelectList(db.Ingressoes, "IngressoId", "IngressoId", vendaIngresso.IngressoId);
            ViewBag.PessoaId = new SelectList(db.Pessoas, "PessoaId", "Nome", vendaIngresso.PessoaId);
            return View(vendaIngresso);
        }

        // GET: VendaIngressos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VendaIngresso vendaIngresso = db.VendaIngressoes.Find(id);
            if (vendaIngresso == null)
            {
                return HttpNotFound();
            }
            ViewBag.BilheteriaId = new SelectList(db.Bilheterias, "BilheteriaId", "Nome", vendaIngresso.BilheteriaId);
            ViewBag.IngressoId = new SelectList(db.Ingressoes, "IngressoId", "IngressoId", vendaIngresso.IngressoId);
            ViewBag.PessoaId = new SelectList(db.Pessoas, "PessoaId", "Nome", vendaIngresso.PessoaId);
            return View(vendaIngresso);
        }

        // POST: VendaIngressos/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "VendaIngressoId,IngressoId,PessoaId,BilheteriaId")] VendaIngresso vendaIngresso)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vendaIngresso).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BilheteriaId = new SelectList(db.Bilheterias, "BilheteriaId", "Nome", vendaIngresso.BilheteriaId);
            ViewBag.IngressoId = new SelectList(db.Ingressoes, "IngressoId", "IngressoId", vendaIngresso.IngressoId);
            ViewBag.PessoaId = new SelectList(db.Pessoas, "PessoaId", "Nome", vendaIngresso.PessoaId);
            return View(vendaIngresso);
        }

        // GET: VendaIngressos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VendaIngresso vendaIngresso = db.VendaIngressoes.Find(id);
            if (vendaIngresso == null)
            {
                return HttpNotFound();
            }
            return View(vendaIngresso);
        }

        // POST: VendaIngressos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VendaIngresso vendaIngresso = db.VendaIngressoes.Find(id);
            db.VendaIngressoes.Remove(vendaIngresso);
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
