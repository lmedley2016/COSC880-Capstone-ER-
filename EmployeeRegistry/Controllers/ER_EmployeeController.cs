using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EmployeeRegistry.Models;

namespace EmployeeRegistry.Controllers
{
    public class ER_EmployeeController : Controller
    {
        private EmployeeRegistryDBContext db = new EmployeeRegistryDBContext();


        // GET: Accomplishments
        public ActionResult Index(string sortOrder, string searchString)
        {

            //Receives sortOrder parameter from the query string in the URL. 
            //The query string value is provided by MVC as a parameter to the action method.
            //The parameter will be a string that's either "FirstName" or "LastName".
            //If optionally followed by an underscore and the string "desc" to specify descending order. 
            //The default sort order is ascending.

            //The first time the Index page is requested, there's no query string. 
            //The employees are displayed in ascending order by FirstName, which is the default as established by the fall-through case in the switch statement. 
            //When the user clicks a column heading hyperlink, the appropriate sortOrder value is provided in the query string.

            //The two ViewBag variables are used so that the view can configure the column heading hyperlinks with the appropriate query string values:
            ViewBag.LastNameSortParm = String.IsNullOrEmpty(sortOrder) ? "LastName" : "";
            ViewBag.FirstNameSortParm = sortOrder == "FirstName" ? "First Name" : "FirstName";

            //The method uses LINQ to Entities to specify the column to sort by.
            //The code creates an IQueryable variable before the switch statement, modifies it in the switch statement, and calls the ToList method after the switch statement.
            //When you create and modify IQueryable variables, no query is sent to the database.
            //The query is not executed until you convert the IQueryable object into a collection by calling a method such as ToList.
            //Therefore, this code results in a single query that is not executed until the return View statement.

            var tblER_Employee = from model in db.tblER_Employee.Include(t => t.lutER_Branch).Include(t => t.lutER_Directorate).Include(t => t.lutER_Division).Include(t => t.lutER_Location).Include(t => t.lutER_Organization).Include(t => t.lutER_Role).Include(t => t.lutWAR_Projects) select model;

            //FOR SEARCH BOX:
            //searchString parameter added to the Index method. 
            //LINQ statement added a where clausethat selects only projects that are contained the search string. 
            //The search string value is received from a text box that you'll add to the Index view. 
            //The statement that adds the where clause is executed only if there's a value to search for.
            if (!String.IsNullOrEmpty(searchString))
            {
                tblER_Employee = tblER_Employee.Where(model => model.LastName.ToUpper().Contains(searchString.ToUpper()));
            }
            switch (sortOrder)
            {
                case "LastName":
                    tblER_Employee = tblER_Employee.OrderBy(model => model.LastName);
                    break;
                case "FirstName":
                    tblER_Employee = tblER_Employee.OrderBy(model => model.FirstName);
                    break;
                case "BranchName":
                    tblER_Employee = tblER_Employee.OrderBy(model => model.lutER_Branch.BranchName);
                    break;
                case "Role":
                    tblER_Employee = tblER_Employee.OrderBy(model => model.lutER_Role.RoleType);
                    break;
                case "Organization":
                    tblER_Employee = tblER_Employee.OrderBy(model => model.lutER_Organization.OrganizationalName);
                    break;
                
                default:
                    tblER_Employee = tblER_Employee.OrderBy(model => model.LastName);
                    break;
            }
            return View(tblER_Employee.ToList());
        }

        // GET: tblER_Employee
        //public ActionResult Index()
        //{
            //var tblER_Employee = db.tblER_Employee.Include(t => t.lutER_Branch).Include(t => t.lutER_Directorate).Include(t => t.lutER_Division).Include(t => t.lutER_Location).Include(t => t.lutER_Organization).Include(t => t.lutER_Role).Include(t => t.lutWAR_Projects);
            //return View(tblER_Employee.ToList());
        //}

        // GET: tblER_Employee/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblER_Employee tblER_Employee = db.tblER_Employee.Find(id);
            if (tblER_Employee == null)
            {
                return HttpNotFound();
            }
            return View(tblER_Employee);
        }

        // GET: tblER_Employee/Create
        public ActionResult Create()
        {
            ViewBag.BranchId = new SelectList(db.lutER_Branch, "BranchId", "BranchName");
            ViewBag.DirectorateId = new SelectList(db.lutER_Directorate, "DirectorateId", "DirectorateName");
            ViewBag.DivisionId = new SelectList(db.lutER_Division, "DivisionId", "DivisionName");
            ViewBag.LocationId = new SelectList(db.lutER_Location, "LocationId", "LocationName");
            ViewBag.OrganizationalId = new SelectList(db.lutER_Organization, "OrganizationalId", "OrganizationalName");
            ViewBag.RoleId = new SelectList(db.lutER_Role, "RoleId", "RoleType");
            ViewBag.ProjId = new SelectList(db.lutWAR_Projects, "ProjId", "ProjectName");
            return View();
        }

