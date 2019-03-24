using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EndToEnd.Models
{
    public class Course
    {
        public string Name { get; set; }
        [Key]
        public int Code { get; set; }
        public int Semester { get; set; }
        public string Fond { get; set; }
        public int Credits { get; set; }

    }
}