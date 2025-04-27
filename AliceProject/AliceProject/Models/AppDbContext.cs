using Microsoft.EntityFrameworkCore;

namespace AliceProject.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<TestCase> TestCases { get; set; }
        public DbSet<StudentTest> StudentTests { get; set; }
    }
}
