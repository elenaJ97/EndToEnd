using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EndToEnd.Models
{
    public class StudentGrade
    {
        [Display(Name = "Студент")]
        public string UserName { get; set; }
        [Display(Name = "Индекс на студент")]
        public string StudentIndex { get; set; }
    
        public string StudentID { get; set; }
        [Display(Name = "Оцена")]
        public decimal Result { set; get; }
        public int PrBr { set; get; }
        public int Br { set; get; }
        [Display(Name = "Насока")]
        public string Program { get;  set; }
        [Display(Name = "Код на предметот")]
        public int Code { get; set; }
    }
}