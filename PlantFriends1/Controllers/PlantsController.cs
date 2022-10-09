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
    public class PlantsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Plants
        public ActionResult Index(string category, string search)
        {
            var plants = db.Plants.Include(p => p.Category);

            if (!String.IsNullOrEmpty(search))
            {
                plants = plants.Where(p => p.Category.Name.Contains(search) ||
                p.Name.Contains(search));
                ViewBag.Search = search;
            }
            var categories = plants.OrderBy(p => p.Category.Name).Select(p => p.Category.Name).Distinct();

            if (!String.IsNullOrEmpty(category))
            {
                plants = plants.Where(p => p.Category.Name == category);
            }

            ViewBag.Category = new SelectList(categories);
            return View(plants.ToList());

            //return View(db.Plants.OrderBy(m => m.Name).ToList());
        }

        // GET: Plants/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Plant plant = db.Plants.Find(id);
            if (plant == null)
            {
                return HttpNotFound();
            }

            var companionlist = db.Relationships.Where(p=>p.HostPlant.PlantId == id && !(p.RelationshipType.RelationshipTypeId == 3)).ToList();
            //companions = companions.CompanionPlant.Name.ToList();
            ViewBag.Companions = companionlist;

            var enemieslist = db.Relationships.Where(p => p.HostPlant.PlantId == id && p.RelationshipType.RelationshipTypeId == 3).ToList();
            ViewBag.Enemies = enemieslist;
            return View(plant);
        }

        // GET: Plants/Create
        public ActionResult Create()
        {
            ViewBag.PlantCategoryId = new SelectList(db.PlantCategories, "PlantCategoryId", "Name");

            return View();
        }

        // POST: Plants/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PlantId,Name,PlantCategoryId")] Plant plant)
        {
            if (ModelState.IsValid)
            {
                db.Plants.Add(plant);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.PlantCategoryId = new SelectList(db.PlantCategories, "PlantCategoryId", "Name");

            return View(plant);
        }

        // GET: Plants/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Plant plant = db.Plants.Find(id);
            if (plant == null)
            {
                return HttpNotFound();
            }
            ViewBag.PlantCategoryId = new SelectList(db.PlantCategories, "PlantCategoryId", "Name", plant.PlantCategoryId);

            return View(plant);
        }

        // POST: Plants/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PlantId,Name,PlantCategoryId")] Plant plant)
        {
            if (ModelState.IsValid)
            {
                db.Entry(plant).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.PlantCategoryId = new SelectList(db.PlantCategories, "PlantCategoryId", "Name", plant.PlantCategoryId);

            return View(plant);
        }

        // GET: Plants/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Plant plant = db.Plants.Find(id);
            if (plant == null)
            {
                return HttpNotFound();
            }
            return View(plant);
        }

        // POST: Plants/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Plant plant = db.Plants.Find(id);
            db.Plants.Remove(plant);
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
