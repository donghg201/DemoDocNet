using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Test.Models
{
    public class Project
    {
        [Key]
        public int Pro_Id { get;set;}
        public string Pro_Name { get;set;}
        public string Pro_Description { get;set;}
        public string Pro_CustomerName { get;set;}
        public string Pro_Technology { get;set;}
        public int Pro_EstimateHour { get;set;}
        public int Pro_RealHour { get;set;}
        public DateTime Pro_StartDate { get;set;}
        public DateTime Pro_EndDate { get;set;}
        public int Pro_Status { get;set;}
        public bool Pro_DelFlg { get;set;}
        public DateTime Pro_CreateDate { get;set;}
        public string Pro_CreateBy { get;set;}
        public DateTime Pro_LastUpdateDate { get;set;}
        public string Pro_LastUpdateBy { get;set;}
        public DateTime Pro_StartDate_Est { get;set;}
        public DateTime Pro_EndDate_Est { get;set;}
        public string Pro_Code { get;set;}
        public int Pro_Category { get;set;}

    }
}
