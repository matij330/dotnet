using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dotnet.Models
{
    public class Student
    {
        [Key]
        public int StudentID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }

        // Poprawiona nazwa typu
        public virtual List<StudentGrades> Grades { get; set; } = new List<StudentGrades>();
    }

}