using System;
using System.Collections.Generic;

namespace SharedCookbookBackend.Models;

public partial class CookbookMember
{
    public int CookbookMemberId { get; set; }

    public int? PersonId { get; set; }

    public int? CookbookId { get; set; }

    public bool AddRecipePermission { get; set; }

    public bool DeleteRecipePermission { get; set; }

    public bool InvitePermission { get; set; }

    public DateTime? JoinDate { get; set; }

    public virtual Cookbook? Cookbook { get; set; }

    public virtual Person? Person { get; set; }
}
