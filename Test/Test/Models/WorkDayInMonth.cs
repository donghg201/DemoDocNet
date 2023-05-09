using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Test.Models
{
    public class WorkDayInMonth
    {
        [Key]
        public int WD_Id { get;set;}
        public string WD_MonthYear { get;set;}
        public int WD_WorkDays { get;set;}
        public int WD_WorkHours { get;set;}

    }
}
