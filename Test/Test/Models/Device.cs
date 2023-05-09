using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Test.Models
{
    public class Device
    {
        [Key]
        public string Device_Id { get; set; }
        public string Device_Floor{ get; set; }
        public string Device_EmpNo{ get; set; }
        public string Device_Maker{ get; set; }
        public string Device_Model { get; set; }
        public string Device_Seri { get; set; }
        public DateTime Device_DateBuy { get; set; }
        public int Device_Status{ get; set; }
        public int Device_Type { get; set; }
        public string Device_Os { get; set; }
        public string Device_Cpu { get; set; }
        public string Device_Memory { get; set; }
        public string Device_Hdd { get; set; }
        public bool Device_DelFlag{ get; set; }
        public DateTime Device_CreateDate{ get; set; }
        public string Device_CreateBy{ get; set; }
        public DateTime Device_UpdateDate{ get; set; }
        public string Device_UpdateBy{ get; set; }
        public string Device_Memo{ get; set; }
        public string Device_Accessories{ get; set; }
        public int Device_No { get; set; }

    }
}
