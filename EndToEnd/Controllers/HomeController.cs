using EndToEnd.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EndToEnd.Controllers
{
    public class HomeController : Controller
    {
        private EndToEndContext db = new EndToEndContext();
        private ApplicationDbContext db1 = new ApplicationDbContext();
        public ActionResult Index()
        {
            var professor = new List<Professor>(db.Professors);
            var users = new List<ApplicationUser>(db1.Users);
            var student = new List<Student>(db.Students);

            var delete = (from a in student
                          where !users.Any(s => s.Id == a.ID)
                          select a).ToList();
            foreach (var item in delete)
            {
                db.Students.Remove(item);
            }
            db.SaveChanges();
            var delete1 = (from a in professor
                          where !users.Any(s => s.Id == a.IDProF)
                          select a).ToList();
            foreach (var item in delete1)
            {
                db.Professors.Remove(item);
            }
            db.SaveChanges();
            if (User.IsInRole("Student"))
            {
                var user = User.Identity.GetUserId();
                var average = (from g in db.Grades
                               join s in db.Students on g.StudentID equals s.ID
                               select g.Result).Average();
                var mytab = db.Students.FirstOrDefault(s => s.ID == user);
                mytab.GPA = average;
                db.SaveChanges();
            }
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}