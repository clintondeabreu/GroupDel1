using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BackEnd.Models;

namespace BackEnd.Controllers
{
    public class AdditionalInfoesController : Controller
    {
        private DiseaseDBEntities db = new DiseaseDBEntities();

        // GET: AdditionalInfoes
        public ActionResult Index()
        {
            return View(db.AdditionalInfoes.ToList());
        }

        // GET: AdditionalInfoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdditionalInfo additionalInfo = db.AdditionalInfoes.Find(id);
            if (additionalInfo == null)
            {
                return HttpNotFound();
            }
            return View(additionalInfo);
        }

        // GET: AdditionalInfoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdditionalInfoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AdditionalInfoID,Description")] AdditionalInfo additionalInfo)
        {
            if (ModelState.IsValid)
            {
                db.AdditionalInfoes.Add(additionalInfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(additionalInfo);
        }

        // GET: AdditionalInfoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdditionalInfo additionalInfo = db.AdditionalInfoes.Find(id);
            if (additionalInfo == null)
            {
                return HttpNotFound();
            }
            return View(additionalInfo);
        }

        // POST: AdditionalInfoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AdditionalInfoID,Description")] AdditionalInfo additionalInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(additionalInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(additionalInfo);
        }

        // GET: AdditionalInfoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AdditionalInfo additionalInfo = db.AdditionalInfoes.Find(id);
            if (additionalInfo == null)
            {
                return HttpNotFound();
            }
            return View(additionalInfo);
        }

        // POST: AdditionalInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AdditionalInfo additionalInfo = db.AdditionalInfoes.Find(id);
            db.AdditionalInfoes.Remove(additionalInfo);
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
