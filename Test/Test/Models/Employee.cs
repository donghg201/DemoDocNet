using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Test.Models
{
    public class Employee
    {
        [Key]
        public string Emp_No { get; set; }
        public string Emp_Name { get; set; }
        public string Emp_Password { get; set; }
        public DateTime Emp_Birthday { get; set; }
        public string Emp_Sex { get; set; }
        public string Emp_PhoneNo { get; set; }
        public string Emp_Email { get; set; }
        public string Emp_Address { get; set; }
        public int Emp_PosWork { get; set; }
        public int Emp_Status { get; set; }
        public int Emp_ContractType { get; set; }
        public DateTime Emp_WorkingDateFrom { get; set; }
        public DateTime Emp_WorkingDateTo { get; set; }
        public DateTime Emp_ContractFrom { get; set; }
        public DateTime Emp_ContractTo { get; set; }
        public string Emp_EDLevel { get; set; }
        public string Emp_FL1 { get; set; }
        public string Emp_FLLevel1 { get; set; }
        public string Emp_FL2 { get; set; }
        public string Emp_FLLevel2 { get; set; }
        public string Emp_FL3 { get; set; }
        public string Emp_FLLevel3 { get; set; }
        public string Emp_SoftSkill { get; set; }
        public int Emp_PL1 { get; set; }
        public string Emp_PL1Level { get; set; }
        public int Emp_PL1Exp { get; set; }
        public int Emp_PL2 { get; set; }
        public string Emp_PL2Level { get; set; }
        public int Emp_PL2Exp { get; set; }
        public int Emp_PL3 { get; set; }
        public string Emp_PL3Level { get; set; }
        public int Emp_PL3Exp { get; set; }
        public int Emp_RoleApp { get; set; }
        public bool Emp_DelFlg { get; set; }
        public DateTime Emp_CreateDate { get; set; }
        public string Emp_CreateBy { get; set; }
        public DateTime Emp_LastUpdateDate { get; set; }
        public string Emp_LastUpdateBy { get; set; }
        public string Emp_BussinessExp { get; set; }
        public int Emp_Salary { get; set; }
        public int Emp_MaritalStatus { get; set; }
        public int Emp_NumberChild { get; set; }
        public int Emp_Team { get; set; }
        public bool Emp_TeamLead { get; set; }
        public float Emp_LeaveCurrentYear { get; set; }
        public float Emp_LeaveUsed { get; set; }
        public float Emp_LeaveLastYear { get; set; }
        public string Emp_LeaveApplyRole1By { get; set; }
        public string Emp_LeaveApplyRole2By { get; set; }
        public string Emp_LeaveApplyRole3By { get; set; }
        public string Emp_NickName { get; set; }
        public string Emp_ChatworkId { get; set; }
    }
}
