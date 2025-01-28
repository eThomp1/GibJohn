using GibJohn.Models;
using Microsoft.EntityFrameworkCore;

namespace GibJohn.Services
{
    public class CustomerService
    {
        private readonly TlS2303064GibJohnContext _context;
        public CustomerService(TlS2303064GibJohnContext context)
        {
            _context = context;
        }
    }
}
