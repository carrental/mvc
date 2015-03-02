using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CarRental.Data;

namespace CarRentAdmin.Controllers
{
    public class CarTypeController : Controller
    {
        private CarRentalDb db = new CarRentalDb();

        // GET: /CarType/
        public ActionResult Index()
        {
            return View(db.Types.ToList());
        }

        // GET: /CarType/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarType cartype = db.Types.Find(id);
            if (cartype == null)
            {
                return HttpNotFound();
            }
            return View(cartype);
        }

        // GET: /CarType/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /CarType/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="Id,title")] CarType cartype)
        {
            if (ModelState.IsValid)
            {
                db.Types.Add(cartype);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cartype);
        }

        // GET: /CarType/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarType cartype = db.Types.Find(id);
            if (cartype == null)
            {
                return HttpNotFound();
            }
            return View(cartype);
        }

        // POST: /CarType/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="Id,title")] CarType cartype)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cartype).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cartype);
        }

        // GET: /CarType/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CarType cartype = db.Types.Find(id);
            if (cartype == null)
            {
                return HttpNotFound();
            }
            return View(cartype);
        }

        // POST: /CarType/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CarType cartype = db.Types.Find(id);
            db.Types.Remove(cartype);
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
