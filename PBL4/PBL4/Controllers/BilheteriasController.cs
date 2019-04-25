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
    public class BilheteriasController : Controller
    {
        private PBL4Context db = new PBL4Context();

        // GET: Bilheterias
        public ActionResult Index()
        {
            return View(db.Bilheterias.ToList());
        }

        // GET: Bilheterias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bilheteria bilheteria = db.Bilheterias.Find(id);
            if (bilheteria == null)
            {
                return HttpNotFound();
            }
            return View(bilheteria);
        }

        // GET: Bilheterias/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Bilheterias/Create
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BilheteriaId,Nome,Local")] Bilheteria bilheteria)
        {
            if (ModelState.IsValid)
            {
                db.Bilheterias.Add(bilheteria);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bilheteria);
        }

        // GET: Bilheterias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bilheteria bilheteria = db.Bilheterias.Find(id);
            if (bilheteria == null)
            {
                return HttpNotFound();
            }
            return View(bilheteria);
        }

        // POST: Bilheterias/Edit/5
        // Para se proteger de mais ataques, ative as propriedades específicas a que você quer se conectar. Para 
        // obter mais detalhes, consulte https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BilheteriaId,Nome,Local")] Bilheteria bilheteria)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bilheteria).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bilheteria);
        }

        // GET: Bilheterias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bilheteria bilheteria = db.Bilheterias.Find(id);
            if (bilheteria == null)
            {
                return HttpNotFound();
            }
            return View(bilheteria);
        }

        // POST: Bilheterias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bilheteria bilheteria = db.Bilheterias.Find(id);
            db.Bilheterias.Remove(bilheteria);
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
