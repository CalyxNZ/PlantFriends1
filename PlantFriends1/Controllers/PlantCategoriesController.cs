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
    public class PlantCategoriesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PlantCategories
        public ActionResult Index()
        {
            return View(db.PlantCategories.OrderBy(c => c.Name).ToList());
        }

        // GET: PlantCategories/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlantCategory plantCategory = db.PlantCategories.Find(id);
            if (plantCategory == null)
            {
                return HttpNotFound();
            }
            return View(plantCategory);
        }

        // GET: PlantCategories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: PlantCategories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PlantCategoryId,Name")] PlantCategory plantCategory)
        {
            if (ModelState.IsValid)
            {
                db.PlantCategories.Add(plantCategory);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(plantCategory);
        }

        // GET: PlantCategories/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlantCategory plantCategory = db.PlantCategories.Find(id);
            if (plantCategory == null)
            {
                return HttpNotFound();
            }
            return View(plantCategory);
        }

        // POST: PlantCategories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PlantCategoryId,Name")] PlantCategory plantCategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(plantCategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(plantCategory);
        }

        // GET: PlantCategories/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PlantCategory plantCategory = db.PlantCategories.Find(id);
            if (plantCategory == null)
            {
                return HttpNotFound();
            }
            return View(plantCategory);
        }

        // POST: PlantCategories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PlantCategory plantCategory = db.PlantCategories.Find(id);
            db.PlantCategories.Remove(plantCategory);
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
