using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProjektSale;

namespace ProjektSale.Controllers
{
    [Authorize]
    public class PRZEDMIOTYController : Controller
    {
        private ProjektSaleEntities db = new ProjektSaleEntities();

        // GET: PRZEDMIOTY
        public ActionResult Index()
        {
            var pRZEDMIOTY = db.PRZEDMIOTY.Include(p => p.SALE);
            return View(pRZEDMIOTY.ToList());
        }

        // GET: PRZEDMIOTY/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRZEDMIOTY pRZEDMIOTY = db.PRZEDMIOTY.Find(id);
            if (pRZEDMIOTY == null)
            {
                return HttpNotFound();
            }
            return View(pRZEDMIOTY);
        }

        // GET: PRZEDMIOTY/Create
        public ActionResult Create()
        {
            ViewBag.ID_SALI = new SelectList(db.SALE, "ID_SALI", "NAZWA");
            return View();
        }

        // POST: PRZEDMIOTY/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_PRZEDMIOTU,NAZWA,OPIS,ILOSC,ID_SALI")] PRZEDMIOTY pRZEDMIOTY)
        {
            if (ModelState.IsValid)
            {
                db.PRZEDMIOTY.Add(pRZEDMIOTY);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_SALI = new SelectList(db.SALE, "ID_SALI", "NAZWA", pRZEDMIOTY.ID_SALI);
            return View(pRZEDMIOTY);
        }

        // GET: PRZEDMIOTY/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRZEDMIOTY pRZEDMIOTY = db.PRZEDMIOTY.Find(id);
            if (pRZEDMIOTY == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_SALI = new SelectList(db.SALE, "ID_SALI", "NAZWA", pRZEDMIOTY.ID_SALI);
            return View(pRZEDMIOTY);
        }

        // POST: PRZEDMIOTY/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_PRZEDMIOTU,NAZWA,OPIS,ILOSC,ID_SALI")] PRZEDMIOTY pRZEDMIOTY)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pRZEDMIOTY).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_SALI = new SelectList(db.SALE, "ID_SALI", "NAZWA", pRZEDMIOTY.ID_SALI);
            return View(pRZEDMIOTY);
        }

        // GET: PRZEDMIOTY/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRZEDMIOTY pRZEDMIOTY = db.PRZEDMIOTY.Find(id);
            if (pRZEDMIOTY == null)
            {
                return HttpNotFound();
            }
            return View(pRZEDMIOTY);
        }

        // POST: PRZEDMIOTY/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PRZEDMIOTY pRZEDMIOTY = db.PRZEDMIOTY.Find(id);
            db.PRZEDMIOTY.Remove(pRZEDMIOTY);
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
