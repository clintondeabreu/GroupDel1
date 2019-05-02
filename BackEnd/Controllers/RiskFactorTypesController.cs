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
    public class RiskFactorTypesController : Controller
    {
        private DiseaseDBEntities db = new DiseaseDBEntities();

        // GET: RiskFactorTypes
        public ActionResult Index()
        {
            return View(db.RiskFactorTypes.ToList());
        }

        // GET: RiskFactorTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RiskFactorType riskFactorType = db.RiskFactorTypes.Find(id);
            if (riskFactorType == null)
            {
                return HttpNotFound();
            }
            return View(riskFactorType);
        }

        // GET: RiskFactorTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RiskFactorTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RFT_ID,Description")] RiskFactorType riskFactorType)
        {
            if (ModelState.IsValid)
            {
                db.RiskFactorTypes.Add(riskFactorType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(riskFactorType);
        }

        // GET: RiskFactorTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RiskFactorType riskFactorType = db.RiskFactorTypes.Find(id);
            if (riskFactorType == null)
            {
                return HttpNotFound();
            }
            return View(riskFactorType);
        }

        // POST: RiskFactorTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RFT_ID,Description")] RiskFactorType riskFactorType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(riskFactorType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(riskFactorType);
        }

        // GET: RiskFactorTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RiskFactorType riskFactorType = db.RiskFactorTypes.Find(id);
            if (riskFactorType == null)
            {
                return HttpNotFound();
            }
            return View(riskFactorType);
        }

        // POST: RiskFactorTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RiskFactorType riskFactorType = db.RiskFactorTypes.Find(id);
            db.RiskFactorTypes.Remove(riskFactorType);
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
