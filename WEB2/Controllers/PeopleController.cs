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
    public class PeopleController : Controller
    {
        private INTECEntities db = new INTECEntities();

        // GET: People
        public ActionResult Index()
        {
            var people = db.People.Include(p => p.ClientTypes).Include(p => p.Companies).Include(p => p.ContactTypes).Include(p => p.Deparments);
            return View(people.ToList());
        }

        // GET: People/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            People people = db.People.Find(id);
            if (people == null)
            {
                return HttpNotFound();
            }
            return View(people);
        }

        // GET: People/Create
        public ActionResult Create()
        {
            ViewBag.ClientTypeId = new SelectList(db.ClientTypes, "Id", "Name");
            ViewBag.CompanyId = new SelectList(db.Companies, "Id", "Name");
            ViewBag.ContactTypeId = new SelectList(db.ContactTypes, "Id", "Name");
            ViewBag.DepartmentId = new SelectList(db.Deparments, "Id", "Code");
            return View();
        }

        // POST: People/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,MiddleName,LastName,ClientTypeId,ContactTypeId,SupportStaff,PhoneNumber,EmailAddress,CompanyId,DepartmentId,Enabled,CreatedDate")] People people)
        {
            if (ModelState.IsValid)
            {
                db.People.Add(people);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClientTypeId = new SelectList(db.ClientTypes, "Id", "Name", people.ClientTypeId);
            ViewBag.CompanyId = new SelectList(db.Companies, "Id", "Name", people.CompanyId);
            ViewBag.ContactTypeId = new SelectList(db.ContactTypes, "Id", "Name", people.ContactTypeId);
            ViewBag.DepartmentId = new SelectList(db.Deparments, "Id", "Code", people.DepartmentId);
            return View(people);
        }

        // GET: People/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            People people = db.People.Find(id);
            if (people == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClientTypeId = new SelectList(db.ClientTypes, "Id", "Name", people.ClientTypeId);
            ViewBag.CompanyId = new SelectList(db.Companies, "Id", "Name", people.CompanyId);
            ViewBag.ContactTypeId = new SelectList(db.ContactTypes, "Id", "Name", people.ContactTypeId);
            ViewBag.DepartmentId = new SelectList(db.Deparments, "Id", "Code", people.DepartmentId);
            return View(people);
        }

        // POST: People/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,MiddleName,LastName,ClientTypeId,ContactTypeId,SupportStaff,PhoneNumber,EmailAddress,CompanyId,DepartmentId,Enabled,CreatedDate")] People people)
        {
            if (ModelState.IsValid)
            {
                db.Entry(people).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClientTypeId = new SelectList(db.ClientTypes, "Id", "Name", people.ClientTypeId);
            ViewBag.CompanyId = new SelectList(db.Companies, "Id", "Name", people.CompanyId);
            ViewBag.ContactTypeId = new SelectList(db.ContactTypes, "Id", "Name", people.ContactTypeId);
            ViewBag.DepartmentId = new SelectList(db.Deparments, "Id", "Code", people.DepartmentId);
            return View(people);
        }

        // GET: People/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            People people = db.People.Find(id);
            if (people == null)
            {
                return HttpNotFound();
            }
            return View(people);
        }

        // POST: People/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            People people = db.People.Find(id);
            db.People.Remove(people);
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
