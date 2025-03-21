using BlazorApp2.Components.Pages.users;
using BlazorApp2.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp2.Services
{
    public class TestService : IModelService<Test>
    {
        private readonly AppDbContext _context;

        public TestService(AppDbContext context) {
            _context = context;
        }
        public async Task Add(Test item)
        {
            _context.Tests.Add(item);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            var test = await _context.Tests.FindAsync(id);
            if (test != null)
            {
                _context.Tests.Remove(test);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Test>> GetAll()
        {
            return await _context.Tests.ToListAsync();
        }

        public async Task<Test> Get(Guid id)
        {
            var test = await _context.Tests.FindAsync(id);
            if (test == null)
            {
                throw new Exception("user not found");
            }
            return test;
        }

        public async Task Update(Test item)
        {
            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
