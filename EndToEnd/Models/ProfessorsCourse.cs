using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace EndToEnd.Models
{
    public class ProfessorsCourse
    {
        [Key]
        [Column(Order = 0)]
        public string IDProF { get; set; }
        [Key]
        [Column(Order = 1)]
        public int Code { get; set; }

    }
}