using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Project.Models;

namespace Project.Controllers
{
    public class ComponentsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult New()
        {
            return View();
        }

        // GET: Components
        public ActionResult Index()
        {
            if (User.IsInRole(RoleName.CanManageComponent))
                return View(db.Component.ToList());
            else
                return View("ReadOnly");
        }

        // GET: Components/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Component component = db.Component.Find(id);
            if (component == null)
            {
                return HttpNotFound();
            }
            return View(component);
        }

        [Authorize(Roles = RoleName.CanManageComponent)]

        // GET: Components/Create
        public ActionResult Create()
        {
            return View();
        }
        [Authorize(Roles = RoleName.CanManageComponent)]
        // POST: Components/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,PartId,Name,Qty")] Component component)
        {
            if (ModelState.IsValid)
            {
                db.Component.Add(component);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(component);
        }
        [Authorize(Roles = RoleName.CanManageComponent)]
        // GET: Components/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Component component = db.Component.Find(id);
            if (component == null)
            {
                return HttpNotFound();
            }
            return View(component);
        }
        [Authorize(Roles = RoleName.CanManageComponent)]
        // POST: Components/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,PartId,Name,Qty")] Component component)
        {
            if (ModelState.IsValid)
            {
                db.Entry(component).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(component);
        }
        [Authorize(Roles = RoleName.CanManageComponent)]
        // GET: Components/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Component component = db.Component.Find(id);
            if (component == null)
            {
                return HttpNotFound();
            }
            return View(component);
        }
        [Authorize(Roles = RoleName.CanManageComponent)]
        // POST: Components/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Component component = db.Component.Find(id);
            db.Component.Remove(component);
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
