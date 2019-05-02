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
    public class TreatmentTypesController : Controller
    {
        private DiseaseDBEntities db = new DiseaseDBEntities();

        // GET: TreatmentTypes
        public ActionResult Index()
        {
            return View(db.TreatmentTypes.ToList());
        }

        // GET: TreatmentTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TreatmentType treatmentType = db.TreatmentTypes.Find(id);
            if (treatmentType == null)
            {
                return HttpNotFound();
            }
            return View(treatmentType);
        }

        // GET: TreatmentTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TreatmentTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TreatmentTypeID,Description")] TreatmentType treatmentType)
        {
            if (ModelState.IsValid)
            {
                db.TreatmentTypes.Add(treatmentType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(treatmentType);
        }

        // GET: TreatmentTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TreatmentType treatmentType = db.TreatmentTypes.Find(id);
            if (treatmentType == null)
            {
                return HttpNotFound();
            }
            return View(treatmentType);
        }

        // POST: TreatmentTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TreatmentTypeID,Description")] TreatmentType treatmentType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(treatmentType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(treatmentType);
        }

        // GET: TreatmentTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TreatmentType treatmentType = db.TreatmentTypes.Find(id);
            if (treatmentType == null)
            {
                return HttpNotFound();
            }
            return View(treatmentType);
        }

        // POST: TreatmentTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TreatmentType treatmentType = db.TreatmentTypes.Find(id);
            db.TreatmentTypes.Remove(treatmentType);
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
