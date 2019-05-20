using EndToEnd.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
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
            var list = (from g in db.Grades
                        join s in db.Students on g.StudentID equals s.ID
                        select g.Result);
            if (User.IsInRole("Student"))
            {
                if (list.Any())
                {
                    var user = User.Identity.GetUserId();
                    var average = (from g in db.Grades
                                   join s in db.Students on g.StudentID equals user
                                   select g.Result).DefaultIfEmpty(-1).Average();

                    
                        var mytab = db.Students.FirstOrDefault(s => s.ID == user);
                        mytab.GPA = average;

                   
                        //db.SaveChanges();
                    



                }
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