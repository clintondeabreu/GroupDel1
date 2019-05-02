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
    public class MedicationTypesController : Controller
    {
        private DiseaseDBEntities db = new DiseaseDBEntities();

        // GET: MedicationTypes
        public ActionResult Index()
        {
            return View(db.MedicationTypes.ToList());
        }

        // GET: MedicationTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MedicationType medicationType = db.MedicationTypes.Find(id);
            if (medicationType == null)
            {
                return HttpNotFound();
            }
            return View(medicationType);
        }

        // GET: MedicationTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MedicationTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "MT_ID,Description")] MedicationType medicationType)
        {
            if (ModelState.IsValid)
            {
                db.MedicationTypes.Add(medicationType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(medicationType);
        }

        // GET: MedicationTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MedicationType medicationType = db.MedicationTypes.Find(id);
            if (medicationType == null)
            {
                return HttpNotFound();
            }
            return View(medicationType);
        }

        // POST: MedicationTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "MT_ID,Description")] MedicationType medicationType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(medicationType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(medicationType);
        }

        // GET: MedicationTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            MedicationType medicationType = db.MedicationTypes.Find(id);
            if (medicationType == null)
            {
                return HttpNotFound();
            }
            return View(medicationType);
        }

        // POST: MedicationTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MedicationType medicationType = db.MedicationTypes.Find(id);
            db.MedicationTypes.Remove(medicationType);
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
