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
    public class STUDENCIController : Controller
    {
        private ProjektSaleEntities db = new ProjektSaleEntities();

        // GET: STUDENCI
        public ActionResult Index()
        {
            var sTUDENCI = db.STUDENCI.Include(s => s.KIERUNKI);
            return View(sTUDENCI.ToList());
        }

        // GET: STUDENCI/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            STUDENCI sTUDENCI = db.STUDENCI.Find(id);
            if (sTUDENCI == null)
            {
                return HttpNotFound();
            }
            return View(sTUDENCI);
        }

        // GET: STUDENCI/Create
        public ActionResult Create()
        {
            ViewBag.ID_KIERUNKU = new SelectList(db.KIERUNKI, "ID_KIERUNKU", "NAZWA_KIERUNKU");
            return View();
        }

        // POST: STUDENCI/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "NR_ALBUMU,IMIE,NAZWISKO,NR_TELEFONU,ID_KIERUNKU")] STUDENCI sTUDENCI)
        {
            if (ModelState.IsValid)
            {
                db.STUDENCI.Add(sTUDENCI);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_KIERUNKU = new SelectList(db.KIERUNKI, "ID_KIERUNKU", "NAZWA_KIERUNKU", sTUDENCI.ID_KIERUNKU);
            return View(sTUDENCI);
        }

        // GET: STUDENCI/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            STUDENCI sTUDENCI = db.STUDENCI.Find(id);
            if (sTUDENCI == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_KIERUNKU = new SelectList(db.KIERUNKI, "ID_KIERUNKU", "NAZWA_KIERUNKU", sTUDENCI.ID_KIERUNKU);
            return View(sTUDENCI);
        }

        // POST: STUDENCI/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "NR_ALBUMU,IMIE,NAZWISKO,NR_TELEFONU,ID_KIERUNKU")] STUDENCI sTUDENCI)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sTUDENCI).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_KIERUNKU = new SelectList(db.KIERUNKI, "ID_KIERUNKU", "NAZWA_KIERUNKU", sTUDENCI.ID_KIERUNKU);
            return View(sTUDENCI);
        }

        // GET: STUDENCI/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            STUDENCI sTUDENCI = db.STUDENCI.Find(id);
            if (sTUDENCI == null)
            {
                return HttpNotFound();
            }
            return View(sTUDENCI);
        }

        // POST: STUDENCI/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            STUDENCI sTUDENCI = db.STUDENCI.Find(id);
            db.STUDENCI.Remove(sTUDENCI);
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
