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
    public class SymptomTypesController : Controller
    {
        private DiseaseDBEntities db = new DiseaseDBEntities();

        // GET: SymptomTypes
        public ActionResult Index()
        {
            return View(db.SymptomTypes.ToList());
        }

        // GET: SymptomTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SymptomType symptomType = db.SymptomTypes.Find(id);
            if (symptomType == null)
            {
                return HttpNotFound();
            }
            return View(symptomType);
        }

        // GET: SymptomTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SymptomTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SymptomTypeID,Description")] SymptomType symptomType)
        {
            if (ModelState.IsValid)
            {
                db.SymptomTypes.Add(symptomType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(symptomType);
        }

        // GET: SymptomTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SymptomType symptomType = db.SymptomTypes.Find(id);
            if (symptomType == null)
            {
                return HttpNotFound();
            }
            return View(symptomType);
        }

        // POST: SymptomTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SymptomTypeID,Description")] SymptomType symptomType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(symptomType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(symptomType);
        }

        // GET: SymptomTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SymptomType symptomType = db.SymptomTypes.Find(id);
            if (symptomType == null)
            {
                return HttpNotFound();
            }
            return View(symptomType);
        }

        // POST: SymptomTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SymptomType symptomType = db.SymptomTypes.Find(id);
            db.SymptomTypes.Remove(symptomType);
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
