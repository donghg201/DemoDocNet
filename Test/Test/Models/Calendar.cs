using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Test.Models
{
    public class Calendar
    {
        [Key]
        public int Calendar_Id { get; set; }
        public string Calendar_Title { get; set; }
        public DateTime Calendar_Start { get; set; }
        public DateTime Calendar_End { get; set; }
        public string Calendar_Url { get; set; }
        public bool Calendar_DelFlg { get; set; }
        public bool Calendar_AllDay { get; set; }
        public string Calendar_Description { get; set; }
        public string Calendar_Guest { get; set; }
        public DateTime Calendar_CreateDate { get; set; }
        public string Calendar_CreateBy { get; set; }
        public DateTime Calendar_LastUpdateDate { get; set; }
        public string Calendar_LastUpdateBy { get; set; }
        public bool Calendar_Display { get; set; }
        public string Calendar_IdGoogleCal { get; set; }
        public bool Calendar_Daily { get; set; }
        public bool Calendar_Weekly { get; set; }

    }
}
