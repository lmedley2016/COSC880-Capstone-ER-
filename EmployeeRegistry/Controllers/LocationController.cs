using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EmployeeRegistry.Models;

namespace EmployeeRegistry.Controllers
{
    public class LocationController : Controller
    {
        private EmployeeRegistryDBContext db = new EmployeeRegistryDBContext();

        // GET: lutER_Location
        public ActionResult Index()
        {
            return View(db.lutER_Location.ToList());
        }

        // GET: lutER_Location/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            lutER_Location lutER_Location = db.lutER_Location.Find(id);
            if (lutER_Location == null)
            {
                return HttpNotFound();
            }
            return View(lutER_Location);
        }

        // GET: lutER_Location/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: lutER_Location/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LocationId,LocationName")] lutER_Location lutER_Location)
        {
            if (ModelState.IsValid)
            {
                db.lutER_Location.Add(lutER_Location);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(lutER_Location);
        }

        // GET: lutER_Location/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            lutER_Location lutER_Location = db.lutER_Location.Find(id);
            if (lutER_Location == null)
            {
                return HttpNotFound();
            }
            return View(lutER_Location);
        }

        // POST: lutER_Location/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LocationId,LocationName")] lutER_Location lutER_Location)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lutER_Location).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lutER_Location);
        }

        // GET: lutER_Location/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            lutER_Location lutER_Location = db.lutER_Location.Find(id);
            if (lutER_Location == null)
            {
                return HttpNotFound();
            }
            return View(lutER_Location);
        }

        // POST: lutER_Location/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            lutER_Location lutER_Location = db.lutER_Location.Find(id);
            db.lutER_Location.Remove(lutER_Location);
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
