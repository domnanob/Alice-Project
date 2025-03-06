using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorApp2.Models
{
    [Table("Users")]
    public class User
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }
        [Required]
        [MaxLength(100)]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public int RoleId { get; set; }
        public Role Role { get; set; } = null!;
    }
}
