using System.ComponentModel.DataAnnotations;

namespace Btec_Website.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string StudentId { get; set; }
        public string Department { get; set; }
        public int YearOfAdmission { get; set; }
        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public double GPA { get; set; }
        public bool IsActive { get; set; }

        // Quan hệ với bảng Role
        public int RoleId { get; set; }
        public Role Role { get; set; }

        // Các quan hệ khác theo nhu cầu của hệ thống
        // Ví dụ: Danh sách các môn học mà sinh viên đã đăng ký
        public virtual ICollection<Course> Courses { get; set; }

    }
}
