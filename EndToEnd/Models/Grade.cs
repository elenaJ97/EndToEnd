using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace EndToEnd.Models
{
    public class Grade
    {
        public string StudentID { get; set; }

        public decimal Result { get; set; }
        public int Code { get; set; }
        [Key]
        public int PrBr { get; set; }

    }
}