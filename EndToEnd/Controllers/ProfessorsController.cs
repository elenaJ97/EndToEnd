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
using Microsoft.AspNet.Identity.Owin;

namespace EndToEnd.Controllers
{
    public class ProfessorsController : Controller
    {
        private EndToEndContext db = new EndToEndContext();
        private ApplicationDbContext db1 = new ApplicationDbContext();
        private ApplicationUserManager _userManager;


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
        #region public ApplicationUserManager UserManager
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ??
                    HttpContext.GetOwinContext()
                    .GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
        #endregion
        // POST: Professors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Professor professor = db.Professors.Find(id);
            var course = new List<ProfessorsCourse>(db.ProfessorsCourses);
            var courses = (from g in course
                          where g.IDProF == id
                          select g).ToList();
            foreach (var item in courses)
            {
                db.ProfessorsCourses.Remove(item);
            }
            db.SaveChanges();
            db.Professors.Remove(professor);
            ApplicationUser user = UserManager.FindById(id);
            if (user == null)
            {
                throw new Exception("Could not find the User");
            }

            UserManager.RemoveFromRoles(user.Id, UserManager.GetRoles(user.Id).ToArray());
            UserManager.Update(user);
            UserManager.Delete(user);
            db.SaveChanges();
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
