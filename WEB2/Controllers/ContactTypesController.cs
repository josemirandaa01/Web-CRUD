using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BO;

namespace WEB2.Controllers
{
    public class ContactTypesController : Controller
    {
        private INTECEntities db = new INTECEntities();

        // GET: ContactTypes
        public ActionResult Index()
        {
            return View(db.ContactTypes.ToList());
        }

        // GET: ContactTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactTypes contactTypes = db.ContactTypes.Find(id);
            if (contactTypes == null)
            {
                return HttpNotFound();
            }
            return View(contactTypes);
        }

        // GET: ContactTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ContactTypes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description,Enabled,CreatedDate")] ContactTypes contactTypes)
        {
            if (ModelState.IsValid)
            {
                db.ContactTypes.Add(contactTypes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(contactTypes);
        }

        // GET: ContactTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactTypes contactTypes = db.ContactTypes.Find(id);
            if (contactTypes == null)
            {
                return HttpNotFound();
            }
            return View(contactTypes);
        }

        // POST: ContactTypes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,Enabled,CreatedDate")] ContactTypes contactTypes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(contactTypes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(contactTypes);
        }

        // GET: ContactTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ContactTypes contactTypes = db.ContactTypes.Find(id);
            if (contactTypes == null)
            {
                return HttpNotFound();
            }
            return View(contactTypes);
        }

        // POST: ContactTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ContactTypes contactTypes = db.ContactTypes.Find(id);
            db.ContactTypes.Remove(contactTypes);
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
