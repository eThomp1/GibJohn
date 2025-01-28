using System;
using System.Collections.Generic;

namespace GibJohn.Models;

public partial class User
{
    public int UserId { get; set; }

    public string Username { get; set; } = null!;

    public string Password { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public DateTime Dob { get; set; }

    public int Points { get; set; }

    public int? Time { get; set; }

    public virtual ICollection<Game> Games { get; set; } = new List<Game>();
}
