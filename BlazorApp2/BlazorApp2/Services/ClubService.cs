using BlazorApp2.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorApp2.Services
{
    public class ClubService : IClubService
    {
        private readonly AppDbContext _context;

        public ClubService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Club>> GetClubs()
        {
            return await _context.Clubs.ToListAsync();
        }

        public async Task<Club> GetClub(int id)
        {
            var club = await _context.Clubs.FindAsync(id);
            if (club == null)
            {
                throw new Exception("club not found");
            }
            return club;
        }

        public async Task AddClub(Club club)
        {
            _context.Clubs.Add(club);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateClub(Club club)
        {
            _context.Entry(club).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteClub(int id)
        {
            var club = await _context.Clubs.FindAsync(id);
            if (club != null)
            {
                _context.Clubs.Remove(club);
                await _context.SaveChangesAsync();
            }
        }
    }
}
