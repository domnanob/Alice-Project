using BlazorApp2.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp2.Services
{
    public class RoleService : IRoleService
    {
        private readonly AppDbContext _context;

        public RoleService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<Role>> GetRoles()
        {
            return await _context.Roles.ToListAsync();
        }
    }
}
