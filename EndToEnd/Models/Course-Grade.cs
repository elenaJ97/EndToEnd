using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EndToEnd.Models
{
    public class Course_Grade
    {
        [Display(Name = "Име на предмет")]
        public string Name { set; get; }
        [Display(Name = "Оцена")]
        public decimal Result { set; get; }
    }
}