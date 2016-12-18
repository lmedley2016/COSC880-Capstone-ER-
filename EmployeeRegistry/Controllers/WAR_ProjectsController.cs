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
    public class WAR_ProjectsController : Controller
    {
        private EmployeeRegistryDBContext db = new EmployeeRegistryDBContext();

        // GET: lutWAR_Projects
        public ActionResult Index()
        {
            return View(db.lutWAR_Projects.ToList());
        }

        // GET: lutWAR_Projects/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            lutWAR_Projects lutWAR_Projects = db.lutWAR_Projects.Find(id);
            if (lutWAR_Projects == null)
            {
                return HttpNotFound();
            }
            return View(lutWAR_Projects);
        }

        // GET: lutWAR_Projects/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: lutWAR_Projects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProjId,ProjectName")] lutWAR_Projects lutWAR_Projects)
        {
            if (ModelState.IsValid)
            {
                db.lutWAR_Projects.Add(lutWAR_Projects);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(lutWAR_Projects);
        }

        // GET: lutWAR_Projects/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            lutWAR_Projects lutWAR_Projects = db.lutWAR_Projects.Find(id);
            if (lutWAR_Projects == null)
            {
                return HttpNotFound();
            }
            return View(lutWAR_Projects);
        }

        // POST: lutWAR_Projects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProjId,ProjectName")] lutWAR_Projects lutWAR_Projects)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lutWAR_Projects).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lutWAR_Projects);
        }

        // GET: lutWAR_Projects/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            lutWAR_Projects lutWAR_Projects = db.lutWAR_Projects.Find(id);
            if (lutWAR_Projects == null)
            {
                return HttpNotFound();
            }
            return View(lutWAR_Projects);
        }

        // POST: lutWAR_Projects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            lutWAR_Projects lutWAR_Projects = db.lutWAR_Projects.Find(id);
            db.lutWAR_Projects.Remove(lutWAR_Projects);
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
