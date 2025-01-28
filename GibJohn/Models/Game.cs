using System;
using System.Collections.Generic;

namespace GibJohn.Models;

public partial class Game
{
    public int GameId { get; set; }

    public int NumQuestion { get; set; }

    public sbyte? Completed { get; set; }

    public int? UserId { get; set; }

    public virtual ICollection<Question> Questions { get; set; } = new List<Question>();

    public virtual User? User { get; set; }
}
