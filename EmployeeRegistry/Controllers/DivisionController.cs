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
    public class DivisionController : Controller
    {
        private EmployeeRegistryDBContext db = new EmployeeRegistryDBContext();

        // GET: lutER_Division
        public ActionResult Index()
        {
            return View(db.lutER_Division.ToList());
        }

        // GET: lutER_Division/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            lutER_Division lutER_Division = db.lutER_Division.Find(id);
            if (lutER_Division == null)
            {
                return HttpNotFound();
            }
            return View(lutER_Division);
        }

        // GET: lutER_Division/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: lutER_Division/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DivisionId,DivisionName")] lutER_Division lutER_Division)
        {
            if (ModelState.IsValid)
            {
                db.lutER_Division.Add(lutER_Division);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(lutER_Division);
        }

        // GET: lutER_Division/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            lutER_Division lutER_Division = db.lutER_Division.Find(id);
            if (lutER_Division == null)
            {
                return HttpNotFound();
            }
            return View(lutER_Division);
        }

        // POST: lutER_Division/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DivisionId,DivisionName")] lutER_Division lutER_Division)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lutER_Division).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lutER_Division);
        }

        // GET: lutER_Division/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            lutER_Division lutER_Division = db.lutER_Division.Find(id);
            if (lutER_Division == null)
            {
                return HttpNotFound();
            }
            return View(lutER_Division);
        }

        // POST: lutER_Division/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            lutER_Division lutER_Division = db.lutER_Division.Find(id);
            db.lutER_Division.Remove(lutER_Division);
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
