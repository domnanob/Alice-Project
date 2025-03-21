using BlazorApp2.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp2.Services
{
    public class RoleService : IModelService<Role>
    {
        private readonly AppDbContext _context;

        public RoleService(AppDbContext context)
        {
            _context = context;
        }
        public async Task<List<Role>> GetAll()
        {
            return await _context.Roles.ToListAsync();
        }
        public async Task Add(Role item)
        {
            throw new NotImplementedException();
        }

        public async Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<Role> Get(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task Update(Role item)
        {
            throw new NotImplementedException();
        }
    }
}
