using System;
using System.Collections.Generic;

namespace SharedCookbookBackend.Models;

public partial class RecipeIngredient
{
    public int RecipeIngredientId { get; set; }

    public string IngredientName { get; set; } = null!;

    public int Ordinal { get; set; }

    public bool Optional { get; set; }

    public int? RecipeId { get; set; }

    public int? CategoryId { get; set; }

    public virtual Recipe? Recipe { get; set; }
}
