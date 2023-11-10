using System;
using System.Collections.Generic;

namespace SharedCookbookBackend.Models;

public partial class CookbookNotification
{
    public int CookbookNotificationId { get; set; }

    public int? SenderPersonId { get; set; }

    public int? CookbookId { get; set; }

    public string ActionType { get; set; } = null!;

    public int? RecipeId { get; set; }

    public DateTime NotificationDate { get; set; }

    public bool IsSeen { get; set; }

    public virtual Cookbook? Cookbook { get; set; }

    public virtual Recipe? Recipe { get; set; }

    public virtual Person? SenderPerson { get; set; }
}
