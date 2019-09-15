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
    public class UsersInfoController : ApiController
    {
        private LmsDbMyHclEntities2 db = new LmsDbMyHclEntities2();

        // GET: api/UsersInfo
        public IQueryable<UsersInfo> GetUsersInfoes()
        {
            return db.UsersInfoes;
        }

        // GET: api/UsersInfo/5
        [ResponseType(typeof(UsersInfo))]
        public IHttpActionResult GetUsersInfo(int id)
        {
            UsersInfo usersInfo = db.UsersInfoes.Find(id);
            if (usersInfo == null)
            {
                return NotFound();
            }

            return Ok(usersInfo);
        }

        // PUT: api/UsersInfo/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutUsersInfo(int id, UsersInfo usersInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != usersInfo.UserID)
            {
                return BadRequest();
            }

            db.Entry(usersInfo).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsersInfoExists(id))
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

        // POST: api/UsersInfo
        [ResponseType(typeof(UsersInfo))]
        public IHttpActionResult PostUsersInfo(UsersInfo usersInfo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.UsersInfoes.Add(usersInfo);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = usersInfo.UserID }, usersInfo);
        }

        // DELETE: api/UsersInfo/5
        [ResponseType(typeof(UsersInfo))]
        public IHttpActionResult DeleteUsersInfo(int id)
        {
            UsersInfo usersInfo = db.UsersInfoes.Find(id);
            if (usersInfo == null)
            {
                return NotFound();
            }

            db.UsersInfoes.Remove(usersInfo);
            db.SaveChanges();

            return Ok(usersInfo);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool UsersInfoExists(int id)
        {
            return db.UsersInfoes.Count(e => e.UserID == id) > 0;
        }
    }
}