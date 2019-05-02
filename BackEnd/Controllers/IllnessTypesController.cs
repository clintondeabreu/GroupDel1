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
    public class IllnessTypesController : Controller
    {
        private DiseaseDBEntities db = new DiseaseDBEntities();

        // GET: IllnessTypes
        public ActionResult Index()
        {
            return View(db.IllnessTypes.ToList());
        }

        // GET: IllnessTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IllnessType illnessType = db.IllnessTypes.Find(id);
            if (illnessType == null)
            {
                return HttpNotFound();
            }
            return View(illnessType);
        }

        // GET: IllnessTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: IllnessTypes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IllnessTypeID,Description")] IllnessType illnessType)
        {
            if (ModelState.IsValid)
            {
                db.IllnessTypes.Add(illnessType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(illnessType);
        }

        // GET: IllnessTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IllnessType illnessType = db.IllnessTypes.Find(id);
            if (illnessType == null)
            {
                return HttpNotFound();
            }
            return View(illnessType);
        }

        // POST: IllnessTypes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IllnessTypeID,Description")] IllnessType illnessType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(illnessType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(illnessType);
        }

        // GET: IllnessTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IllnessType illnessType = db.IllnessTypes.Find(id);
            if (illnessType == null)
            {
                return HttpNotFound();
            }
            return View(illnessType);
        }

        // POST: IllnessTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            IllnessType illnessType = db.IllnessTypes.Find(id);
            db.IllnessTypes.Remove(illnessType);
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
