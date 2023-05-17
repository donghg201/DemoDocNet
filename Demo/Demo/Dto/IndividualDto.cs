using Demo.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace Demo.Dto
{
    public class IndividualDto
    {
        public DateTime? BirthDate { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

    }
}
