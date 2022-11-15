using Microsoft.VisualBasic;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplication4.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [Column("Birth date")]
        [DisplayFormat(DataFormatString = "{yyyy/MM/dd}")]
        public DateTime BirthDate { get; set; }
        [Column("Work Experience")]
        public int WorkExperience { get; set; }
        public string City { get; set; }


    }
}
