using System;
using System.Collections.Generic;

namespace SharedCookbookBackend.Models;

public partial class RecipeDirection
{
    public int RecipeDirectionId { get; set; }

    public string Instruction { get; set; } = null!;

    public string? ImagePath { get; set; }

    public int Ordinal { get; set; }

    public int? RecipeId { get; set; }

    public virtual Recipe? Recipe { get; set; }
}
