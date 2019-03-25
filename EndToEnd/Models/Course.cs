using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EndToEnd.Models
{
    public class Course
    {
        [Required(ErrorMessage = "Внесете име")]
        [Display(Name = "Име на предмет")]
        public string Name { get; set; }

        [Key]
        [Display(Name = "Код")]
        public int Code { get; set; }

        [Required(ErrorMessage = "Може да внесете број од 1 до 8")]
        [Range(1, 8, ErrorMessage = "Може да внесете број од 1 до 8")]
        [Display(Name = "Семестар")]
        public int Semester { get; set; }

        [Required(ErrorMessage = "Внесете фонд на часови")]
        [Display(Name = "Фонд на часови")]
        public string Fond { get; set; }

        [Required(ErrorMessage = "Може да внесете број од 3 до 10")]
        [Range(1, 8, ErrorMessage = "Може да внесете број од 3 до 10")]
        [Display(Name = "Кредити")]
        public int Credits { get; set; }

    }
}