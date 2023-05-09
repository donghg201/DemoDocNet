using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Test.Models
{
    public class MessLog
    {
        [Key]
        public int ML_Id { get;set;}
        public string ML_RoomId { get;set;}
        public DateTime ML_Date { get;set;}
        public bool ML_Flg { get;set;}

    }
}
