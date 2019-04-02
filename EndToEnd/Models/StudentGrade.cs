using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EndToEnd.Models
{
    public class StudentGrade
    {
        public string UserName { get; set; }
        public string StudentIndex { get; set; }
        public string StudentID { get; set; }

        public decimal Result { set; get; }
        public int PrBr { set; get; }
        public int Br { set; get; }
        public string Program { get;  set; }
        public int Code { get; set; }
    }
}