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
    public class RiskFactorsController : Controller
    {
        private DiseaseDBEntities db = new DiseaseDBEntities();

        // GET: RiskFactors
        public ActionResult Index()
        {
            var riskFactors = db.RiskFactors.Include(r => r.RiskFactorType);
            return View(riskFactors.ToList());
        }

        // GET: RiskFactors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RiskFactor riskFactor = db.RiskFactors.Find(id);
            if (riskFactor == null)
            {
                return HttpNotFound();
            }
            return View(riskFactor);
        }

        // GET: RiskFactors/Create
        public ActionResult Create()
        {
            ViewBag.RFT_ID = new SelectList(db.RiskFactorTypes, "RFT_ID", "Description");
            return View();
        }

        // POST: RiskFactors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RF_ID,Description,RFT_ID")] RiskFactor riskFactor)
        {
            if (ModelState.IsValid)
            {
                db.RiskFactors.Add(riskFactor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.RFT_ID = new SelectList(db.RiskFactorTypes, "RFT_ID", "Description", riskFactor.RFT_ID);
            return View(riskFactor);
        }

        // GET: RiskFactors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RiskFactor riskFactor = db.RiskFactors.Find(id);
            if (riskFactor == null)
            {
                return HttpNotFound();
            }
            ViewBag.RFT_ID = new SelectList(db.RiskFactorTypes, "RFT_ID", "Description", riskFactor.RFT_ID);
            return View(riskFactor);
        }

        // POST: RiskFactors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RF_ID,Description,RFT_ID")] RiskFactor riskFactor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(riskFactor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.RFT_ID = new SelectList(db.RiskFactorTypes, "RFT_ID", "Description", riskFactor.RFT_ID);
            return View(riskFactor);
        }

        // GET: RiskFactors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RiskFactor riskFactor = db.RiskFactors.Find(id);
            if (riskFactor == null)
            {
                return HttpNotFound();
            }
            return View(riskFactor);
        }

        // POST: RiskFactors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RiskFactor riskFactor = db.RiskFactors.Find(id);
            db.RiskFactors.Remove(riskFactor);
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
