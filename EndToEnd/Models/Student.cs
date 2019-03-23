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
        public string UserName { get; set; }
     
        [RegularExpression(@"\d{1}-\d{4}|\d{2}-\d{4}|\d{3}-\d{4}", ErrorMessage = "Wrong index format.Required XXX-XXXX format")]
        [Required]
        public string StudentIndex { get; set; }

        [Range(5, 10)]
        [Required]
        public decimal GPA { get; set; }

        [Required]
        public string Program { get; set; }
        [Required]
        [RegularExpression(@"^(?("")("".+?(?<!\\)""@)|(([0-9a-z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-z])@))" + @"(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-z][-0-9a-z]*[0-9a-z]*\.)+[a-z0-9][\-a-z0-9]{0,22}[a-z0-9]))$", ErrorMessage = "Wrong email format.")]
        public string Email { get; set; }

    }
}