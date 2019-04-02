using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace EndToEnd.Models
{
    public class EndToEndContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
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
