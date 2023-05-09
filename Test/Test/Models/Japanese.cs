using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Test.Models
{
    public class Japanese
    {
        [Key]
        public int Japanese_Id { get;set;}
        public string Japanese_Name { get;set;}
        public int Japanese_Title { get;set;}
        public string Japanese_English { get;set;}
        public int Japanese_Explain { get;set;}
        public string Japanese_Hiragana { get;set;}
        public bool Japanese_DelFlg { get;set;}
        public string Japanese_Memo { get;set;}

    }
}
