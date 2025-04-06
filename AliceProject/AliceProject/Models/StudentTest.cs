using System.ComponentModel.DataAnnotations.Schema;

namespace AliceProject.Models
{
    [Table("StudentTests")]
    public class StudentTest
    {
        public Guid Id { get; set; }
        public string StudentName { get; set; }
        public int PassedCount { get; set; }
        public Guid TestId { get; set; }
        public Test Test { get; set; } = null!;
    }
}
