using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using GICCustomerApp.Models;

namespace GICCustomerApp.Controllers
{
    public class UsersInfoController : Controller
    {
        private LmsDbMyHclEntities db = new LmsDbMyHclEntities();

        // GET: UsersInfo
        public ActionResult Index()
        {
            var usersInfoes = db.UsersInfoes.Include(u => u.CompanyID);
            return View(usersInfoes.ToList());
        }

        // GET: UsersInfo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UsersInfo usersInfo = db.UsersInfoes.Find(id);
            if (usersInfo == null)
            {
                return HttpNotFound();
            }
            return View(usersInfo);
        }

        // GET: UsersInfo/Create
        public ActionResult Create()
        {
            ViewBag.CustomerId = new SelectList(db.CompanyIDs, "CompanyID1", "CustomerCode");
            return View();
        }

        // POST: UsersInfo/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UserID,UserName,UserEmailID,CreatedDate,CustomerId")] UsersInfo usersInfo)
        {
            if (ModelState.IsValid)
            {
                db.UsersInfoes.Add(usersInfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CustomerId = new SelectList(db.CompanyIDs, "CompanyID1", "CustomerCode", usersInfo.CustomerId);
            return View(usersInfo);
        }

        // GET: UsersInfo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UsersInfo usersInfo = db.UsersInfoes.Find(id);
            if (usersInfo == null)
            {
                return HttpNotFound();
            }
            ViewBag.CustomerId = new SelectList(db.CompanyIDs, "CompanyID1", "CustomerCode", usersInfo.CustomerId);
            return View(usersInfo);
        }

        // POST: UsersInfo/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserID,UserName,UserEmailID,CreatedDate,CustomerId")] UsersInfo usersInfo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usersInfo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CustomerId = new SelectList(db.CompanyIDs, "CompanyID1", "CustomerCode", usersInfo.CustomerId);
            return View(usersInfo);
        }

        // GET: UsersInfo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UsersInfo usersInfo = db.UsersInfoes.Find(id);
            if (usersInfo == null)
            {
                return HttpNotFound();
            }
            return View(usersInfo);
        }

        // POST: UsersInfo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UsersInfo usersInfo = db.UsersInfoes.Find(id);
            db.UsersInfoes.Remove(usersInfo);
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
