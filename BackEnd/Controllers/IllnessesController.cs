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
    public class IllnessesController : Controller
    {
        private DiseaseDBEntities db = new DiseaseDBEntities();

        // GET: Illnesses
        public ActionResult Index()
        {
            var illnesses = db.Illnesses.Include(i => i.AdditionalInfo).Include(i => i.IllnessType).Include(i => i.RiskFactor).Include(i => i.Treatment);
            return View(illnesses.ToList());
        }

        // GET: Illnesses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Illness illness = db.Illnesses.Find(id);
            if (illness == null)
            {
                return HttpNotFound();
            }
            return View(illness);
        }

        // GET: Illnesses/Create
        public ActionResult Create()
        {
            ViewBag.AdditionalInfoID = new SelectList(db.AdditionalInfoes, "AdditionalInfoID", "Description");
            ViewBag.IllnessTypeID = new SelectList(db.IllnessTypes, "IllnessTypeID", "Description");
            ViewBag.RF_ID = new SelectList(db.RiskFactors, "RF_ID", "Description");
            ViewBag.TreatmentID = new SelectList(db.Treatments, "TreatmentID", "Description");
            return View();
        }

        // POST: Illnesses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IllnessID,RF_ID,IllnessTypeID,TreatmentID,AdditionalInfoID")] Illness illness)
        {
            if (ModelState.IsValid)
            {
                db.Illnesses.Add(illness);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AdditionalInfoID = new SelectList(db.AdditionalInfoes, "AdditionalInfoID", "Description", illness.AdditionalInfoID);
            ViewBag.IllnessTypeID = new SelectList(db.IllnessTypes, "IllnessTypeID", "Description", illness.IllnessTypeID);
            ViewBag.RF_ID = new SelectList(db.RiskFactors, "RF_ID", "Description", illness.RF_ID);
            ViewBag.TreatmentID = new SelectList(db.Treatments, "TreatmentID", "Description", illness.TreatmentID);
            return View(illness);
        }

        // GET: Illnesses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Illness illness = db.Illnesses.Find(id);
            if (illness == null)
            {
                return HttpNotFound();
            }
            ViewBag.AdditionalInfoID = new SelectList(db.AdditionalInfoes, "AdditionalInfoID", "Description", illness.AdditionalInfoID);
            ViewBag.IllnessTypeID = new SelectList(db.IllnessTypes, "IllnessTypeID", "Description", illness.IllnessTypeID);
            ViewBag.RF_ID = new SelectList(db.RiskFactors, "RF_ID", "Description", illness.RF_ID);
            ViewBag.TreatmentID = new SelectList(db.Treatments, "TreatmentID", "Description", illness.TreatmentID);
            return View(illness);
        }

        // POST: Illnesses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IllnessID,RF_ID,IllnessTypeID,TreatmentID,AdditionalInfoID")] Illness illness)
        {
            if (ModelState.IsValid)
            {
                db.Entry(illness).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AdditionalInfoID = new SelectList(db.AdditionalInfoes, "AdditionalInfoID", "Description", illness.AdditionalInfoID);
            ViewBag.IllnessTypeID = new SelectList(db.IllnessTypes, "IllnessTypeID", "Description", illness.IllnessTypeID);
            ViewBag.RF_ID = new SelectList(db.RiskFactors, "RF_ID", "Description", illness.RF_ID);
            ViewBag.TreatmentID = new SelectList(db.Treatments, "TreatmentID", "Description", illness.TreatmentID);
            return View(illness);
        }

        // GET: Illnesses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Illness illness = db.Illnesses.Find(id);
            if (illness == null)
            {
                return HttpNotFound();
            }
            return View(illness);
        }

        // POST: Illnesses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Illness illness = db.Illnesses.Find(id);
            db.Illnesses.Remove(illness);
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
