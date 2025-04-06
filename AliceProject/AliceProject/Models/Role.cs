using System.ComponentModel.DataAnnotations.Schema;

namespace AliceProject.Models
{
    [Table("Roles")]
    public class Role
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
    }
}
