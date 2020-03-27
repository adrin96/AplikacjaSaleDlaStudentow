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
    public class BIURAController : Controller
    {
       
        private ProjektSaleEntities db = new ProjektSaleEntities();

        // GET: BIURA
        public ActionResult Index()
        {
            return View(db.BIURA.ToList());
        }

        // GET: BIURA/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BIURA bIURA = db.BIURA.Find(id);
            if (bIURA == null)
            {
                return HttpNotFound();
            }
            return View(bIURA);
        }

        // GET: BIURA/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BIURA/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID_BIURA,NAZWA,ADRES")] BIURA bIURA)
        {
            if (ModelState.IsValid)
            {
                db.BIURA.Add(bIURA);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(bIURA);
        }

        // GET: BIURA/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BIURA bIURA = db.BIURA.Find(id);
            if (bIURA == null)
            {
                return HttpNotFound();
            }
            return View(bIURA);
        }

        // POST: BIURA/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID_BIURA,NAZWA,ADRES")] BIURA bIURA)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bIURA).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bIURA);
        }

        // GET: BIURA/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BIURA bIURA = db.BIURA.Find(id);
            if (bIURA == null)
            {
                return HttpNotFound();
            }
            return View(bIURA);
        }

        // POST: BIURA/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            BIURA bIURA = db.BIURA.Find(id);
            db.BIURA.Remove(bIURA);
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
