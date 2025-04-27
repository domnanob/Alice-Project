using AliceProject.Helpers;
using AliceProject.Models;

namespace AliceProject
{
    public class DataSeeder
    {
        private readonly AppDbContext _context;
        public DataSeeder(AppDbContext context) { 
            _context = context;
        }
        public void Seed() {
            SeedRoles();
            SeedUsers();
        }
        private void SeedRoles() {
            if (!_context.Roles.Any())
            {
                IEnumerable<Role> roles = new List<Role>()
                {
                    new Role() {
                        Id = Guid.NewGuid(),
                        Name = "admin"
                    },
                    new Role() {
                        Id = Guid.NewGuid(),
                        Name = "user"
                    }
                };
                _context.Roles.AddRange(roles);
                _context.SaveChanges();
            }
        }
        private void SeedUsers() {
            if (!_context.Users.Any())
            {
                IEnumerable<User> users = new List<User>()
                {
                    new User()
                    {
                        Id = Guid.NewGuid(),
                        Email = "admin@aliceproject.com",
                        FirstName = "admin",
                        LastName = "admin",
                        Password =  new PasswordHandling().Hash("admin"),
                        RoleId = _context.Roles.Single(x => x.Name == "admin").Id
                    },
                    new User()
                    {
                        Id = Guid.NewGuid(),
                        Email = "domnanob@aliceproject.com",
                        FirstName = "Domnanovich",
                        LastName = "Balint",
                        Password =  new PasswordHandling().Hash("Password"),
                        RoleId = _context.Roles.Single(x => x.Name == "user").Id
                    }
                };
                _context.Users.AddRange(users);
                _context.SaveChanges();
            }
        }
    }

}
