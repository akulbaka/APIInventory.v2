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
using APIInventory.Data;
using APIInventory.Models;
using Microsoft.AspNet.Identity;

namespace APIInventory.Controllers
{
    [Authorize]
    public class ScansController : ApiController
    {
        private ScansContext db = new ScansContext();

        // GET: api/Scans
        public IQueryable<ScanModels> GetScanModels()
        {
            return db.ScanModels;
        }

        // GET: api/UserScans
        [Route("api/UserScans")]
        public IQueryable<ScanModels> GetUserScanModels()
        {
            string userId = User.Identity.GetUserId();

            return db.ScanModels.Where(scanModels => scanModels.UserId == userId);
        }

        // GET: api/Scans/5
        [ResponseType(typeof(ScanModels))]
        public IHttpActionResult GetScanModels(int id)
        {
            ScanModels scanModels = db.ScanModels.Find(id);
            if (scanModels == null)
            {
                return NotFound();
            }

            return Ok(scanModels);
        }

        // PUT: api/Scans/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutScanModels(int id, ScanModels scanModels)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != scanModels.Id)
            {
                return BadRequest();
            }

            db.Entry(scanModels).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ScanModelsExists(id))
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

        // POST: api/Scans
        [ResponseType(typeof(ScanModels))]
        public IHttpActionResult PostScanModels(ScanModels scanModels)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            string userId = User.Identity.GetUserId();
            scanModels.UserId = userId;

            db.ScanModels.Add(scanModels);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = scanModels.Id }, scanModels);
        }

        // DELETE: api/Scans/5
        [ResponseType(typeof(ScanModels))]
        public IHttpActionResult DeleteScanModels(int id)
        {
            ScanModels scanModels = db.ScanModels.Find(id);
            if (scanModels == null)
            {
                return NotFound();
            }

            db.ScanModels.Remove(scanModels);
            db.SaveChanges();

            return Ok(scanModels);
        }

        // GET: api/SearchScans/{keyword}
        [Route("api/SearchScans/{keyword}")]
        [HttpGet]
        public IQueryable<ScanModels> SearchScanModels(string keyword)
        {
            return db.ScanModels.Where(scan => scan.Code.Contains(keyword) || scan.Name.Contains(keyword));
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ScanModelsExists(int id)
        {
            return db.ScanModels.Count(e => e.Id == id) > 0;
        }
    }
}