using System;
using System.Collections.Generic;

namespace SharedCookbookBackend.Models;

public partial class RecipeComment
{
    public int RecipeCommentId { get; set; }

    public int? RecipeId { get; set; }

    public int? PersonId { get; set; }

    public string CommentText { get; set; } = null!;

    public DateTime CreationDate { get; set; }

    public virtual Person? Person { get; set; }

    public virtual Recipe? Recipe { get; set; }
}
