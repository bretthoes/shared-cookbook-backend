using System;
using System.Collections.Generic;

namespace SharedCookbookBackend.Models;

public partial class Person
{
    public int PersonId { get; set; }

    public string DisplayName { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string? ImagePath { get; set; }

    public string? PasswordHash { get; set; }

    public string? PasswordSalt { get; set; }

    public virtual ICollection<CookbookInvitation> CookbookInvitationRecipientPeople { get; set; } = new List<CookbookInvitation>();

    public virtual ICollection<CookbookInvitation> CookbookInvitationSenderPeople { get; set; } = new List<CookbookInvitation>();

    public virtual ICollection<CookbookMember> CookbookMembers { get; set; } = new List<CookbookMember>();

    public virtual ICollection<CookbookNotification> CookbookNotifications { get; set; } = new List<CookbookNotification>();

    public virtual ICollection<Cookbook> Cookbooks { get; set; } = new List<Cookbook>();

    public virtual ICollection<RecipeComment> RecipeComments { get; set; } = new List<RecipeComment>();

    public virtual ICollection<RecipeRating> RecipeRatings { get; set; } = new List<RecipeRating>();
}
