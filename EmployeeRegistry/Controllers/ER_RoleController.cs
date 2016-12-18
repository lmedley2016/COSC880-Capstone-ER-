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
    public class ER_RoleController : Controller
    {
        private EmployeeRegistryDBContext db = new EmployeeRegistryDBContext();

        // GET: lutER_Role
        public ActionResult Index()
        {
            return View(db.lutER_Role.ToList());
        }

        // GET: lutER_Role/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            lutER_Role lutER_Role = db.lutER_Role.Find(id);
            if (lutER_Role == null)
            {
                return HttpNotFound();
            }
            return View(lutER_Role);
        }

        // GET: lutER_Role/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: lutER_Role/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RoleId,RoleType")] lutER_Role lutER_Role)
        {
            if (ModelState.IsValid)
            {
                db.lutER_Role.Add(lutER_Role);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(lutER_Role);
        }

        // GET: lutER_Role/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            lutER_Role lutER_Role = db.lutER_Role.Find(id);
            if (lutER_Role == null)
            {
                return HttpNotFound();
            }
            return View(lutER_Role);
        }

        // POST: lutER_Role/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RoleId,RoleType")] lutER_Role lutER_Role)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lutER_Role).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lutER_Role);
        }

        // GET: lutER_Role/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            lutER_Role lutER_Role = db.lutER_Role.Find(id);
            if (lutER_Role == null)
            {
                return HttpNotFound();
            }
            return View(lutER_Role);
        }

        // POST: lutER_Role/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            lutER_Role lutER_Role = db.lutER_Role.Find(id);
            db.lutER_Role.Remove(lutER_Role);
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
