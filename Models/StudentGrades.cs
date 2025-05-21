using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
namespace dotnet.Models
{
public class StudentGrades
{
        [Key]
        public int GradeID { get; set; }

        [Required]
        public int Grade { get; set; }

        public int StudentID { get; set; }

        [ForeignKey("StudentID")]
        [ValidateNever]
        public virtual Student Student { get; set; }
    }

}
