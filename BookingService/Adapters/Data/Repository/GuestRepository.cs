using Domain.Entities;
using Domain.Ports;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository
{
    public class GuestRepository : IGuestRepository
    {
        private readonly AppDbContext _context;

        public GuestRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<int> Create(Guest guest)
        {
            _context.Guests.Add(guest);
            await _context.SaveChangesAsync();
            return guest.Id;
        }

        public async Task<Guest> Get(int id)
        {
            return await _context.Guests.Where(g => g.Id == id).FirstOrDefaultAsync();
        }
    }
}
