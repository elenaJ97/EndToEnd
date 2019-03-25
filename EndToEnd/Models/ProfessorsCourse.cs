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
        
        
        public string IDProF { get; set; }
        public int Code { get; set; }
        [Key]
        public int Br { get; set; }

    }
}