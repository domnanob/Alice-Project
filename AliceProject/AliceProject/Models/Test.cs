using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace AliceProject.Models
{
    [Table("Tests")]
    public class Test
    {
        public Guid Id { get; set; }
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }
        [Required]
        [MaxLength(255)]
        public string Directory { get; set; }
        [Required]
        public DateTime CreatedAt { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; } = null!;

    }
}
