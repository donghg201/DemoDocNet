using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Test.Models
{
    public class CalendarHoliday
    {
        [Key]
        public int CH_Id{get;set;}
        public int CH_Year { get;set;}
        public int CH_Month { get;set;}
        public int CH_Day { get;set;}
        public string CH_Description { get;set;}
        public bool CH_DelFlg { get; set; }
        public int CH_Type { get;set;}

    }
}
