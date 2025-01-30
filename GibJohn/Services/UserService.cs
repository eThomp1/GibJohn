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
    }
}
