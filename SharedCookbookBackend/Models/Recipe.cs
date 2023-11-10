using System;
using System.Collections.Generic;

namespace SharedCookbookBackend.Models;

public partial class Recipe
{
    public int RecipeId { get; set; }

    public string Title { get; set; } = null!;

    public string? Summary { get; set; }

    public string? ImagePath { get; set; }

    public int? CookbookId { get; set; }

    public virtual Cookbook? Cookbook { get; set; }

    public virtual ICollection<CookbookNotification> CookbookNotifications { get; set; } = new List<CookbookNotification>();

    public virtual ICollection<IngredientCategory> IngredientCategories { get; set; } = new List<IngredientCategory>();

    public virtual ICollection<RecipeComment> RecipeComments { get; set; } = new List<RecipeComment>();

    public virtual ICollection<RecipeDirection> RecipeDirections { get; set; } = new List<RecipeDirection>();

    public virtual ICollection<RecipeIngredient> RecipeIngredients { get; set; } = new List<RecipeIngredient>();

    public virtual ICollection<RecipeRating> RecipeRatings { get; set; } = new List<RecipeRating>();
}
