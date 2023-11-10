using System;
using System.Collections.Generic;

namespace SharedCookbookBackend.Models;

public partial class IngredientCategory
{
    public int IngredientCategoryId { get; set; }

    public string Title { get; set; } = null!;

    public int? RecipeId { get; set; }

    public virtual Recipe? Recipe { get; set; }
}
