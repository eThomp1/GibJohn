using System;
using System.Collections.Generic;

namespace GibJohn.Models;

public partial class Question
{
    public int QuestionId { get; set; }

    public string? QuestionText { get; set; }

    public string? QuestionCorrect { get; set; }

    public string? QuestionWrong1 { get; set; }

    public string? QuestionWrong2 { get; set; }

    public string? QuestionWrong3 { get; set; }

    public int? Points { get; set; }

    public int? GameId { get; set; }

    public virtual Game? Game { get; set; }
}
