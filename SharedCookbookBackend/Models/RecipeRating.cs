using System;
using System.Collections.Generic;

namespace SharedCookbookBackend.Models;

public partial class RecipeRating
{
    public int RecipeRatingId { get; set; }

    public int? RecipeId { get; set; }

    public int? PersonId { get; set; }

    public int RatingValue { get; set; }

    public DateTime CreationDate { get; set; }

    public virtual Person? Person { get; set; }

    public virtual Recipe? Recipe { get; set; }
}
