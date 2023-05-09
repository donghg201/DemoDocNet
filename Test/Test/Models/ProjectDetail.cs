using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Test.Models
{
    public class ProjectDetail
    {
        [Key]
        public int ProD_Id { get;set;}
        public int ProD_No { get;set;}
        public string ProD_EmpNo { get;set;}
        public int ProD_PosWork { get;set;}
        public int ProD_PL { get;set;}
        public DateTime ProD_JoinDate { get;set;}
        public DateTime ProD_LeaveDate { get;set;}
        public string ProD_PM { get;set;}
        public string ProD_DescJob { get;set;}
        public int ProD_Status { get;set;}
        public bool ProD_DelFlg { get;set;}
        public DateTime ProD_CreateDate { get; set; }
        public int ProD_CreateBy { get;set;}
        public DateTime ProD_LastUpdateDate { get;set;}
        public int ProD_LastUpdateBy { get;set;}
        public DateTime ProD_JoinDate_Est { get;set;}
        public DateTime ProD_LeaveDate_Est { get;set;}


    }
}
