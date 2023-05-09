using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Test.Models
{
    public class CalendarPersonal
    {
        [Key]
        public int Personal_Id { get; set; }
        public string Personal_CreateBy { get; set; }
        public string Personal_Guest { get; set; }
        public string Personal_Color { get; set; }
        public bool Personal_Checked { get; set; }
        public bool Personal_DelFlg { get; set; }
        public string Personal_GuestName { get; set; }

    }
}