        // POST: tblER_Employee/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "EmpId,RoleId,DirectorateId,DivisionId,LocationId,OrganizationalId,BranchId,ProjId,FirstName,LastName,EmailAddress,EmpArchive,Matrixed")] tblER_Employee tblER_Employee)
        {
            if (ModelState.IsValid)
            {
                db.tblER_Employee.Add(tblER_Employee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.BranchId = new SelectList(db.lutER_Branch, "BranchId", "BranchName", tblER_Employee.BranchId);
            ViewBag.DirectorateId = new SelectList(db.lutER_Directorate, "DirectorateId", "DirectorateName", tblER_Employee.DirectorateId);
            ViewBag.DivisionId = new SelectList(db.lutER_Division, "DivisionId", "DivisionName", tblER_Employee.DivisionId);
            ViewBag.LocationId = new SelectList(db.lutER_Location, "LocationId", "LocationName", tblER_Employee.LocationId);
            ViewBag.OrganizationalId = new SelectList(db.lutER_Organization, "OrganizationalId", "OrganizationalName", tblER_Employee.OrganizationalId);
            ViewBag.RoleId = new SelectList(db.lutER_Role, "RoleId", "RoleType", tblER_Employee.RoleId);
            ViewBag.ProjId = new SelectList(db.lutWAR_Projects, "ProjId", "ProjectName", tblER_Employee.ProjId);
            return View(tblER_Employee);
        }

        // GET: tblER_Employee/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblER_Employee tblER_Employee = db.tblER_Employee.Find(id);
            if (tblER_Employee == null)
            {
                return HttpNotFound();
            }
            ViewBag.BranchId = new SelectList(db.lutER_Branch, "BranchId", "BranchName", tblER_Employee.BranchId);
            ViewBag.DirectorateId = new SelectList(db.lutER_Directorate, "DirectorateId", "DirectorateName", tblER_Employee.DirectorateId);
            ViewBag.DivisionId = new SelectList(db.lutER_Division, "DivisionId", "DivisionName", tblER_Employee.DivisionId);
            ViewBag.LocationId = new SelectList(db.lutER_Location, "LocationId", "LocationName", tblER_Employee.LocationId);
            ViewBag.OrganizationalId = new SelectList(db.lutER_Organization, "OrganizationalId", "OrganizationalName", tblER_Employee.OrganizationalId);
            ViewBag.RoleId = new SelectList(db.lutER_Role, "RoleId", "RoleType", tblER_Employee.RoleId);
            ViewBag.ProjId = new SelectList(db.lutWAR_Projects, "ProjId", "ProjectName", tblER_Employee.ProjId);
            return View(tblER_Employee);
        }

        // POST: tblER_Employee/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "EmpId,RoleId,DirectorateId,DivisionId,LocationId,OrganizationalId,BranchId,ProjId,FirstName,LastName,EmailAddress,EmpArchive,Matrixed")] tblER_Employee tblER_Employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tblER_Employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.BranchId = new SelectList(db.lutER_Branch, "BranchId", "BranchName", tblER_Employee.BranchId);
            ViewBag.DirectorateId = new SelectList(db.lutER_Directorate, "DirectorateId", "DirectorateName", tblER_Employee.DirectorateId);
            ViewBag.DivisionId = new SelectList(db.lutER_Division, "DivisionId", "DivisionName", tblER_Employee.DivisionId);
            ViewBag.LocationId = new SelectList(db.lutER_Location, "LocationId", "LocationName", tblER_Employee.LocationId);
            ViewBag.OrganizationalId = new SelectList(db.lutER_Organization, "OrganizationalId", "OrganizationalName", tblER_Employee.OrganizationalId);
            ViewBag.RoleId = new SelectList(db.lutER_Role, "RoleId", "RoleType", tblER_Employee.RoleId);
            ViewBag.ProjId = new SelectList(db.lutWAR_Projects, "ProjId", "ProjectName", tblER_Employee.ProjId);
            return View(tblER_Employee);
        }

        // GET: tblER_Employee/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tblER_Employee tblER_Employee = db.tblER_Employee.Find(id);
            if (tblER_Employee == null)
            {
                return HttpNotFound();
            }
            return View(tblER_Employee);
        }

        // POST: tblER_Employee/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tblER_Employee tblER_Employee = db.tblER_Employee.Find(id);
            db.tblER_Employee.Remove(tblER_Employee);
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
