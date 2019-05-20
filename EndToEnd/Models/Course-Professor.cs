using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EndToEnd.Models
{
    public class Course_Professor
    {
        [Display(Name = "Име на предмет")]
        public string Name { set; get; }

        [Display(Name = "Код")]
        public int Code { set; get; }
        public int Br { set; get; }
        
    }
}