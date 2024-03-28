using System.ComponentModel.DataAnnotations;


namespace Btec_Website.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        [StringLength(100)]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(255)]
        public string Email { get; set; }

        [Required]
        [StringLength(100)]
        public string Password { get; set; }

        // Navigation property for the roles a user can have
        public virtual ICollection<Role> Roles { get; set; }

        // Navigation property for the courses assigned to the user
        public virtual ICollection<AssignCourse> AssignedCourses { get; set; }
    }
}
