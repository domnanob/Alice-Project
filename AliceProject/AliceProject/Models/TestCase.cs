using System.ComponentModel.DataAnnotations.Schema;
using System.Xml;

namespace AliceProject.Models
{
    [Table("TestCases")]
    public class TestCase
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Input { get; set; }
        public string ExpectedOutput { get; set; }
        public Guid TestId { get; set; }
        public Test Test { get; set; } = null!;
    }
}
