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
    public class SALEController : Controller
    {
        private ProjektSaleEntities db = new ProjektSaleEntities();

        // GET: SALE
        public ActionResult Index()
        {
            return View(db.SALE.ToList());
        }

        // GET: SALE/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SALE sALE = db.SALE.Find(id);
            if (sALE == null)
            {
                return HttpNotFound();
            }
            return View(sALE);
        }

        // GET: SALE/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SALE/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_SALI,NAZWA,OPIS")] SALE sALE)
        {
            if (ModelState.IsValid)
            {
                db.SALE.Add(sALE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sALE);
        }

        // GET: SALE/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SALE sALE = db.SALE.Find(id);
            if (sALE == null)
            {
                return HttpNotFound();
            }
            return View(sALE);
        }

        // POST: SALE/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_SALI,NAZWA,OPIS")] SALE sALE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sALE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sALE);
        }

        // GET: SALE/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SALE sALE = db.SALE.Find(id);
            if (sALE == null)
            {
                return HttpNotFound();
            }
            return View(sALE);
        }

        // POST: SALE/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SALE sALE = db.SALE.Find(id);
            db.SALE.Remove(sALE);
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
