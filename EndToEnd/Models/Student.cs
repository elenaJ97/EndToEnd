using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EndToEnd.Models
{
    public class Student
    {
        public string  ID { get; set; }

        [Required]
        [Display(Name = "Име и презиме")]
        public string UserName { get; set; }
     
        [RegularExpression(@"\d{1}-\d{4}|\d{2}-\d{4}|\d{3}-\d{4}", ErrorMessage = "Потребно е да го внесете индексот со формат xxx-xxxx!")]
        [Required]
        [Display(Name = "Индекс")]
        public string StudentIndex { get; set; }

        [Range(5, 10)]
        [Required]
        [Display(Name = "Просек")]
        public decimal GPA { get; set; }

        [Required(ErrorMessage = "Потребно е да се пополни ова поле.")]
        [Display(Name = "Смер")]
        public string Program { get; set; }

        [Required]
        [RegularExpression(@"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" + @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$", ErrorMessage = "Wrong email format.")]
        public string Email { get; set; }

    }
}