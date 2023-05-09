using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Test.Models
{
    public class CalendarWordDay
    {
        [Key]
        public int CWD_Id {get;set;}
        public int CWD_Year { get; set; }
        public int CWD_Month1 { get; set; }
        public int CWD_Month2 { get; set; }
        public int CWD_Month3 { get; set; }
        public int CWD_Month4 { get; set; }
        public int CWD_Month5 { get; set; }
        public int CWD_Month6 { get; set; }
        public int CWD_Month7 { get; set; }
        public int CWD_Month8 { get; set; }
        public int CWD_Month9 { get; set; }
        public int CWD_Month10 { get; set; }
        public int CWD_Month11 { get; set; }
        public int CWD_Month12 { get; set; }
        public bool CWD_DelFlg { get; set; }

    }
}
