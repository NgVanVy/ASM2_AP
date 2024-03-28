using System.ComponentModel.DataAnnotations;

namespace Btec_Website.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }
        [Required]
        [StringLength(50)]
        public string LastName { get; set; }
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        // Navigation properties
        public virtual ICollection<AssignCourse> AssignCourses { get; set; }
    }
}
