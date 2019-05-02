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
    public class MedicationsController : Controller
    {
        private DiseaseDBEntities db = new DiseaseDBEntities();

        // GET: Medications
        public ActionResult Index()
        {
            var medications = db.Medications.Include(m => m.IllnessType).Include(m => m.MedicationType);
            return View(medications.ToList());
        }

        // GET: Medications/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medication medication = db.Medications.Find(id);
            if (medication == null)
            {
                return HttpNotFound();
            }
            return View(medication);
        }

        // GET: Medications/Create
        public ActionResult Create()
        {
            ViewBag.IllnessTypeID = new SelectList(db.IllnessTypes, "IllnessTypeID", "Description");
            ViewBag.MT_ID = new SelectList(db.MedicationTypes, "MT_ID", "Description");
            return View();
        }

        // POST: Medications/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MedicationID,Description,MT_ID,IllnessTypeID")] Medication medication)
        {
            if (ModelState.IsValid)
            {
                db.Medications.Add(medication);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.IllnessTypeID = new SelectList(db.IllnessTypes, "IllnessTypeID", "Description", medication.IllnessTypeID);
            ViewBag.MT_ID = new SelectList(db.MedicationTypes, "MT_ID", "Description", medication.MT_ID);
            return View(medication);
        }

        // GET: Medications/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medication medication = db.Medications.Find(id);
            if (medication == null)
            {
                return HttpNotFound();
            }
            ViewBag.IllnessTypeID = new SelectList(db.IllnessTypes, "IllnessTypeID", "Description", medication.IllnessTypeID);
            ViewBag.MT_ID = new SelectList(db.MedicationTypes, "MT_ID", "Description", medication.MT_ID);
            return View(medication);
        }

        // POST: Medications/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MedicationID,Description,MT_ID,IllnessTypeID")] Medication medication)
        {
            if (ModelState.IsValid)
            {
                db.Entry(medication).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.IllnessTypeID = new SelectList(db.IllnessTypes, "IllnessTypeID", "Description", medication.IllnessTypeID);
            ViewBag.MT_ID = new SelectList(db.MedicationTypes, "MT_ID", "Description", medication.MT_ID);
            return View(medication);
        }

        // GET: Medications/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Medication medication = db.Medications.Find(id);
            if (medication == null)
            {
                return HttpNotFound();
            }
            return View(medication);
        }

        // POST: Medications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Medication medication = db.Medications.Find(id);
            db.Medications.Remove(medication);
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
