using GibJohn.Components.Pages;
using GibJohn.Models;
using Microsoft.EntityFrameworkCore;
namespace GibJohn.Services

{
    public class GameService
    {
        public readonly TlS2303064GibJohnContext _context;
        public GameService(TlS2303064GibJohnContext context) 
        {
            _context = context;
        }
        public async Task GetQuestions()
    }
}
