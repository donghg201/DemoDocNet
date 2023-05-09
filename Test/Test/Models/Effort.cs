using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Test.Models
{
    public class Effort
    {
        [Key]
        public int Eff_Id {get;set;}
        public int Eff_ProDId { get;set;}
        public string Eff_MonthYear { get;set;}
        public decimal Eff_Day1 { get;set;}
        public decimal Eff_Day2 { get;set;}
        public decimal Eff_Day3 { get;set;}
        public decimal Eff_Day4 { get;set;}
        public decimal Eff_Day5 { get;set;}
        public decimal Eff_Day6 { get;set;}
        public decimal Eff_Day7 { get;set;}
        public decimal Eff_Day8 { get;set;}
        public decimal Eff_Day9 { get;set;}
        public decimal Eff_Day10 { get;set;}
        public decimal Eff_Day11 { get;set;}
        public decimal Eff_Day12 { get;set;}
        public decimal Eff_Day13 { get;set;}
        public decimal Eff_Day14 { get;set;}
        public decimal Eff_Day15 { get;set;}
        public decimal Eff_Day16 { get;set;}
        public decimal Eff_Day17 { get;set;}
        public decimal Eff_Day19 { get;set;}
        public decimal Eff_Day20 { get;set;}
        public decimal Eff_Day21 { get;set;}
        public decimal Eff_Day22 { get;set;}
        public decimal Eff_Day23 { get;set;}
        public decimal Eff_Day24 { get;set;}
        public decimal Eff_Day25 { get;set;}
        public decimal Eff_Day26 { get;set;}
        public decimal Eff_Day27 { get;set;}
        public decimal Eff_Day28 { get;set;}
        public decimal Eff_Day29 { get;set;}
        public decimal Eff_Day30 { get;set;}
        public decimal Eff_Day31 { get;set;}
        public DateTime Eff_CountHour { get;set;}
        public string Eff_CreateDate { get;set;}
        public DateTime Eff_CreateBy { get;set;}
        public string Eff_LastUpdateDate { get;set;}
        public string Eff_LastUpdateBy { get;set;}
        public bool Eff_DelFlg { get;set;}

    }
}
