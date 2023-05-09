using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Test.Models
{
    public class Title
    {
        [Key]
        public int Title_Id{ get;set;}
        public string Title_Name{ get;set;}
        public bool Title_DelFlg{ get;set;}

    }
}
