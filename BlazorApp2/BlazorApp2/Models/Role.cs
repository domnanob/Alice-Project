using System.ComponentModel.DataAnnotations.Schema;

namespace BlazorApp2.Models
{
    [Table("Roles")]
    public class Role
    {
        public Guid Id {  get; set; }
        public string Name { get; set; }
    }
}
