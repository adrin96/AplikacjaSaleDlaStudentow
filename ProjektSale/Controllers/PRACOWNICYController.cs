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
    public class PRACOWNICYController : Controller
    {
        private ProjektSaleEntities db = new ProjektSaleEntities();

        // GET: PRACOWNICY
        public ActionResult Index()
        {
            var pRACOWNICY = db.PRACOWNICY.Include(p => p.BIURA).Include(p => p.PRACOWNICY2);
            return View(pRACOWNICY.ToList());
        }

        // GET: PRACOWNICY/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRACOWNICY pRACOWNICY = db.PRACOWNICY.Find(id);
            if (pRACOWNICY == null)
            {
                return HttpNotFound();
            }
            return View(pRACOWNICY);
        }

        // GET: PRACOWNICY/Create
        public ActionResult Create()
        {
            ViewBag.ID_BIURA = new SelectList(db.BIURA, "ID_BIURA", "NAZWA");
            ViewBag.ID_PRZELOZONEGO = new SelectList(db.PRACOWNICY, "ID_PRACOWNIKA", "IMIE");
            return View();
        }

        // POST: PRACOWNICY/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_PRACOWNIKA,IMIE,NAZWISKO,PENSJA,DATA_ZATRUDNIENIA,ID_BIURA,ID_PRZELOZONEGO,STANOWISKO")] PRACOWNICY pRACOWNICY)
        {
            if (ModelState.IsValid)
            {
                db.PRACOWNICY.Add(pRACOWNICY);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ID_BIURA = new SelectList(db.BIURA, "ID_BIURA", "NAZWA", pRACOWNICY.ID_BIURA);
            ViewBag.ID_PRZELOZONEGO = new SelectList(db.PRACOWNICY, "ID_PRACOWNIKA", "IMIE", pRACOWNICY.ID_PRZELOZONEGO);
            return View(pRACOWNICY);
        }

        // GET: PRACOWNICY/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRACOWNICY pRACOWNICY = db.PRACOWNICY.Find(id);
            if (pRACOWNICY == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID_BIURA = new SelectList(db.BIURA, "ID_BIURA", "NAZWA", pRACOWNICY.ID_BIURA);
            ViewBag.ID_PRZELOZONEGO = new SelectList(db.PRACOWNICY, "ID_PRACOWNIKA", "IMIE", pRACOWNICY.ID_PRZELOZONEGO);
            return View(pRACOWNICY);
        }

        // POST: PRACOWNICY/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_PRACOWNIKA,IMIE,NAZWISKO,PENSJA,DATA_ZATRUDNIENIA,ID_BIURA,ID_PRZELOZONEGO,STANOWISKO")] PRACOWNICY pRACOWNICY)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pRACOWNICY).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ID_BIURA = new SelectList(db.BIURA, "ID_BIURA", "NAZWA", pRACOWNICY.ID_BIURA);
            ViewBag.ID_PRZELOZONEGO = new SelectList(db.PRACOWNICY, "ID_PRACOWNIKA", "IMIE", pRACOWNICY.ID_PRZELOZONEGO);
            return View(pRACOWNICY);
        }

        // GET: PRACOWNICY/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PRACOWNICY pRACOWNICY = db.PRACOWNICY.Find(id);
            if (pRACOWNICY == null)
            {
                return HttpNotFound();
            }
            return View(pRACOWNICY);
        }

        // POST: PRACOWNICY/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PRACOWNICY pRACOWNICY = db.PRACOWNICY.Find(id);
            db.PRACOWNICY.Remove(pRACOWNICY);
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
