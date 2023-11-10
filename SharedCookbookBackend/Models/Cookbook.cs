using System;
using System.Collections.Generic;

namespace SharedCookbookBackend.Models;

public partial class Cookbook
{
    public int CookbookId { get; set; }

    public string Title { get; set; } = null!;

    public string? CoverPattern { get; set; }

    public string? CoverFont { get; set; }

    public string? CoverColor { get; set; }

    public string? CoverAccentColor { get; set; }

    public int? PersonId { get; set; }

    public string? ImagePath { get; set; }

    public virtual ICollection<CookbookInvitation> CookbookInvitations { get; set; } = new List<CookbookInvitation>();

    public virtual ICollection<CookbookMember> CookbookMembers { get; set; } = new List<CookbookMember>();

    public virtual ICollection<CookbookNotification> CookbookNotifications { get; set; } = new List<CookbookNotification>();

    public virtual Person? Person { get; set; }

    public virtual ICollection<Recipe> Recipes { get; set; } = new List<Recipe>();
}
