using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PlantFriends1.Models;

namespace PlantFriends1.Controllers
{
    public class RelationshipTypesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: RelationshipTypes
        public ActionResult Index()
        {
            return View(db.RelationshipTypes.OrderBy(m => m.RelationshipName).ToList());
        }

        // GET: RelationshipTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RelationshipType relationshipType = db.RelationshipTypes.Find(id);
            if (relationshipType == null)
            {
                return HttpNotFound();
            }
            return View(relationshipType);
        }

        // GET: RelationshipTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RelationshipTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RelationshipTypeId,RelationshipName,Description")] RelationshipType relationshipType)
        {
            if (ModelState.IsValid)
            {
                db.RelationshipTypes.Add(relationshipType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(relationshipType);
        }

        // GET: RelationshipTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RelationshipType relationshipType = db.RelationshipTypes.Find(id);
            if (relationshipType == null)
            {
                return HttpNotFound();
            }
            return View(relationshipType);
        }

        // POST: RelationshipTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RelationshipTypeId,RelationshipName,Description")] RelationshipType relationshipType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(relationshipType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(relationshipType);
        }

        // GET: RelationshipTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            RelationshipType relationshipType = db.RelationshipTypes.Find(id);
            if (relationshipType == null)
            {
                return HttpNotFound();
            }
            return View(relationshipType);
        }

        // POST: RelationshipTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            RelationshipType relationshipType = db.RelationshipTypes.Find(id);
            db.RelationshipTypes.Remove(relationshipType);
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
