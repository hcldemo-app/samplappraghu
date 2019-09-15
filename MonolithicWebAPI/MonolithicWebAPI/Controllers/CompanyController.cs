using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using MonolithicWebAPI.Models;

namespace MonolithicWebAPI.Controllers
{
    public class CompanyController : ApiController
    {
        private LmsDbMyHclEntities2 db = new LmsDbMyHclEntities2();

        // GET: api/Company
        public IQueryable<CompanyID> GetCompany()
        {
            return db.CompanyIDs;
        }

        // GET: api/Company/5
        [ResponseType(typeof(CompanyID))]
        public IHttpActionResult GetCompanyID(int id)
        {
            CompanyID companyID = db.CompanyIDs.Find(id);
            if (companyID == null)
            {
                return NotFound();
            }

            return Ok(companyID);
        }

        // PUT: api/Company/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCompanyID(int id, CompanyID companyID)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != companyID.CompanyID1)
            {
                return BadRequest();
            }

            db.Entry(companyID).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompanyIDExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Company
        [ResponseType(typeof(CompanyID))]
        public IHttpActionResult PostCompanyID(CompanyID companyID)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CompanyIDs.Add(companyID);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = companyID.CompanyID1 }, companyID);
        }

        // DELETE: api/Company/5
        [ResponseType(typeof(CompanyID))]
        public IHttpActionResult DeleteCompanyID(int id)
        {
            CompanyID companyID = db.CompanyIDs.Find(id);
            if (companyID == null)
            {
                return NotFound();
            }

            db.CompanyIDs.Remove(companyID);
            db.SaveChanges();

            return Ok(companyID);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CompanyIDExists(int id)
        {
            return db.CompanyIDs.Count(e => e.CompanyID1 == id) > 0;
        }
    }
}