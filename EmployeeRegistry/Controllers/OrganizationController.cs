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
    public class OrganizationController : Controller
    {
        private EmployeeRegistryDBContext db = new EmployeeRegistryDBContext();

        // GET: lutER_Organization
        public ActionResult Index()
        {
            return View(db.lutER_Organization.ToList());
        }

        // GET: lutER_Organization/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            lutER_Organization lutER_Organization = db.lutER_Organization.Find(id);
            if (lutER_Organization == null)
            {
                return HttpNotFound();
            }
            return View(lutER_Organization);
        }

        // GET: lutER_Organization/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: lutER_Organization/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "OrganizationalId,OrganizationalName")] lutER_Organization lutER_Organization)
        {
            if (ModelState.IsValid)
            {
                db.lutER_Organization.Add(lutER_Organization);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(lutER_Organization);
        }

        // GET: lutER_Organization/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            lutER_Organization lutER_Organization = db.lutER_Organization.Find(id);
            if (lutER_Organization == null)
            {
                return HttpNotFound();
            }
            return View(lutER_Organization);
        }

        // POST: lutER_Organization/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "OrganizationalId,OrganizationalName")] lutER_Organization lutER_Organization)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lutER_Organization).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lutER_Organization);
        }

        // GET: lutER_Organization/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            lutER_Organization lutER_Organization = db.lutER_Organization.Find(id);
            if (lutER_Organization == null)
            {
                return HttpNotFound();
            }
            return View(lutER_Organization);
        }

        // POST: lutER_Organization/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            lutER_Organization lutER_Organization = db.lutER_Organization.Find(id);
            db.lutER_Organization.Remove(lutER_Organization);
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
