using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace dotnet.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }
        [Required]
        public string FirstName { get; set; }
        public string SecondName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public int Index { get; set; }

    }
}
