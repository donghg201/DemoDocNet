using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Test.Models
{
    public class EmployeeSkill
    {
        [Key]
        public int Id {get;set;}
        public string Emp_No { get; set; }
        public int Skill_Id { get; set; }
        public string Skill_Name { get; set; }
        public int Skill_Level { get; set; }
        public string Skill_Exp { get; set; }

    }
}
