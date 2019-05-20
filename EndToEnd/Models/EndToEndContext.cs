using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EndToEnd.Models
{
    public class EndToEndContext : DbContext
    {
      
        public EndToEndContext() : base("name=EndToEndContext")
        {
        }

        public System.Data.Entity.DbSet<EndToEnd.Models.Student> Students { get; set; }

        public System.Data.Entity.DbSet<EndToEnd.Models.Professor> Professors { get; set; }

        public System.Data.Entity.DbSet<EndToEnd.Models.Grade> Grades { get; set; }
        public System.Data.Entity.DbSet<EndToEnd.Models.Course> Courses { get; set; }
        public System.Data.Entity.DbSet<EndToEnd.Models.ProfessorsCourse> ProfessorsCourses { get; set; }




    }
}
