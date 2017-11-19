using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Cwiczenie.Models;
using Cwiczenie.Repository;
using static System.ActivationContext;

namespace Cwiczenie.Controllers
{
    public class FormListController : Controller
    {
        private FormListRepository _formListRepository;
        public FormListController()
        {
            _formListRepository = new FormListRepository();
        }

        public ActionResult Index()
        {
            return View(_formListRepository.GetWhere(x => x.Id > 0));
        }

        // GET: FormList/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FormList formList = _formListRepository.GetWhere(x => x.Id == id.Value).FirstOrDefault();
            if (formList == null)
            {
                return HttpNotFound();
            }
            return View(formList);
        }

        // GET: FormList/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FormList/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Surname")] FormList formList)
        {
            if (ModelState.IsValid)
            {
                _formListRepository.Create(formList);
                return RedirectToAction("Index");
            }

            return View(formList);
        }

        // GET: FormList/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FormList formList = _formListRepository.GetWhere(x => x.Id == id.Value).FirstOrDefault();
            if (formList == null)
            {
                return HttpNotFound();
            }
            return View(formList);
        }

      

        // GET: FormList/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FormList formList = _formListRepository.GetWhere(x => x.Id == id.Value).FirstOrDefault();
           
                if (formList == null)
            {
                return HttpNotFound();
            }
            return View(formList);
        }

        // POST: FormList/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
           
            FormList formList = _formListRepository.GetWhere(x => x.Id == id).FirstOrDefault();
            _formListRepository.Delete(formList);
            return RedirectToAction("Index");
        }

       
    }
}
