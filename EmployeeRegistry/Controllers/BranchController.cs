﻿using System;
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
    public class BranchController : Controller
    {
        private EmployeeRegistryDBContext db = new EmployeeRegistryDBContext();

        // GET: lutER_Branch
        public ActionResult Index()
        {
            return View(db.lutER_Branch.ToList());
        }

        // GET: lutER_Branch/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            lutER_Branch lutER_Branch = db.lutER_Branch.Find(id);
            if (lutER_Branch == null)
            {
                return HttpNotFound();
            }
            return View(lutER_Branch);
        }

        // GET: lutER_Branch/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: lutER_Branch/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BranchId,BranchName")] lutER_Branch lutER_Branch)
        {
            if (ModelState.IsValid)
            {
                db.lutER_Branch.Add(lutER_Branch);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(lutER_Branch);
        }

        // GET: lutER_Branch/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            lutER_Branch lutER_Branch = db.lutER_Branch.Find(id);
            if (lutER_Branch == null)
            {
                return HttpNotFound();
            }
            return View(lutER_Branch);
        }

        // POST: lutER_Branch/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BranchId,BranchName")] lutER_Branch lutER_Branch)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lutER_Branch).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lutER_Branch);
        }

        // GET: lutER_Branch/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            lutER_Branch lutER_Branch = db.lutER_Branch.Find(id);
            if (lutER_Branch == null)
            {
                return HttpNotFound();
            }
            return View(lutER_Branch);
        }

        // POST: lutER_Branch/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            lutER_Branch lutER_Branch = db.lutER_Branch.Find(id);
            db.lutER_Branch.Remove(lutER_Branch);
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
