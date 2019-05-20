using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Dynamic;
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
        private ApplicationDbContext db1 = new ApplicationDbContext();

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

            var professor = new List<Professor>(db.Professors);
            var users = new List<ApplicationUser>(db1.Users);
            var student = new List<Student>(db.Students);
            return View(query.ToList());
        }


        [HttpGet]
        public ActionResult Insert(int? id)
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
            var result = from s in db.Students
                         join g in db.Grades on s.ID equals g.StudentID
                         where g.Code == professorsCourse.Code
                         select new StudentGrade
                         {
                             UserName = s.UserName,
                             StudentIndex = s.StudentIndex,
                             Result = g.Result ,
                             StudentID=s.ID,
                             Br=professorsCourse.Br,
                             PrBr = g.PrBr,
                             Program = s.Program,
                             Code =g.Code
                         };
            
            return View(result.ToList());
        }
       

        /*
        public ActionResult Create()
        {
            return View();
        }
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

        
       */
        [HttpGet]
        public ActionResult Do(int? id)
        {
          

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Grade grade = db.Grades.Find(id);
            if (grade == null)
            {
                return HttpNotFound();
            }

            var result = from s in db.Students
                         join g in db.Grades on s.ID equals g.StudentID
                         where g.PrBr == grade.PrBr
                         select new StudentGrade {
                             UserName = s.UserName,
                             StudentIndex = s.StudentIndex,
                             Result = g.Result,
                             StudentID = s.ID,
                             PrBr = g.PrBr,
                             Program = s.Program,
                             Code = g.Code
                         };


            return View(result.First());
           
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Do([Bind(Include = "StudentID,Result,Code,PrBr,Br")] StudentGrade grade)
        {

            if (ModelState.IsValid)
                {
                var mytab = db.Grades.First(g => g.PrBr == grade.PrBr);
                mytab.Result = grade.Result;
                db.SaveChanges();
                  
                    return RedirectToAction("Index");
                }
                return View(grade);
            

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
        [HttpPost, ActionName("Delete")]
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
