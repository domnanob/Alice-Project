using AliceProject.Models;
using Microsoft.EntityFrameworkCore;

namespace AliceProject.Services
{
    public class TestCasesService : IModelService<TestCase>
    {
        private readonly AppDbContext _context;
        public TestCasesService(AppDbContext context)
        {
            _context = context;
        }
        public async Task Add(TestCase item)
        {
            _context.TestCases.Add(item);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            var testCase = await _context.TestCases.FindAsync(id);
            if (testCase != null)
            {
                _context.TestCases.Remove(testCase);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<TestCase> Get(Guid id)
        {
            var testCase = await _context.TestCases.FindAsync(id);
            if (testCase == null)
            {
                throw new Exception("user not found");
            }
            return testCase;
        }

        public async Task<List<TestCase>> GetAll()
        {
            return await _context.TestCases.ToListAsync();
        }

        public async Task Update(TestCase item)
        {
            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
