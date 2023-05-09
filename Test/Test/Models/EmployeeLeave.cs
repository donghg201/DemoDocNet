using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Test.Models
{
    public class EmployeeLeave
    {
        [Key]
        public int Leave_Id {get;set;}
        public string Emp_No { get;set;}
        public string Leave_Reason { get;set;}
        public int Leave_Type { get;set;}
        public DateTime Leave_CreatedDate { get;set;}
        public int Leave_Status { get;set;}
        public DateTime Leave_From { get;set;}
        public DateTime Leave_To { get;set;}
        public bool Leave_DelFlg { get;set;}
        public string Leave_Note1 { get;set;}
        public int Leave_Applyrole1 { get;set;}
        public int Leave_Applyrole2 { get;set;}
        public int Leave_Applyrole3 { get;set;}
        public string Leave_Day { get;set;}
        public string Leave_Note2 { get;set;}
        public string Leave_Note3 { get;set;}
        public DateTime Leave_ApplyRole1Date { get;set;}
        public DateTime Leave_ApplyRole2Date { get;set;}
        public DateTime Leave_ApplyRole3Date { get;set;}
        public DateTime Leave_FromTime { get;set;}
        public DateTime Leave_ToTime { get;set;}

    }
}
