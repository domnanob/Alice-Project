using Microsoft.EntityFrameworkCore;

namespace BlazorApp2.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        public DbSet<Club> Clubs { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<TestCase> TestCases { get; set; }
        public DbSet<StudentTest> StudentTests { get; set; }
    }
}
