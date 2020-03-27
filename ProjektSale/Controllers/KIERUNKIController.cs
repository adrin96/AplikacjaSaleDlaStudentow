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
    public class KIERUNKIController : Controller
    {
        private ProjektSaleEntities db = new ProjektSaleEntities();

        // GET: KIERUNKI
        public ActionResult Index()
        {
            return View(db.KIERUNKI.ToList());
        }

        // GET: KIERUNKI/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KIERUNKI kIERUNKI = db.KIERUNKI.Find(id);
            if (kIERUNKI == null)
            {
                return HttpNotFound();
            }
            return View(kIERUNKI);
        }

        // GET: KIERUNKI/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: KIERUNKI/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_KIERUNKU,NAZWA_KIERUNKU,TYP_STUDIOW,CZAS_TRWANIA")] KIERUNKI kIERUNKI)
        {
            if (ModelState.IsValid)
            {
                db.KIERUNKI.Add(kIERUNKI);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(kIERUNKI);
        }

        // GET: KIERUNKI/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KIERUNKI kIERUNKI = db.KIERUNKI.Find(id);
            if (kIERUNKI == null)
            {
                return HttpNotFound();
            }
            return View(kIERUNKI);
        }

        // POST: KIERUNKI/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_KIERUNKU,NAZWA_KIERUNKU,TYP_STUDIOW,CZAS_TRWANIA")] KIERUNKI kIERUNKI)
        {
            if (ModelState.IsValid)
            {
                db.Entry(kIERUNKI).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(kIERUNKI);
        }

        // GET: KIERUNKI/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            KIERUNKI kIERUNKI = db.KIERUNKI.Find(id);
            if (kIERUNKI == null)
            {
                return HttpNotFound();
            }
            return View(kIERUNKI);
        }

        // POST: KIERUNKI/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            KIERUNKI kIERUNKI = db.KIERUNKI.Find(id);
            db.KIERUNKI.Remove(kIERUNKI);
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
