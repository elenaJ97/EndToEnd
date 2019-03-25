using EndToEnd.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace EndToEnd.Controllers
{
    public class CoursesController : Controller
    {
        private EndToEndContext db = new EndToEndContext();

        // GET: Courses
        public ActionResult Index()
        {
            var userId = User.Identity.GetUserId();
            if (User.IsInRole("Student"))
            {
                var result = from a in db.Courses
                             where !db.Grades.Any(s => s.Code == a.Code && s.StudentID == userId)
                             select a;
                return View(result.ToList());

            }
            else
            {

                var result = from a in db.Courses
                             where !db.ProfessorsCourses.Any(s => s.Code == a.Code && s.IDProF == userId)
                             select a;
                return View(result.ToList());

            }

        }

        // GET: Courses/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.Courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        // GET: Courses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Courses/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Code,Name,Semester,Fond,Credits")] Course course)
        {
            
            if (ModelState.IsValid)
            {
                db.Courses.Add(course);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(course);
        }

        // GET: Courses/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.Courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        // POST: Courses/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Code,Name,Semester,Fond,Credits")] Course course)
        {
            if (ModelState.IsValid)
            {
                db.Entry(course).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(course);
        }
       
        // GET: Courses/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = db.Courses.Find(id);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        // POST: Courses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var userId = User.Identity.GetUserId();
            Course course = db.Courses.Find(id);
            if (User.IsInRole("Student"))
            {
                using (SqlConnection con = new SqlConnection("Server=DESKTOP-2ALKA6L;Database=Data1;Trusted_Connection=true;"))
                {
                    con.Open();
                    try
                    {
                        using (SqlCommand command = new SqlCommand(
                            "INSERT INTO Grades VALUES(@StudentID, @Result, @Code)", con))
                        {
                            command.Parameters.Add(new SqlParameter("StudentID", userId));
                            command.Parameters.Add(new SqlParameter("Result", 5.00));
                            command.Parameters.Add(new SqlParameter("Code", id));


                            command.ExecuteNonQuery();
                        }
                    }
                    catch
                    {
                        Console.WriteLine("Count not insert.");
                    }
                }
            }
            else if (User.IsInRole("Professor"))
            {
                using (SqlConnection con = new SqlConnection("Server=DESKTOP-2ALKA6L;Database=Data1;Trusted_Connection=true;"))
                {
                    con.Open();
                    try
                    {
                        using (SqlCommand command = new SqlCommand(
                            "INSERT INTO ProfessorsCourses VALUES(@IDProf, @Code)", con))
                        {
                            command.Parameters.Add(new SqlParameter("IDProf", userId));
                            command.Parameters.Add(new SqlParameter("Code", id));


                            command.ExecuteNonQuery();
                        }
                    }
                    catch
                    {
                        Console.WriteLine("Count not insert.");
                    }
                }
            }
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
