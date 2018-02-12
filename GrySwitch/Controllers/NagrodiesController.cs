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
    public class NagrodiesController : Controller
    {
        private ProjektEntities db = new ProjektEntities();

        // GET: Nagrodies
        public ActionResult Index()
        {
            return View(db.Nagrody.ToList());
        }

        // GET: Nagrodies/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nagrody nagrody = db.Nagrody.Find(id);
            if (nagrody == null)
            {
                return HttpNotFound();
            }
            return View(nagrody);
        }

        // GET: Nagrodies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Nagrodies/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,NazwaNagrody,Prestiż")] Nagrody nagrody)
        {
            if (ModelState.IsValid)
            {
                db.Nagrody.Add(nagrody);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(nagrody);
        }

        // GET: Nagrodies/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nagrody nagrody = db.Nagrody.Find(id);
            if (nagrody == null)
            {
                return HttpNotFound();
            }
            return View(nagrody);
        }

        // POST: Nagrodies/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,NazwaNagrody,Prestiż")] Nagrody nagrody)
        {
            if (ModelState.IsValid)
            {
                db.Entry(nagrody).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(nagrody);
        }

        // GET: Nagrodies/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Nagrody nagrody = db.Nagrody.Find(id);
            if (nagrody == null)
            {
                return HttpNotFound();
            }
            return View(nagrody);
        }

        // POST: Nagrodies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Nagrody nagrody = db.Nagrody.Find(id);
            db.Nagrody.Remove(nagrody);
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
