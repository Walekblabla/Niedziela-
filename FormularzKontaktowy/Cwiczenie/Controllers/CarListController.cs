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
    public class CarListController : Controller
    {
        private Models.AppContext db = new Models.AppContext();

        // GET: CarList
        public ActionResult Index()
        {
            return View(db.CarLists.ToList());
        }

        // GET: CarList/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarList carList = db.CarLists.Find(id);
            if (carList == null)
            {
                return HttpNotFound();
            }
            return View(carList);
        }

        // GET: CarList/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CarList/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Brand,TypeOfEngine")] CarList carList)
        {
            if (ModelState.IsValid)
            {
                db.CarLists.Add(carList);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(carList);
        }

        // GET: CarList/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarList carList = db.CarLists.Find(id);
            if (carList == null)
            {
                return HttpNotFound();
            }
            return View(carList);
        }

        // POST: CarList/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Brand,TypeOfEngine")] CarList carList)
        {
            if (ModelState.IsValid)
            {
                db.Entry(carList).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(carList);
        }

        // GET: CarList/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarList carList = db.CarLists.Find(id);
            if (carList == null)
            {
                return HttpNotFound();
            }
            return View(carList);
        }

        // POST: CarList/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CarList carList = db.CarLists.Find(id);
            db.CarLists.Remove(carList);
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
