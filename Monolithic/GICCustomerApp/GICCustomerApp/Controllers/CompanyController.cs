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
    public class CompanyController : Controller
    {
        private LmsDbMyHclEntities db = new LmsDbMyHclEntities();

        // GET: Company
        public ActionResult Index()
        {
            return View(db.CompanyIDs.ToList());
        }

        // GET: Company/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyID companyID = db.CompanyIDs.Find(id);
            if (companyID == null)
            {
                return HttpNotFound();
            }
            return View(companyID);
        }

        // GET: Company/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Company/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CompanyID1,CustomerCode,CompanyName,ContactName,ContactTitle,Address,City,RegionState,PostalCode,Country,PhoneNumber")] CompanyID companyID)
        {
            if (ModelState.IsValid)
            {
                db.CompanyIDs.Add(companyID);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(companyID);
        }

        // GET: Company/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyID companyID = db.CompanyIDs.Find(id);
            if (companyID == null)
            {
                return HttpNotFound();
            }
            return View(companyID);
        }

        // POST: Company/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CompanyID1,CustomerCode,CompanyName,ContactName,ContactTitle,Address,City,RegionState,PostalCode,Country,PhoneNumber")] CompanyID companyID)
        {
            if (ModelState.IsValid)
            {
                db.Entry(companyID).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(companyID);
        }

        // GET: Company/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CompanyID companyID = db.CompanyIDs.Find(id);
            if (companyID == null)
            {
                return HttpNotFound();
            }
            return View(companyID);
        }

        // POST: Company/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CompanyID companyID = db.CompanyIDs.Find(id);
            db.CompanyIDs.Remove(companyID);
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
