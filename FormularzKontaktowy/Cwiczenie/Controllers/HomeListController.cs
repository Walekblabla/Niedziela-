using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Cwiczenie.Models;

namespace Cwiczenie.Controllers
{
    public class HomeListController : Controller
    {
        private Models.AppContext db = new Models.AppContext();

        // GET: HomeList
        public ActionResult Index()
        {
            return View(db.HomeLists.ToList());
        }

        // GET: HomeList/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HomeList homeList = db.HomeLists.Find(id);
            if (homeList == null)
            {
                return HttpNotFound();
            }
            return View(homeList);
        }

        // GET: HomeList/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HomeList/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,TownName,Color")] HomeList homeList)
        {
            if (ModelState.IsValid)
            {
                db.HomeLists.Add(homeList);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(homeList);
        }

        // GET: HomeList/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HomeList homeList = db.HomeLists.Find(id);
            if (homeList == null)
            {
                return HttpNotFound();
            }
            return View(homeList);
        }

        // POST: HomeList/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,TownName,Color")] HomeList homeList)
        {
            if (ModelState.IsValid)
            {
                db.Entry(homeList).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(homeList);
        }

        // GET: HomeList/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HomeList homeList = db.HomeLists.Find(id);
            if (homeList == null)
            {
                return HttpNotFound();
            }
            return View(homeList);
        }

        // POST: HomeList/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HomeList homeList = db.HomeLists.Find(id);
            db.HomeLists.Remove(homeList);
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
