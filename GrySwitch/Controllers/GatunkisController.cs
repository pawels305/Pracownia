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
    public class GatunkisController : Controller
    {
        private ProjektEntities db = new ProjektEntities();

        // GET: Gatunkis
        public ActionResult Index()
        {
            return View(db.Gatunki.ToList());
        }

        // GET: Gatunkis/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gatunki gatunki = db.Gatunki.Find(id);
            if (gatunki == null)
            {
                return HttpNotFound();
            }
            return View(gatunki);
        }

        // GET: Gatunkis/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Gatunkis/Create
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Gatunek")] Gatunki gatunki)
        {
            if (ModelState.IsValid)
            {
                db.Gatunki.Add(gatunki);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(gatunki);
        }

        // GET: Gatunkis/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gatunki gatunki = db.Gatunki.Find(id);
            if (gatunki == null)
            {
                return HttpNotFound();
            }
            return View(gatunki);
        }

        // POST: Gatunkis/Edit/5
        // Aby zapewnić ochronę przed atakami polegającymi na przesyłaniu dodatkowych danych, włącz określone właściwości, z którymi chcesz utworzyć powiązania.
        // Aby uzyskać więcej szczegółów, zobacz https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Gatunek")] Gatunki gatunki)
        {
            if (ModelState.IsValid)
            {
                db.Entry(gatunki).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(gatunki);
        }

        // GET: Gatunkis/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Gatunki gatunki = db.Gatunki.Find(id);
            if (gatunki == null)
            {
                return HttpNotFound();
            }
            return View(gatunki);
        }

        // POST: Gatunkis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Gatunki gatunki = db.Gatunki.Find(id);
            db.Gatunki.Remove(gatunki);
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
