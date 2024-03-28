using System.ComponentModel.DataAnnotations;

namespace Btec_Website.Models
{
    public class Course
    {
        [Key]
        public int CourseId { get; set; }

        [Required]
        [StringLength(100)]
        public string CourseName { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        // Navigation property for the assignments of this course to users
        public virtual ICollection<AssignCourse> Assignments { get; set; }
    }
}
