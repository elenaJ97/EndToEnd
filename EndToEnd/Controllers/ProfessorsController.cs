using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EndToEnd.Models;

namespace EndToEnd.Controllers
{
    public class ProfessorsController : Controller
    {
        private EndToEndContext db = new EndToEndContext();
        private ApplicationDbContext db1 = new ApplicationDbContext();

        // GET: Professors
        public ActionResult Index(string searchString)
        {
            var professor = new List<Professor>(db.Professors);

            var users = new List<ApplicationUser>(db1.Users);

            var query = from p in professor
                        join u in users on p.IDProF equals u.Id
                        select new Professor
                        {
                           Name=p.Name,
                           Surname=p.Surname,
                           IDProF=p.IDProF,
                           Email=p.Email

                        };
            var delete = (from a in professor
                          where !users.Any(s => s.Id == a.IDProF)
                          select a).ToList();
            foreach (var item in delete)
            {
                db.Professors.Remove(item);
            }
            db.SaveChanges();
            if (searchString != "")
            {
               
                var professors = from p in professor
                                 join u in users on p.IDProF equals u.Id

                                 select p;

                if (!String.IsNullOrEmpty(searchString))
                {
                    professors = professors.Where(s => s.Surname.Contains(searchString));
                }

                return View(professors);
            }
            return View(db.Professors.ToList());
        }

        // GET: Professors/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Professor professor = db.Professors.Find(id);
            if (professor == null)
            {
                return HttpNotFound();
            }
            return View(professor);
        }

        // GET: Professors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Professors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "IDProF,Name,Surname,Email")] Professor professor)
        {
            if (ModelState.IsValid)
            {
                db.Professors.Add(professor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(professor);
        }

        // GET: Professors/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Professor professor = db.Professors.Find(id);
            if (professor == null)
            {
                return HttpNotFound();
            }
            return View(professor);
        }

        // POST: Professors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "IDProF,Name,Surname,Email")] Professor professor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(professor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(professor);
        }

        // GET: Professors/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Professor professor = db.Professors.Find(id);
            if (professor == null)
            {
                return HttpNotFound();
            }
            return View(professor);
        }

        // POST: Professors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Professor professor = db.Professors.Find(id);
            db.Professors.Remove(professor);
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
