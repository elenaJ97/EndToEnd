using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EndToEnd.Models;
using Microsoft.AspNet.Identity;

namespace EndToEnd.Controllers
{
    public class ProfessorsCoursesController : Controller
    {
        private EndToEndContext db = new EndToEndContext();

        // GET: ProfessorsCourses
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();

            var query = from PC in db.ProfessorsCourses
                        join Courses in db.Courses on PC.Code equals Courses.Code
                        where PC.IDProF == userId
                        select new Course_Professor
                        {
                            Name = Courses.Name,
                            Code = Courses.Code,
                            Br = PC.Br,

                        };
            return View(query.ToList());
        }

        // GET: ProfessorsCourses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProfessorsCourse professorsCourse = db.ProfessorsCourses.Find(id);
            if (professorsCourse == null)
            {
                return HttpNotFound();
            }
            return View(professorsCourse);
        }

        // GET: ProfessorsCourses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProfessorsCourses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Br,IDProF,Code")] ProfessorsCourse professorsCourse)
        {
            if (ModelState.IsValid)
            {
                db.ProfessorsCourses.Add(professorsCourse);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(professorsCourse);
        }

        // GET: ProfessorsCourses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProfessorsCourse professorsCourse = db.ProfessorsCourses.Find(id);
            if (professorsCourse == null)
            {
                return HttpNotFound();
            }
            return View(professorsCourse);
        }

        // POST: ProfessorsCourses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Br,IDProF,Code")] ProfessorsCourse professorsCourse)
        {
            if (ModelState.IsValid)
            {
                db.Entry(professorsCourse).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(professorsCourse);
        }

        // GET: ProfessorsCourses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ProfessorsCourse professorsCourse = db.ProfessorsCourses.Find(id);
            if (professorsCourse == null)
            {
                return HttpNotFound();
            }
            return View(professorsCourse);
        }

        // POST: ProfessorsCourses/Delete/5
        [HttpPost, ActionName("Избриши")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ProfessorsCourse professorsCourse = db.ProfessorsCourses.Find(id);
            db.ProfessorsCourses.Remove(professorsCourse);
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
