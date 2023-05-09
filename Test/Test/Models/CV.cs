using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Test.Models
{
    public class CV
    {
        [Key]
        public int CV_Id {get;set;}
        public string CV_Name { get;set;}
        public int CV_PosAppliedId { get;set;}
        public int CV_PLAppliedId { get;set;}
        public DateTime CV_AppliedDate { get;set;}
        public int CV_Status { get;set;}
        public DateTime CV_Route1Date { get;set;}
        public int CV_Route1Result { get;set;}
        public DateTime CV_Route2Date { get;set;}
        public int CV_Route2Result { get;set;}
        public int CV_OfterStatus { get;set;}
        public int CV_RecruitChanel { get;set;}
        public string CV_RecommendedBy { get;set;}
        public DateTime CV_DateJoining { get;set;}
        public string CV_FileUpload { get; set; }
        public string CV_CreateDate { get;set;}
        public string CV_CreateBy { get;set;}
        public DateTime CV_LastUpdateDate { get; set; }
        public string CV_LastUpdateBy { get;set;}
        public bool CV_DelFlg { get;set;}
        public string CV_Note { get;set;}

    }
}
