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
    public class DirectorateController : Controller
    {
        private EmployeeRegistryDBContext db = new EmployeeRegistryDBContext();

        // GET: lutER_Directorate
        public ActionResult Index()
        {
            return View(db.lutER_Directorate.ToList());
        }

        // GET: lutER_Directorate/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            lutER_Directorate lutER_Directorate = db.lutER_Directorate.Find(id);
            if (lutER_Directorate == null)
            {
                return HttpNotFound();
            }
            return View(lutER_Directorate);
        }

        // GET: lutER_Directorate/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: lutER_Directorate/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DirectorateId,DirectorateName")] lutER_Directorate lutER_Directorate)
        {
            if (ModelState.IsValid)
            {
                db.lutER_Directorate.Add(lutER_Directorate);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(lutER_Directorate);
        }

        // GET: lutER_Directorate/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            lutER_Directorate lutER_Directorate = db.lutER_Directorate.Find(id);
            if (lutER_Directorate == null)
            {
                return HttpNotFound();
            }
            return View(lutER_Directorate);
        }

        // POST: lutER_Directorate/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DirectorateId,DirectorateName")] lutER_Directorate lutER_Directorate)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lutER_Directorate).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lutER_Directorate);
        }

        // GET: lutER_Directorate/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            lutER_Directorate lutER_Directorate = db.lutER_Directorate.Find(id);
            if (lutER_Directorate == null)
            {
                return HttpNotFound();
            }
            return View(lutER_Directorate);
        }

        // POST: lutER_Directorate/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            lutER_Directorate lutER_Directorate = db.lutER_Directorate.Find(id);
            db.lutER_Directorate.Remove(lutER_Directorate);
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
