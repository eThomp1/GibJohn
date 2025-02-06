using GibJohn.Models;
using Microsoft.EntityFrameworkCore;

namespace GibJohn.Services
{
    public class UserService
    {
        private readonly TlS2303064GibJohnContext _context;
        public UserService(TlS2303064GibJohnContext context)
        {
            _context = context;
        }
        public async Task AddUserAsync(User user)
        {
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();
        }
        public async Task<User?> LogIn(User user)
        {
            return await _context.Users.FirstOrDefaultAsync(
                c => c.Username == user.Username &&
                c.Password == user.Password);
        }
        public async Task<bool> CheckUsernameExistsAsync(string username)
        {
            var result = await _context.Users.FirstOrDefaultAsync(c => c.Username == username);
            return result != null;
        }
        public async Task<List<User>> GetScoreboard()
        {
            int num = 5;
            List<User> scoreboard = await _context.Users.OrderByDescending(u => u.Points).ToListAsync();
            return scoreboard;
        }
    }
}
