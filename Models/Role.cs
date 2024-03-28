using System.ComponentModel.DataAnnotations;

namespace Btec_Website.Models
{
    public class Role
    {
        [Key]
        public int RoleId { get; set; }

        [Required]
        [StringLength(50)]
        public string RoleName { get; set; }

        // Navigation property for the users associated with a role
        public virtual ICollection<User> Users { get; set; }
    }
}
