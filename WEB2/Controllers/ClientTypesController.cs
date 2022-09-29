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
    public class ClientTypesController : Controller
    {
        private INTECEntities db = new INTECEntities();

        // GET: ClientTypes
        public ActionResult Index()
        {
            return View(db.ClientTypes.ToList());
        }

        // GET: ClientTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClientTypes clientTypes = db.ClientTypes.Find(id);
            if (clientTypes == null)
            {
                return HttpNotFound();
            }
            return View(clientTypes);
        }

        // GET: ClientTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClientTypes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description,Enabled,CreatedDate")] ClientTypes clientTypes)
        {
            if (ModelState.IsValid)
            {
                db.ClientTypes.Add(clientTypes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(clientTypes);
        }

        // GET: ClientTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClientTypes clientTypes = db.ClientTypes.Find(id);
            if (clientTypes == null)
            {
                return HttpNotFound();
            }
            return View(clientTypes);
        }

        // POST: ClientTypes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,Enabled,CreatedDate")] ClientTypes clientTypes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(clientTypes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(clientTypes);
        }

        // GET: ClientTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ClientTypes clientTypes = db.ClientTypes.Find(id);
            if (clientTypes == null)
            {
                return HttpNotFound();
            }
            return View(clientTypes);
        }

        // POST: ClientTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ClientTypes clientTypes = db.ClientTypes.Find(id);
            db.ClientTypes.Remove(clientTypes);
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
