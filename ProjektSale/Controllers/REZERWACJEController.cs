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
    public class REZERWACJEController : Controller
    {
        private ProjektSaleEntities db = new ProjektSaleEntities();

        // GET: REZERWACJE
        public ActionResult Index()
        {
            var rEZERWACJE = db.REZERWACJE.Include(r => r.PRACOWNICY).Include(r => r.SALE).Include(r => r.STUDENCI);
            return View(rEZERWACJE.ToList());
        }

        // GET: REZERWACJE/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            REZERWACJE rEZERWACJE = db.REZERWACJE.Find(id);
            if (rEZERWACJE == null)
            {
                return HttpNotFound();
            }
            return View(rEZERWACJE);
        }

        // GET: REZERWACJE/Create
        public ActionResult Create()
        {
            ViewBag.ID_PRACOWNIKA = new SelectList(db.PRACOWNICY, "ID_PRACOWNIKA", "IMIE");
            ViewBag.ID_SALI = new SelectList(db.SALE, "ID_SALI", "NAZWA");
            ViewBag.NR_ALBUMU = new SelectList(db.STUDENCI, "NR_ALBUMU", "IMIE");
            return View();
        }

        // POST: REZERWACJE/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_REZERWACJI,REZERWACJA_OD,REZERWACJA_DO,CENA,NR_ALBUMU,ID_SALI,ID_PRACOWNIKA")] REZERWACJE rEZERWACJE)
        {
            if (ModelState.IsValid)
            {
                db.REZERWACJE.Add(rEZERWACJE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_PRACOWNIKA = new SelectList(db.PRACOWNICY, "ID_PRACOWNIKA", "IMIE", rEZERWACJE.ID_PRACOWNIKA);
            ViewBag.ID_SALI = new SelectList(db.SALE, "ID_SALI", "NAZWA", rEZERWACJE.ID_SALI);
            ViewBag.NR_ALBUMU = new SelectList(db.STUDENCI, "NR_ALBUMU", "IMIE", rEZERWACJE.NR_ALBUMU);
            return View(rEZERWACJE);
        }

        // GET: REZERWACJE/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            REZERWACJE rEZERWACJE = db.REZERWACJE.Find(id);
            if (rEZERWACJE == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_PRACOWNIKA = new SelectList(db.PRACOWNICY, "ID_PRACOWNIKA", "IMIE", rEZERWACJE.ID_PRACOWNIKA);
            ViewBag.ID_SALI = new SelectList(db.SALE, "ID_SALI", "NAZWA", rEZERWACJE.ID_SALI);
            ViewBag.NR_ALBUMU = new SelectList(db.STUDENCI, "NR_ALBUMU", "IMIE", rEZERWACJE.NR_ALBUMU);
            return View(rEZERWACJE);
        }

        // POST: REZERWACJE/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_REZERWACJI,REZERWACJA_OD,REZERWACJA_DO,CENA,NR_ALBUMU,ID_SALI,ID_PRACOWNIKA")] REZERWACJE rEZERWACJE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(rEZERWACJE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_PRACOWNIKA = new SelectList(db.PRACOWNICY, "ID_PRACOWNIKA", "IMIE", rEZERWACJE.ID_PRACOWNIKA);
            ViewBag.ID_SALI = new SelectList(db.SALE, "ID_SALI", "NAZWA", rEZERWACJE.ID_SALI);
            ViewBag.NR_ALBUMU = new SelectList(db.STUDENCI, "NR_ALBUMU", "IMIE", rEZERWACJE.NR_ALBUMU);
            return View(rEZERWACJE);
        }

        // GET: REZERWACJE/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            REZERWACJE rEZERWACJE = db.REZERWACJE.Find(id);
            if (rEZERWACJE == null)
            {
                return HttpNotFound();
            }
            return View(rEZERWACJE);
        }

        // POST: REZERWACJE/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            REZERWACJE rEZERWACJE = db.REZERWACJE.Find(id);
            db.REZERWACJE.Remove(rEZERWACJE);
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
