using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dotnet.Models
{
    public class StudentOceny
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Range(2,5)]

        public int StudentId { get; set; }  // <-- TO DODAJ
        public int Grade { get; set; }
        [ForeignKey("StudentId")]
        public virtual Student Student { get; set; }
    }
}


