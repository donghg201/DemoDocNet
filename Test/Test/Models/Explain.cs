using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Test.Models
{
    public class Explain
    {
        [Key]
        public int Explain_Id{get;set;}
        public string Explain_Describe{get;set;}
        public bool Explain_DelFlg{get;set;}

    }
}
