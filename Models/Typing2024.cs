using System;
using System.Collections.Generic;

namespace WebAPITestProj1.Models;

public partial class Typing2024
{
    public int Id { get; set; }

    public string? Date { get; set; }

    public string? Type { get; set; }

    public decimal? WPM { get; set; }

    public string? Percentage_Complete { get; set; }

    public string? Accuracy { get; set; }
}
