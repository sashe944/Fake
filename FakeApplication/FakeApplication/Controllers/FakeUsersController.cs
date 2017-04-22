using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FakeApplication.Models;

namespace FakeApplication.Controllers
{
    public class FakeUsersController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: FakeUsers
        public ActionResult Index()
        {
            return View(db.FakeUsers.ToList());
        }

        // GET: FakeUsers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FakeUsers fakeUsers = db.FakeUsers.Find(id);
            if (fakeUsers == null)
            {
                return HttpNotFound();
            }
            return View(fakeUsers);
        }

        // GET: FakeUsers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: FakeUsers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FakeName,FakeDate")] FakeUsers fakeUsers)
        {
            if (ModelState.IsValid)
            {
                db.FakeUsers.Add(fakeUsers);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(fakeUsers);
        }

        // GET: FakeUsers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FakeUsers fakeUsers = db.FakeUsers.Find(id);
            if (fakeUsers == null)
            {
                return HttpNotFound();
            }
            return View(fakeUsers);
        }

        // POST: FakeUsers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FakeName,FakeDate")] FakeUsers fakeUsers)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fakeUsers).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fakeUsers);
        }

        // GET: FakeUsers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FakeUsers fakeUsers = db.FakeUsers.Find(id);
            if (fakeUsers == null)
            {
                return HttpNotFound();
            }
            return View(fakeUsers);
        }

        // POST: FakeUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FakeUsers fakeUsers = db.FakeUsers.Find(id);
            db.FakeUsers.Remove(fakeUsers);
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
