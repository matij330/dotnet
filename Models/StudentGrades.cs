using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace dotnet.Models
{
public class StudentGrades
{
        [Key]
        public int GradeID { get; set; }

        [Required]
        public int Grade { get; set; }

        [Required]
        public int StudentID { get; set; }

        [ForeignKey("StudentID")]
        public virtual Student Student { get; set; }
    }

}
