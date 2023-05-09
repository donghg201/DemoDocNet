using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Test.Models
{
    public class EmployeeWorkPerformance
    {
        [Key]
        public int Id {get;set;}
        public string Emp_No { get;set;}
        public string ProjectName { get;set;}
        public string ProjectContent { get;set;}
        public string Role { get;set;}
        public string OS { get;set;}
        public string Environment { get; set; }
        public string ProgrammingLanguage { get;set;}
        public string InChargePhase { get;set;}
        public int Year { get; set; }
        public int Month { get;set;}
        public bool DelFlg { get; set; }

    }
}
