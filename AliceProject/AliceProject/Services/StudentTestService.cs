using AliceProject.Models;
using AliceProject.Components.Pages.users;
using Microsoft.EntityFrameworkCore;

namespace AliceProject.Services
{
    public class StudentTestService : IModelService<StudentTest>
    {
        private readonly AppDbContext _context;

        public StudentTestService(AppDbContext context)
        {
            _context = context;
        }
        public async Task Add(StudentTest item)
        {
            _context.StudentTests.Add(item);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            var studentTest = await _context.StudentTests.FindAsync(id);
            if (studentTest != null)
            {
                _context.StudentTests.Remove(studentTest);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<StudentTest> Get(Guid id)
        {
            var studentTest = await _context.StudentTests.FindAsync(id);
            if (studentTest == null)
            {
                throw new Exception("user not found");
            }
            return studentTest;
        }

        public async Task<List<StudentTest>> GetAll()
        {
            return await _context.StudentTests.ToListAsync();
        }

        public async Task Update(StudentTest item)
        {
            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
