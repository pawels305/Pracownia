using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GrySwitch.Models;

namespace GrySwitch.Controllers
{
    public class GriesController : Controller
    {
        private ProjektEntities db = new ProjektEntities();

        // GET: Gries
        public ActionResult Index()
        {
            var gry = db.Gry.Include(g => g.Gatunki).Include(g => g.Nagrody);
            return View(gry.ToList());
        }

        // GET: Gries/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gry gry = db.Gry.Find(id);
            if (gry == null)
            {
                return HttpNotFound();
            }
            return View(gry);
        }

        // GET: Gries/Create
        public ActionResult Create()
        {
            ViewBag.IdGatunku = new SelectList(db.Gatunki, "Id", "Gatunek");
            ViewBag.IdNagród = new SelectList(db.Nagrody, "Id", "NazwaNagrody");
            return View();
        }

        // POST: Gries/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Tytuł,Cena,IdGatunku,IdNagród,DataWydania")] Gry gry)
        {
            if (ModelState.IsValid)
            {
                db.Gry.Add(gry);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IdGatunku = new SelectList(db.Gatunki, "Id", "Gatunek", gry.IdGatunku);
            ViewBag.IdNagród = new SelectList(db.Nagrody, "Id", "NazwaNagrody", gry.IdNagród);
            return View(gry);
        }

        // GET: Gries/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gry gry = db.Gry.Find(id);
            if (gry == null)
            {
                return HttpNotFound();
            }
            ViewBag.IdGatunku = new SelectList(db.Gatunki, "Id", "Gatunek", gry.IdGatunku);
            ViewBag.IdNagród = new SelectList(db.Nagrody, "Id", "NazwaNagrody", gry.IdNagród);
            return View(gry);
        }

        // POST: Gries/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Tytuł,Cena,IdGatunku,IdNagród,DataWydania")] Gry gry)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gry).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IdGatunku = new SelectList(db.Gatunki, "Id", "Gatunek", gry.IdGatunku);
            ViewBag.IdNagród = new SelectList(db.Nagrody, "Id", "NazwaNagrody", gry.IdNagród);
            return View(gry);
        }

        // GET: Gries/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gry gry = db.Gry.Find(id);
            if (gry == null)
            {
                return HttpNotFound();
            }
            return View(gry);
        }

        // POST: Gries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Gry gry = db.Gry.Find(id);
            db.Gry.Remove(gry);
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
