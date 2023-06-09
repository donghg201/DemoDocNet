﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace QuanLyPhim.Models
{
    public class Movie
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int MovieId { get; set; }
        //[StringLength(10,ErrorMessage ="Not enough length")]
        public string MovieName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Actor { get; set; }
        public string Director { get; set; }
        public string MovieStudio { get; set; }
        public string PosterMovie { get; set; }
        public string Note { get; set; }

        //public int CateId { get; set; }
        //[ForeignKey("CateId")]
        //public Category Category { get; set; }
    }
}
