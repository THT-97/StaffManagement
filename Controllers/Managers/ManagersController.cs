using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using StaffManagement.Models;

namespace StaffManagement.Controllers
{
    public class ManagersController : Controller
    {
        private StaffManagementEntities1 db = new StaffManagementEntities1();

        // GET: Managers
        public ActionResult Index()
        {
            if (Session["RoleID"] != null && Session["RoleID"].ToString() == "3")
            {
                var managers = db.Managers.Include(m => m.Account).Include(m => m.Role);
                return View(managers.ToList());
            }
            else return RedirectToAction("Index", "Home", null);
        }

        // GET: Managers/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Manager manager = db.Managers.Find(id);
            if (manager == null)
            {
                return HttpNotFound();
            }
            return View(manager);
        }

        // GET: Managers/Create
        public ActionResult Create()
        {
            ViewBag.AccountID = new SelectList(db.Accounts, "ID", "Username");
            ViewBag.Role_ID = new SelectList(db.Roles, "Role_ID", "Role_Name");
            return View();
        }

        // POST: Managers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Staff_ID,Staff_Name,DoB,Phone,Email,Pic,CV,Status,Datehired,Dateleft,AccountID,Role_ID")] Manager manager)
        {
            if (ModelState.IsValid)
            {
                db.Managers.Add(manager);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AccountID = new SelectList(db.Accounts, "ID", "Username", manager.AccountID);
            ViewBag.Role_ID = new SelectList(db.Roles, "Role_ID", "Role_Name", manager.Role_ID);
            return View(manager);
        }

        // GET: Managers/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Manager manager = db.Managers.Find(id);
            if (manager == null)
            {
                return HttpNotFound();
            }
            ViewBag.AccountID = new SelectList(db.Accounts, "ID", "Username", manager.AccountID);
            ViewBag.Role_ID = new SelectList(db.Roles, "Role_ID", "Role_Name", manager.Role_ID);
            return View(manager);
        }

        // POST: Managers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Staff_ID,Staff_Name,DoB,Phone,Email,Pic,CV,Status,Datehired,Dateleft,AccountID,Role_ID")] Manager manager)
        {
            if (ModelState.IsValid)
            {
                db.Entry(manager).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AccountID = new SelectList(db.Accounts, "ID", "Username", manager.AccountID);
            ViewBag.Role_ID = new SelectList(db.Roles, "Role_ID", "Role_Name", manager.Role_ID);
            return View(manager);
        }

        // GET: Managers/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Manager manager = db.Managers.Find(id);
            if (manager == null)
            {
                return HttpNotFound();
            }
            return View(manager);
        }

        // POST: Managers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Manager manager = db.Managers.Find(id);
            db.Managers.Remove(manager);
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
