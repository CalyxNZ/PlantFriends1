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
    public class RelationshipsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Relationships
        public ActionResult Index(string plant, string search)
        {

            var relationships = db.Relationships.OrderBy(p => p.HostPlant.Name);

            //if (!String.IsNullOrEmpty(search))
            //{
            //    relationships = (IOrderedQueryable<Relationship>)relationships.Where(p => p.HostPlant.Name.Contains(search) || p.CompanionPlant.Name.Contains(search));
            //    ViewBag.Search = search;
            //}
            //var plants = relationships.OrderBy(p => p.CompanionPlant.Name).Select(p => p.CompanionPlant.Name).Distinct();

            //if (!String.IsNullOrEmpty(plant))
            //{
            //    plants = (IQueryable<string>)relationships.Where(p =>p.CompanionPlant.Name == plant);
            //}

            //ViewBag.Plants = new SelectList(plants);


            return View(relationships.ToList());
            //return View();

        }

        // GET: Relationships/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Relationship relationship = db.Relationships.Find(id);
            if (relationship == null)
            {
                return HttpNotFound();
            }
            return View(relationship);
        }

        // GET: Relationships/Create
        public ActionResult Create()
        {
            ViewBag.HostPlantId = new SelectList(db.Plants, "PlantId", "Name");
            ViewBag.CompanionPlantId = new SelectList(db.Plants, "PlantId", "Name");
            ViewBag.RelationshipTypeId = new SelectList(db.RelationshipTypes, "RelationshipTypeId", "RelationshipName");
            return View();
        }

        // POST: Relationships/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "RelationshipId,RelationshipTypeId,CompanionPlantId,HostPlantId")] Relationship relationship)
        {
            if (ModelState.IsValid)
            {
                db.Relationships.Add(relationship);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.HostPlantId = new SelectList(db.Plants, "PlantId", "Name", relationship.HostPlantId);
            ViewBag.CompanionPlantId = new SelectList(db.Plants, "PlantId", "Name", relationship.CompanionPlantId);
            ViewBag.RelationshipTypeId = new SelectList(db.RelationshipTypes, "RelationshipTypeId", "RelationshipName", relationship.RelationshipTypeId);
            return View(relationship);
        }

        // GET: Relationships/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Relationship relationship = db.Relationships.Find(id);
            if (relationship == null)
            {
                return HttpNotFound();
            }

            ViewBag.HostPlantId = new SelectList(db.Plants, "PlantId", "Name", relationship.HostPlantId);
            ViewBag.CompanionPlantId = new SelectList(db.Plants, "PlantId", "Name", relationship.CompanionPlantId);
            ViewBag.RelationshipTypeId = new SelectList(db.RelationshipTypes, "RelationshipTypeId", "RelationshipName", relationship.RelationshipTypeId);
            return View(relationship);
        }

        // POST: Relationships/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "RelationshipId,HostPlantId,CompanionPlantId,RelationshipTypeId")] Relationship relationship)
        {
            if (ModelState.IsValid)
            {
                db.Entry(relationship).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.HostPlantId = new SelectList(db.Plants, "PlantId", "Name", relationship.HostPlantId);
            ViewBag.CompanionPlantId = new SelectList(db.Plants, "PlantId", "Name", relationship.CompanionPlantId);
            ViewBag.RelationshipTypeId = new SelectList(db.RelationshipTypes, "RelationshipTypeId", "RelationshipName", relationship.RelationshipTypeId);
            return View(relationship);
        }

        // GET: Relationships/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Relationship relationship = db.Relationships.Find(id);
            if (relationship == null)
            {
                return HttpNotFound();
            }

            return View(relationship);
        }

        // POST: Relationships/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Relationship relationship = db.Relationships.Find(id);
            db.Relationships.Remove(relationship);
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
