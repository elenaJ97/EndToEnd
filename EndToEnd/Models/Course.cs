using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EndToEnd.Models
{
    public class Course
    {
        [Display(Name = "Име на предмет")]
        public string Name { get; set; }

        [Key]
        [Display(Name = "Код")]
        public int Code { get; set; }

        [Display(Name = "Семестар")]
        public int Semester { get; set; }

        [Display(Name = "Фонд на часови")]
        public string Fond { get; set; }

        [Display(Name = "Кредити")]
        public int Credits { get; set; }

    }
}